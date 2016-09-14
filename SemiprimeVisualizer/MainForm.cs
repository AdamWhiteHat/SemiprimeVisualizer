using System;
using System.Linq;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing.Imaging;

namespace SemiprimeVisualizer
{
	public partial class MainForm : Form
	{
		#region Properties
		
		// Numbers		
		private BigInteger Sqrt;		
		private BigInteger SemiPrime;
		private RichTextBoxBehavior q;
		private RichTextBoxBehavior p;
		private RichTextBoxBehavior goalPos;
		private RichTextBoxBehavior goalNeg;
		private RichTextBoxBehavior product;
		private RichTextBoxBehavior productPos;
		private RichTextBoxBehavior productNeg;

		// Misc		
		private int PadLength;
		private int skipCounter;
		private bool isInitialized;		
		private BigInteger lastProduct;
		private QuadraticSearch quadraticSearch;

		// Flags
		private bool IsAutomatedRunning = false;
		private string CyclesFilename = "Cycles.{0}.txt";

		// Static Readonly
		private static readonly string sampleSemiPrime = "1000730021";
		private static readonly string ButtonTextStop = "Stop";
		private static readonly string ButtonTextSearch = "Automate search...";

		#endregion
		#region Constructor / Initializer

		public MainForm()
		{
			InitializeComponent();

			skipCounter = 0;
			isInitialized = false;
			CyclesFilename = string.Format(CyclesFilename, DateTime.Now.ToFileTimeUtc().ToString().Reverse());

			SemiPrime = 0;
			numericUpDownP.Increment = 1;
			numericUpDownQ.Increment = 1;
			timerAutoStep.Interval = (int)numericTimerDelay.Value;
			timerAutoStep.Tick += new EventHandler((s, e) => Step());
			numericTimerDelay.ValueChanged += new EventHandler((s, e) =>
			{
				bool resume = timerAutoStep.Enabled;
				if (resume) { timerAutoStep.Stop(); }
				timerAutoStep.Interval = (int)numericTimerDelay.Value;
				if (resume) { timerAutoStep.Start(); }
			});
			btnOpen.Click += new EventHandler(btnOpen_Click);
			btnSaveProgress.Click += new EventHandler(btnSave_Click);
			btnReset.Click += new EventHandler((s, e) => Reset());
			btnAutomateSearch.Click += new EventHandler((s, e) => AutomationToggle());

			tbSemiPrime.KeyDown += new KeyEventHandler((s, e) =>
			{
				if (e.KeyData == Keys.Enter) e.SuppressKeyPress = true;
			});
			tbSemiPrime.KeyUp += new KeyEventHandler((s, e) =>
			{
				if (e.KeyData == Keys.Enter) InitializeNewSemiPrime(tbSemiPrime.Text);
			});

			p = new RichTextBoxBehavior(rtbP, TextBoxBehaviors.RestoreCursorPosition);
			q = new RichTextBoxBehavior(rtbQ, TextBoxBehaviors.RestoreCursorPosition);
			product = new RichTextBoxBehavior(rtbProduct,null);
			goalPos = new RichTextBoxBehavior(rtbDeltaGoalPositive, TextBoxBehaviors.TrendHighlighting);
			goalNeg = new RichTextBoxBehavior(rtbDeltaGoalNegative, TextBoxBehaviors.TrendHighlighting);
			productPos = new RichTextBoxBehavior(rtbDeltaProductPositive, TextBoxBehaviors.TrendHighlighting);
			productNeg = new RichTextBoxBehavior(rtbDeltaProductNegitive, TextBoxBehaviors.TrendHighlighting);

			Reset();
			
			rtbP.KeyDown += new KeyEventHandler(tbP_KeyDown);
			rtbP.KeyDown += new KeyEventHandler(tbPQ_KeyDown);
			rtbQ.KeyDown += new KeyEventHandler(tbPQ_KeyDown);
			rtbP.TextChanged += new EventHandler(tbPQ_TextChanged);
			rtbQ.TextChanged += new EventHandler(tbPQ_TextChanged);
			numericUpDownP.ValueChanged += new EventHandler(numericUpDownP_ValueChanged);
			numericUpDownQ.ValueChanged += new EventHandler(numericUpDownQ_ValueChanged);
		}

		private void InitializeNewSemiPrime(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{ return; }

			lastProduct = 0;
			SemiPrime = 0;
			Sqrt = 0;

			SemiPrime = BigInteger.Parse(Utils.GetSanitizedString(input));
			Sqrt = SemiPrime.Sqrt();

			PadLength = Math.Min(tbSemiPrime.TextLength, 30);
			q.PaddingLength = PadLength;
			p.PaddingLength = PadLength;
			product.PaddingLength = PadLength;
			goalPos.PaddingLength = PadLength;
			goalNeg.PaddingLength = PadLength;
			productPos.PaddingLength = PadLength;
			productNeg.PaddingLength = PadLength;

			// Update semi-prime boxes
			tbSemiPrime.Text = SemiPrime.ToString();
			tbSemiPrime0.Text = SemiPrime.ToString();
			rtbSemiPrime.Text = SemiPrime.ToString();
			tbSquareRoot.Text = Sqrt.ToString();

			p.CurrentValue = Sqrt % 2 == 0 ? Sqrt - 1 : Sqrt;
			q.CurrentValue = Sqrt % 2 == 0 ? Sqrt + 1 : Sqrt;

			quadraticSearch = null;

			ChangeRichTextAlignment(rtbDeltaGoalNegative, HorizontalAlignment.Center);
			ChangeRichTextAlignment(rtbDeltaGoalPositive, HorizontalAlignment.Center);
			ChangeRichTextAlignment(rtbDeltaProductNegitive, HorizontalAlignment.Center);
			ChangeRichTextAlignment(rtbDeltaProductPositive, HorizontalAlignment.Center);

			UpdateControls();
		}
		
		private void ChangeRichTextAlignment(RichTextBox textBox, HorizontalAlignment alignment)
		{
			textBox.Focus();
			textBox.SelectAll();
			textBox.SelectionAlignment = alignment;
			textBox.DeselectAll();			
		}

		#endregion
		#region Automation

		private void AutomationToggle()
		{
			if (IsAutomatedRunning)
			{
				btnAutomateSearch.Text = ButtonTextSearch;
				timerAutoStep.Stop();
				skipCounter = 0;
				isInitialized = false;
				IsAutomatedRunning = false;
			}
			else
			{
				IsAutomatedRunning = true;
				if (string.IsNullOrWhiteSpace(rtbProduct.Text)) { return; }
				btnAutomateSearch.Text = ButtonTextStop;
				MoveCursorToLeastSignifigantDigit();				
				chart1.Series[0].Points.Clear();
				chart1.Series[1].Points.Clear();
				chart1.ResetAutoValues();
				timerAutoStep.Start();
			}
		}
		
		private void Step()
		{
			if (product.CurrentValue > SemiPrime)
			{
				numericUpDownP.DownButton();
			}
			else if (SemiPrime > product.CurrentValue)
			{
				numericUpDownQ.UpButton();
			}
		}

		#endregion
		#region Numeric Up/Down Step Feature

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData.HasFlag(Keys.Control) && keyData.HasFlag(Keys.P))
			{
				if (chart1 != null && chart1.ChartAreas.Count > 0)
				{
					string filename = Utils.FileDialog<SaveFileDialog>("PNG Files(*.png) | *.png | JPG Files(*.jpg) | *.jpg | BMP Files(*.bmp) | *.bmp | GIF Files(*.gif) | *.gif | TIFF Files(*.tiff) | *.tiff");
					if (!string.IsNullOrWhiteSpace(filename))
					{
						string ext = Path.GetExtension(filename);
						ChartImageFormat format = ChartImageFormat.Bmp;

						if (ext == ".png")
						{
							format = ChartImageFormat.Png;
						}
						else if (ext == ".jpg")
						{
							format = ChartImageFormat.Jpeg;
						}
						else if(ext == ".bmp")
						{
							format = ChartImageFormat.Bmp;
						}
						else if (ext == ".gif")
						{
							format = ChartImageFormat.Gif;
						}
						else if (ext == ".tiff")
						{
							format = ChartImageFormat.Tiff;
						}

						chart1.SaveImage(filename, format);
					}				
				}
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void numericUpDownP_ValueChanged(object sender, EventArgs e)
		{
			BigInteger temp = p.CurrentValue;
			temp += (int)numericUpDownP.Value;
			p.CurrentValue = temp;
			numericUpDownP.Value = 0;
		}

		private void numericUpDownQ_ValueChanged(object sender, EventArgs e)
		{
			BigInteger temp = q.CurrentValue;
			temp += (int)numericUpDownQ.Value;
			q.CurrentValue = temp;
			numericUpDownQ.Value = 0;
		}
		
		// Simulate numeric control UP/DOWN
		private void tbP_KeyDown(object sender, KeyEventArgs e)
		{			
			if (e.KeyCode == Keys.Down && e.Control)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;				
				p.SavedCursorPosition = rtbP.SelectionStart;

				if (rtbP.SelectionLength == 0 && rtbP.SelectionStart < rtbP.TextLength)
				{
					BigInteger placeValue = BigInteger.Pow(10, (rtbP.TextLength - rtbP.SelectionStart));
					BigInteger pDiffPlus = p.CurrentValue;
					BigInteger pDiffMinus = pDiffPlus - placeValue;
					BigDecimal qDiffPlus = SemiPrime / pDiffPlus;
					BigDecimal qDiffMinus = SemiPrime / pDiffMinus;

					BigInteger toAdd = (BigInteger)(qDiffMinus - qDiffPlus) - 1;

					q.CurrentValue += toAdd;
					p.CurrentValue -= placeValue;					
				}
			}
		}

		// Simulate numeric control UP/DOWN
		private void tbPQ_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Control)
			{
				RichTextBox cntrl = (RichTextBox)sender;
				NumericUpDown numControl;
				if (cntrl.Name == "rtbP")
				{
					p.SavedCursorPosition = rtbP.SelectionStart;
					numControl = numericUpDownP;
				}
				else
				{
					q.SavedCursorPosition = rtbQ.SelectionStart;
					numControl = numericUpDownQ;
				}

				if (e.KeyData == Keys.Up)
				{
					numControl.UpButton();
				}
				else if (e.KeyData == Keys.Down)
				{
					numControl.DownButton();
				}
			}
		}

		#endregion
		#region P & Q

		private void tbPQ_TextChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}
		
		#endregion
		#region Update / Calculate

		//  When the semi-prime is changed, this updates everything according to that
		private void UpdateControls()
		{
			lastProduct = product.CurrentValue;
			BigInteger nextProduct = BigInteger.Multiply(p.CurrentValue, q.CurrentValue);
			product.CurrentValue = nextProduct;

			HighlightMatchingCharacters(rtbSemiPrime, rtbProduct);
			CalculateDeltas();
			UpdateChart();

			if (product.CurrentValue == SemiPrime) // Semi-prime is factored: Solved!
			{
				OnSolved();
			}		
		}

		private void UpdateChart()
		{
			if (!isInitialized)
			{
				if (skipCounter++ > 10)
				{
					chart1.Series[0].XValueType = ChartValueType.UInt32;
					chart1.Series[1].XValueType = ChartValueType.UInt32;
					isInitialized = true;
				}
				return;
			}
			BigInteger gpVal = goalPos.CurrentValue;			
			BigInteger ppVal = productPos.CurrentValue;

			BigInteger gnVal = goalNeg.CurrentValue;
			BigInteger pnVal = productNeg.CurrentValue;

			UInt32 MaximumValue = 2147483648;//4000000000;

			if (gpVal > MaximumValue)
			{
				gpVal = (gpVal % MaximumValue);
			}			
			if (ppVal > MaximumValue)
			{
				ppVal = ppVal % MaximumValue;
			}
			if (gnVal > MaximumValue)
			{
				gnVal = gnVal % MaximumValue;
			}
			if (pnVal > MaximumValue)
			{
				pnVal = pnVal % MaximumValue;
			}

			UInt32 a = (UInt32)gpVal;
			UInt32 b = (UInt32)ppVal;

			UInt32 x = (UInt32)gnVal;
			UInt32 y = (UInt32)pnVal;

			if (a - b == 0 || x - y == 0)
			{
				return;
			}

			chart1.Series[0].Points.AddXY(a,b);
			chart1.Series[1].Points.AddXY(x,y);
		}
		
		//private int lastMatchingSelectionLength = 0;
		public void HighlightMatchingCharacters(RichTextBox reference, RichTextBox toHighlight)
		{
			int matchingSelectionLength = Utils.GetMatchingLength(reference.Text, toHighlight.Text);
			string numSolvedText = matchingSelectionLength.ToString();
			if (tbNumbersSolved.Text != numSolvedText)
			{
				tbNumbersSolved.Text = numSolvedText;
			}

			Utils.HighlightRichTextBox(toHighlight, matchingSelectionLength);
			//if (matchingSelectionLength != lastMatchingSelectionLength) {}
			//lastMatchingSelectionLength = matchingSelectionLength;
		}
		
		private void OnSolved()
		{
			if (timerAutoStep.Enabled)
			{
				AutomationToggle();
			}
			rtbP.BackColor = Color.MintCream;
			rtbQ.BackColor = Color.MintCream;
			rtbProduct.BackColor = Color.MintCream;
			tbSemiPrime.BackColor = Color.MintCream;
			MessageBox.Show("Product is equal to Semi-Prime!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void CalculateDeltas()
		{
			BigInteger goalDelta = 0;
			BigInteger productDelta = 0;

			if (product.CurrentValue > SemiPrime)
			{
				goalDelta = product.CurrentValue - SemiPrime;
				goalNeg.CurrentValue = goalDelta;
			}
			else
			{
				goalDelta = SemiPrime - product.CurrentValue;
				goalPos.CurrentValue = goalDelta;
			}

			if (lastProduct > product.CurrentValue)
			{
				productDelta = lastProduct - product.CurrentValue;
				productNeg.CurrentValue = productDelta;
			}
			else
			{
				productDelta = product.CurrentValue - lastProduct;
				productPos.CurrentValue = productDelta;
			}
		}

		#endregion
		#region Open/Save State

		private void btnSave_Click(object sender, EventArgs e)
		{
			string filename = Utils.FileDialog<SaveFileDialog>("XML Files(*.xml) | *.xml");
			if (string.IsNullOrWhiteSpace(filename))
			{
				return;
			}

			XDocument xdoc = new XDocument(
								new XElement("Root",
									new XElement("SemiPrime", SemiPrime.ToString()),
									new XElement("Sqrt", Sqrt.ToString()),
									new XElement("P", p.CurrentValue.ToString()),
									new XElement("Q", q.CurrentValue.ToString()),
									new XElement("Product", product.CurrentValue.ToString())
								)
							);

			xdoc.Save(filename);
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			string filename = Utils.FileDialog<OpenFileDialog>("XML Files(*.xml) | *.xml");
			if (string.IsNullOrWhiteSpace(filename))
			{
				return;
			}
			XDocument xdoc = XDocument.Load(filename);

			IEnumerable<XElement> elements = xdoc.Root.Descendants();

			string semiprime = elements.Where(n => n.Name == "SemiPrime").Single().Value;
			string sqrt = elements.Where(n => n.Name == "Sqrt").Single().Value;

			string pStr = elements.Where(n => n.Name == "P").Single().Value;
			string qStr = elements.Where(n => n.Name == "Q").Single().Value;

			string prod = elements.Where(n => n.Name == "Product").Single().Value;

			BigInteger.TryParse(semiprime, out SemiPrime);
			BigInteger sqr = 0;
			BigInteger.TryParse(sqrt, out sqr);
			Sqrt = sqr;

			BigInteger oP = new BigInteger();
			BigInteger oQ = new BigInteger();
			BigInteger oProd = new BigInteger();
			BigInteger.TryParse(pStr, out oP);
			BigInteger.TryParse(qStr, out oQ);
			BigInteger.TryParse(prod, out oProd);

			p.CurrentValue = oP;
			q.CurrentValue = oQ;
			product.CurrentValue = oProd;

			tbSemiPrime.Text = SemiPrime.ToString();
			tbSemiPrime0.Text = SemiPrime.ToString();
			rtbSemiPrime.Text = SemiPrime.ToString();
			tbSquareRoot.Text = Sqrt.ToString();

			UpdateControls();
		}

		#endregion
		#region Misc

		private void Reset()
		{
			tbSemiPrime.Text = sampleSemiPrime;
			InitializeNewSemiPrime(tbSemiPrime.Text.Trim());
		}

		private void MoveCursorToLeastSignifigantDigit()
		{
			rtbP.Select(rtbP.TextLength, rtbP.TextLength);
			rtbQ.Select(rtbQ.TextLength, rtbQ.TextLength);
		}

		//private void WriteOutput(string message)
		//{
		//	tbOutput.AppendText(string.Concat(message, Environment.NewLine));
		//}

		#endregion

		#region Quadratic Search

		private void btnQuadraticResidue_Click(object sender, EventArgs e)
		{
			timerQuadraticSearch.Start();
		}

		List<BigInteger> DifferenceOfSquares = new List<BigInteger>();
		List<BigInteger> LargestPrimeFactors = new List<BigInteger>();
		List<BigInteger> FermatSquares = new List<BigInteger>();
		List<BigInteger> SmoothNumbers = new List<BigInteger>();
		IEnumerable<BigInteger> differenceOfSquaresEnumerator;
		//IEnumerable<BigInteger> largestPrimeFactorEnumerator;
		IEnumerable<BigInteger> fermatSquaresEnumerator;
		IEnumerable<BigInteger> smoothNumbersEnumerator;
		private void timerQuadraticSearch_Tick(object sender, EventArgs e)
		{
			timerQuadraticSearch.Stop();

			if (quadraticSearch == null)
			{
				quadraticSearch = new QuadraticSearch(SemiPrime);
				differenceOfSquaresEnumerator = quadraticSearch.GetDifferenceOfSquares();
			}

			if (differenceOfSquaresEnumerator != null)
			{
				int skipA = 0;
				if (DifferenceOfSquares.Count > 0)
				{
					skipA = DifferenceOfSquares.Count;
				}
				List<BigInteger> newDifferenceOfSquares = differenceOfSquaresEnumerator.Skip(skipA).Take(1000).ToList();
				DifferenceOfSquares.AddRange(newDifferenceOfSquares);

				string result = string.Join(Environment.NewLine, newDifferenceOfSquares);

				//WriteOutput("Difference of Squares");
				//WriteOutput(result + Environment.NewLine);

				LargestPrimeFactors.AddRange(quadraticSearch.SelectLargestFactor());

				int index = 0;
				Dictionary<BigInteger, List<int>> primeFactorIndexDictionary = new Dictionary<BigInteger, List<int>>();
				foreach (BigInteger factor in LargestPrimeFactors)
				{
					if (primeFactorIndexDictionary.ContainsKey(factor))
					{
						primeFactorIndexDictionary[factor].Add(index++);
					}
					else
					{
						List<int> newList = new List<int>();
						newList.Add(index++);
						primeFactorIndexDictionary.Add(factor, newList);
					}
				}

				IOrderedEnumerable<KeyValuePair<BigInteger, List<int>>> orderedPrimeFactors = primeFactorIndexDictionary.OrderBy(kvp => kvp.Key);

				result = string.Join(Environment.NewLine, orderedPrimeFactors.Select(kvp => string.Format("{0} :\t[{1}]", kvp.Key, string.Join(", ", kvp.Value))));

				//WriteOutput("Largest Prime Factors");
				//WriteOutput(result + Environment.NewLine);

				List<KeyValuePair<BigInteger, List<int>>> smoothNumbers = orderedPrimeFactors.Where(kvp => kvp.Value.Count > 2).ToList();

				List<KeyValuePair<BigInteger, List<BigInteger>>> FoundFactors = new List<KeyValuePair<BigInteger, List<BigInteger>>>();

				foreach (KeyValuePair<BigInteger, List<int>> smoothFactors in smoothNumbers)
				{
					if (smoothFactors.Key == 1)
					{
						continue;
					}

					List<BigInteger> factors = new List<BigInteger>();
					foreach (int indx in smoothFactors.Value)
					{
						factors.Add(DifferenceOfSquares[indx]);
					}
					//WriteOutput(string.Format("Common Prime Factor: {0} of [{1}]", smoothFactors.Key, string.Join(", ", factors)));

					BigInteger sum = factors.Aggregate(BigInteger.Multiply);

					if (QuadraticSearch.IsSquare(sum))
					{
						//WriteOutput(string.Format("*FoundSquare: {0}\r\n*Factors: {1}", smoothFactors.Key, string.Join(", ", factors)));
						FoundFactors.Add(new KeyValuePair<BigInteger, List<BigInteger>>(smoothFactors.Key, factors));
					}
				}

				if (DifferenceOfSquares.Count > 10000)
				{
					if (FermatSquares.Count < 100)
					{
						if (fermatSquaresEnumerator == null)
						{
							fermatSquaresEnumerator = quadraticSearch.WhereFermatSquareFilter();
						}

						if (fermatSquaresEnumerator != null)
						{
							int skipB = 0;
							if (FermatSquares.Count > 0)
							{
								skipB = FermatSquares.Count;
							}
							List<BigInteger> newSquares = fermatSquaresEnumerator.Skip(skipB).Take(1).ToList();
							FermatSquares.AddRange(newSquares);
							result = string.Join(Environment.NewLine, newSquares);

							//WriteOutput("(a^2)-n squares");
							//WriteOutput(result + Environment.NewLine);
						}
					}
					else
					{
						if (smoothNumbersEnumerator == null)
						{
							smoothNumbersEnumerator = quadraticSearch.WhereSmoothNumberFilter(quadraticSearch.ToFactor, FermatSquares);
						}

						if (smoothNumbersEnumerator != null)
						{
							int skipC = 0;
							if (SmoothNumbers.Count > 0)
							{
								skipC = SmoothNumbers.Count;
							}
							List<BigInteger> newSmoothNumbers = smoothNumbersEnumerator.Skip(skipC).Take(10).ToList();
							SmoothNumbers.AddRange(newSmoothNumbers);
							result = string.Join(Environment.NewLine, newSmoothNumbers);

							//WriteOutput("Smooth Numbers");
							//WriteOutput(result + Environment.NewLine);
						}
					}
				}
			}
		}

		#endregion
	}
}
