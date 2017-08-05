using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Linq;

using System.Collections.Generic;

namespace SemiprimeVisualizer
{
	using System.Numerics;
	using System.Windows.Forms;
	using System.Windows.Forms.DataVisualization;
	using System.Windows.Forms.DataVisualization.Charting;

	public partial class MainForm : Form
	{
		#region Properties

		public BigInteger AutomatedLargeStepValue;

		private RichTextBoxBehavior q;
		private RichTextBoxBehavior p;
		private RichTextBoxBehavior goalPos;
		private RichTextBoxBehavior goalNeg;
		private RichTextBoxBehavior product;
		private RichTextBoxBehavior productPos;
		private RichTextBoxBehavior productNeg;

		// Numbers		
		private FactorizationProgress currentProgress;

		// Misc
		private int chartTruncatePlaces;
		private BigInteger chartTruncateValue;
		private int PadLength;
		private int skipCounter;
		private bool isInitialized;
		private BigInteger maxVal = 0;
		private BigInteger lastProduct;

		// Flags
		private bool IsAutomatedRunning = false;

		// Static Readonly
		private static readonly string sampleSemiPrime = "9223372021822390277";//"456072034621752164554771693484021599673";//"243623899407479601851";
		private static readonly string ButtonTextStop = "Stop";
		private static readonly string ButtonTextSearch = "Automate search...";

		#endregion
		#region Constructor / Initializer

		public MainForm()
		{
			InitializeComponent();

			skipCounter = 0;
			isInitialized = false;
			chartTruncatePlaces = 0;
			chartTruncateValue = 0;

			numericUpDownP.Increment = 1;
			numericUpDownQ.Increment = 1;
			timerAutoStep.Interval = (int)numericTimerDelay.Value;
			timerAutoStep.Tick += new EventHandler((s, e) => AutomatedStep());
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
			btnStep1.Click += new EventHandler((s, e) => AutomatedStep());

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
			product = new RichTextBoxBehavior(rtbProduct, null);
			goalPos = new RichTextBoxBehavior(rtbDeltaGoalPositive, TextBoxBehaviors.TrendHighlighting);
			goalNeg = new RichTextBoxBehavior(rtbDeltaGoalNegative, TextBoxBehaviors.TrendHighlighting);
			productPos = new RichTextBoxBehavior(rtbDeltaProductPositive, TextBoxBehaviors.TrendHighlighting);
			productNeg = new RichTextBoxBehavior(rtbDeltaProductNegitive, TextBoxBehaviors.TrendHighlighting);

			AutomatedLargeStepValue = new BigInteger(numericStepSize.Value);

			Reset();

			InitializeChartSeries();

			rtbP.KeyDown += new KeyEventHandler(tbP_KeyDown);
			rtbP.KeyDown += new KeyEventHandler(tbPQ_KeyDown);
			rtbQ.KeyDown += new KeyEventHandler(tbPQ_KeyDown);
			rtbP.TextChanged += new EventHandler(tbPQ_TextChanged);
			rtbQ.TextChanged += new EventHandler(tbPQ_TextChanged);
			numericUpDownP.ValueChanged += new EventHandler(numericUpDownP_ValueChanged);
			numericUpDownQ.ValueChanged += new EventHandler(numericUpDownQ_ValueChanged);
		}

		private void InitializeChartSeries()
		{
			Series seriesP = new Series("Positive");
			Series seriesN = new Series("Negative");
			Series seriesR = new Series("Remainder");

			seriesP.Name = "SeriesPositive";
			seriesP.ChartArea = "ChartArea1";
			seriesP.ChartType = SeriesChartType.FastPoint;
			seriesP.MarkerColor = Color.MediumBlue;
			seriesP.MarkerSize = 2;
			seriesP.MarkerStyle = MarkerStyle.Square;
			seriesP.MarkerBorderWidth = 0;
			seriesP.BorderWidth = 0;
			seriesP.LabelBorderWidth = 0;
			seriesP.EmptyPointStyle.BorderWidth = 0;
			seriesP.EmptyPointStyle.LabelBorderWidth = 0;
			seriesP.EmptyPointStyle.MarkerBorderWidth = 0;
			seriesP.EmptyPointStyle.LabelForeColor = Color.White;
			seriesP.IsVisibleInLegend = false;
			seriesP.LabelForeColor = Color.Empty;
			seriesP.SmartLabelStyle.CalloutLineColor = Color.DarkGray;
			seriesP.XValueType = ChartValueType.UInt32;
			seriesP.YValueType = ChartValueType.UInt32;

			seriesN.Name = "SeriesNegative";
			seriesN.ChartArea = "ChartArea1";
			seriesN.ChartType = SeriesChartType.FastPoint;
			seriesN.MarkerColor = Color.DarkRed;
			seriesN.MarkerSize = 2;
			seriesN.MarkerStyle = MarkerStyle.Square;
			seriesN.MarkerBorderWidth = 0;
			seriesN.BorderWidth = 0;
			seriesN.LabelBorderWidth = 0;
			seriesN.EmptyPointStyle.BorderWidth = 0;
			seriesN.EmptyPointStyle.LabelBorderWidth = 0;
			seriesN.EmptyPointStyle.MarkerBorderWidth = 0;
			seriesN.IsVisibleInLegend = false;
			seriesN.LabelForeColor = Color.Empty;
			seriesN.SmartLabelStyle.CalloutLineColor = Color.DarkGray;
			seriesN.XValueType = ChartValueType.UInt32;
			seriesN.YValueType = ChartValueType.UInt32;

			seriesR.Name = "SeriesRemainder";
			seriesR.ChartArea = "ChartArea1";
			seriesR.ChartType = SeriesChartType.FastPoint;
			seriesR.MarkerColor = Color.DarkGreen;
			seriesR.MarkerSize = 2;
			seriesR.MarkerStyle = MarkerStyle.Square;
			seriesR.MarkerBorderWidth = 0;
			seriesR.BorderWidth = 0;
			seriesR.LabelBorderWidth = 0;
			seriesR.EmptyPointStyle.BorderWidth = 0;
			seriesR.EmptyPointStyle.LabelBorderWidth = 0;
			seriesR.EmptyPointStyle.MarkerBorderWidth = 0;
			seriesR.IsVisibleInLegend = false;
			seriesR.LabelForeColor = Color.Empty;
			seriesR.SmartLabelStyle.CalloutLineColor = Color.DarkGray;
			seriesR.XValueType = ChartValueType.UInt32;
			seriesR.YValueType = ChartValueType.UInt32;

			this.chart1.Series.Add(seriesP);
			this.chart1.Series.Add(seriesN);
			this.chart1.Series.Add(seriesR);

			//this.chart1.Series[0].XValueType = ChartValueType.UInt32;
			//this.chart1.Series[0].YValueType = ChartValueType.UInt32;
			//this.chart1.Series[1].XValueType = ChartValueType.UInt32;
			//this.chart1.Series[1].YValueType = ChartValueType.UInt32;
			//this.chart1.Series[2].XValueType = ChartValueType.UInt32;
			//this.chart1.Series[2].YValueType = ChartValueType.UInt32;

			this.chart1.ChartAreas[0].AxisX.Maximum = UInt32.MaxValue - 1;
			this.chart1.ChartAreas[0].AxisY.Maximum = UInt32.MaxValue - 1;
		}

		private void InitializeNewSemiPrime(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{ return; }

			lastProduct = 0;
			maxVal = 0;

			PadLength = Math.Min(tbSemiPrime.TextLength, 30);

			q.PaddingLength = PadLength;
			p.PaddingLength = PadLength;
			product.PaddingLength = PadLength;
			goalPos.PaddingLength = PadLength;
			goalNeg.PaddingLength = PadLength;
			productPos.PaddingLength = PadLength;
			productNeg.PaddingLength = PadLength;

			// Update semi-prime boxes
			currentProgress = new FactorizationProgress(BigInteger.Parse(Utils.GetSanitizedString(input)));

			p.CurrentValue = currentProgress.P;
			q.CurrentValue = currentProgress.Q;
			product.CurrentValue = currentProgress.Product;

			tbSemiPrime.Text = currentProgress.SemiPrime.ToString();
			tbSemiPrime0.Text = currentProgress.SemiPrime.ToString();
			rtbSemiPrime.Text = currentProgress.SemiPrime.ToString();
			tbSquareRoot.Text = currentProgress.Sqrt.ToString();

			int log10Semiprime = currentProgress.SemiPrime.ToString().Length;
			int log10Sqrt = currentProgress.Sqrt.ToString().Length;

			chartTruncatePlaces = log10Sqrt - 2;
			chartTruncateValue = BigInteger.Pow(10, chartTruncatePlaces);

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
				if (cbClearChart.Checked)
				{
					chart1.Series[0].Points.Clear();
					chart1.Series[1].Points.Clear();
					chart1.Series[2].Points.Clear();
					chart1.ResetAutoValues();
				}
				timerAutoStep.Start();
			}
		}

		private void numericStepSize_ValueChanged(object sender, EventArgs e)
		{
			AutomatedLargeStepValue = new BigInteger(numericStepSize.Value);
		}

		private void AutomatedStep()
		{
			if (product.CurrentValue > currentProgress.SemiPrime)
			{
				//numericUpDownP.DownButton();
				LargeStepDown(AutomatedLargeStepValue);
			}
			else if (currentProgress.SemiPrime > product.CurrentValue)
			{
				numericUpDownQ.UpButton();
			}
		}

		public void LargeStepDown(BigInteger toSubtract)
		{
			while (currentProgress.SemiPrime > product.CurrentValue)
			{
				numericUpDownQ.UpButton();
			}

			Tuple<BigInteger, BigInteger> addSub = CalculateToAddValue(toSubtract, p.CurrentValue);

			p.CurrentValue -= addSub.Item2;
			q.CurrentValue += addSub.Item1;
		}

		private Tuple<BigInteger, BigInteger> CalculateToAddValue(BigInteger toSubtract, BigInteger currentValueP)
		{
			BigInteger currentValueProduct = product.CurrentValue;
			BigInteger targetValueProduct = currentProgress.SemiPrime;
			BigInteger currentValueQ = q.CurrentValue;

			BigInteger newValueP = currentValueP - toSubtract;
			BigDecimal beforeQuotient = currentValueProduct / currentValueP; // targetValueProduct / currentValueP;
			BigDecimal afterQuotient = currentValueProduct / newValueP; // targetValueProduct / newValueP;
			BigInteger ToAddQs = (BigInteger)(afterQuotient - beforeQuotient) - 1;

			// --------------


			//BigInteger diffrenceBetweenTargetAndCurrentProduct = targetValueProduct - currentValueProduct;


			//BigInteger totalValueDecrease = currentValueP * toSubtract;
			//BigInteger newUnadjustedProductDifference = currentValueProduct - totalValueDecrease;
			//BigInteger differenceFromTargetProduct = targetValueProduct - newUnadjustedProductDifference;
			//BigInteger NEWnumberOfQsToAdd = differenceFromTargetProduct / currentValueQ;

			//if (ToAddQs != NEWnumberOfQsToAdd)
			//{
			//	BigInteger toAdd1 = ToAddQs;
			//	BigInteger toAdd2 = NEWnumberOfQsToAdd;

			//	BigInteger product1 = newValueP * (currentValueQ + toAdd1);
			//	BigInteger product2 = newValueP * (currentValueQ + toAdd2);

			//	BigInteger difference1 = targetValueProduct - product1;
			//	BigInteger difference2 = targetValueProduct - product2;

			//	BigInteger differenceOfDifferences = BigInteger.Max(difference1, difference2) - BigInteger.Min(difference1, difference2);

			//	bool is2Better = false;
			//	BigInteger winnerToAdd = toAdd1;
			//	BigInteger winnerDifference = difference1;
			//	if (BigInteger.Abs(difference2) < BigInteger.Abs(difference1))
			//	{
			//		is2Better = true;
			//		winnerToAdd = toAdd2;
			//		winnerDifference = difference2;
			//	}

			//	BigInteger winnerAdjustment = BigInteger.Zero;
			//	if (winnerDifference > (currentValueQ + winnerToAdd))
			//	{
			//		winnerAdjustment = winnerDifference / (currentValueQ + winnerToAdd);
			//	}

			//	string is3BetterString = is2Better.ToString();
			//	string adjustmentString = winnerAdjustment.ToString();

			//	int i = 0;
			//}
			//BigInteger n = toSubtract;
			//BigInteger rightSigma = (n * (n + 1)) / 2;
			//BigInteger toAddPlusSigma = n + rightSigma;



			BigInteger newValueQ = (currentValueQ + ToAddQs);
			BigInteger newProduct = (newValueP * newValueQ);
			BigInteger newProductDifference = targetValueProduct - newProduct;

			BigInteger pAdjustment = BigInteger.Zero;
			BigInteger qAdjustment = BigInteger.Zero;
			if (BigInteger.Abs(newProductDifference) > newValueQ)
			{
				qAdjustment = BigInteger.Abs(newProductDifference) / newValueQ;
			}
			else if (BigInteger.Abs(newProductDifference) > newValueP)
			{
				int i = 0;
				//pAdjustment = BigInteger.Abs(newProductDifference) / newValueP;
			}

			if (newProductDifference.Sign == -1)
			{
				qAdjustment = BigInteger.Negate(qAdjustment);
			}

			BigInteger toAdd = ToAddQs + qAdjustment;
			BigInteger toSub = toSubtract + pAdjustment;

			return new Tuple<BigInteger, BigInteger>(toAdd, toSub);
		}

		#endregion
		#region Numeric Up/Down Step Feature

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool ctrlp = (keyData == (Keys.Control | Keys.P));

			if (ctrlp)
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
						else if (ext == ".bmp")
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

						int saveWidth = chart1.Width;
						int saveHeight = chart1.Height;

						chart1.Visible = false;
						chart1.Width = 2100;
						chart1.Height = 1500;
						chart1.SaveImage(filename, format);
						chart1.Width = saveWidth;
						chart1.Height = saveHeight;
						chart1.Visible = true;
					}
				}
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void numericUpDownP_ValueChanged(object sender, EventArgs e)
		{
			BigInteger temp = p.CurrentValue;
			temp += (int)numericUpDownQ.Value;
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
		private void tbPQ_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Control && (e.KeyData == Keys.Up || e.KeyData == Keys.Down))
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
				else
				{
					numControl.DownButton();
				}
			}
		}

		#endregion
		#region P & Q

		// Subtracting place value from P
		private void tbP_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down && e.Control)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				p.SavedCursorPosition = rtbP.SelectionStart;

				if (rtbP.SelectionLength == 0 && rtbP.SelectionStart < rtbP.TextLength)
				{
					BigInteger toSubtract = BigInteger.Pow(10, (rtbP.TextLength - rtbP.SelectionStart));
					LargeStepDown(toSubtract);
				}
			}
		}

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
			UpdateChartAB();
			//UpdateChartC();

			if (product.CurrentValue == currentProgress.SemiPrime) // Semi-prime is factored: Solved!
			{
				OnSolved();
			}
		}

		public void HighlightMatchingCharacters(RichTextBox reference, RichTextBox toHighlight)
		{
			int matchingSelectionLength = Utils.GetMatchingLength(reference.Text, toHighlight.Text);
			string numSolvedText = matchingSelectionLength.ToString();

			Utils.HighlightRichTextBox(toHighlight, matchingSelectionLength);
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

		private static UInt32 ChartAxisMaxValue = UInt32.MaxValue - 1; //## Change Type HERE ##

		BigInteger lastDeltaGoalNeg = new BigInteger();
		BigInteger lastDeltaGoalPos = new BigInteger();
		BigInteger lastDeltaProdNeg = new BigInteger();
		BigInteger lastDeltaProdPos = new BigInteger();

		BigInteger aMax = BigInteger.Zero;
		BigInteger bMax = BigInteger.Zero;
		BigInteger xMax = BigInteger.Zero;
		BigInteger yMax = BigInteger.Zero;

		bool isIncreasing = false;

		private void CalculateDeltas()
		{
			BigInteger goalDelta = 0;
			BigInteger productDelta = 0;

			if (product.CurrentValue > currentProgress.SemiPrime)
			{
				goalDelta = product.CurrentValue - currentProgress.SemiPrime;
				goalNeg.CurrentValue = goalDelta;

				BigInteger diff = 0;
				if (goalDelta > lastDeltaGoalNeg)
				{
					diff = goalDelta - lastDeltaGoalNeg;
					isIncreasing = true;
				}
				else
				{
					diff = lastDeltaGoalNeg - goalDelta;
					isIncreasing = false;
				}

				tbList1.AppendText((isIncreasing ? "+" : "-") + diff.ToString() + Environment.NewLine);

				lastDeltaGoalNeg = goalDelta;
			}
			else
			{
				goalDelta = currentProgress.SemiPrime - product.CurrentValue;
				goalPos.CurrentValue = goalDelta;

				BigInteger diff = 0;
				if (goalDelta > lastDeltaGoalPos)
				{
					diff = goalDelta - lastDeltaGoalPos;
					isIncreasing = true;
				}
				else
				{
					diff = lastDeltaGoalPos - goalDelta;
					isIncreasing = false;
				}

				tbList2.AppendText((isIncreasing ? "+" : "-") + diff.ToString() + Environment.NewLine);

				lastDeltaGoalPos = goalDelta;
			}

			if (lastProduct > product.CurrentValue)
			{
				productDelta = lastProduct - product.CurrentValue;
				productNeg.CurrentValue = productDelta;

				BigInteger diff = 0;
				if (productDelta > lastDeltaProdNeg)
				{
					diff = productDelta - lastDeltaProdNeg;
					isIncreasing = true;
				}
				else
				{
					diff = lastDeltaProdNeg - productDelta;
					isIncreasing = false;
				}

				tbList3.AppendText((isIncreasing ? "+" : "-") + diff.ToString() + Environment.NewLine);

				lastDeltaProdNeg = productDelta;
			}
			else
			{
				productDelta = product.CurrentValue - lastProduct;

				productPos.CurrentValue = productDelta;

				BigInteger diff = 0;
				if (productDelta > lastDeltaProdPos)
				{
					diff = productDelta - lastDeltaProdPos;
					isIncreasing = true;
				}
				else
				{
					diff = lastDeltaProdPos - productDelta;
					isIncreasing = false;
				}

				tbList4.AppendText((isIncreasing ? "+" : "-") + diff.ToString() + Environment.NewLine);

				lastDeltaProdPos = productDelta;
			}
		}

		private void UpdateChartAB()
		{
			if (!isInitialized)
			{
				if (skipCounter++ > 10)
				{
					chart1.Series[0].XValueType = ChartValueType.UInt32; //## HERE, ##
					chart1.Series[0].YValueType = ChartValueType.UInt32;
					chart1.Series[1].XValueType = ChartValueType.UInt32;
					chart1.Series[1].YValueType = ChartValueType.UInt32;
					chart1.Series[2].XValueType = ChartValueType.UInt32;
					chart1.Series[2].YValueType = ChartValueType.UInt32;
					isInitialized = true;
				}
				return;
			}

			BigInteger gpVal = goalPos.CurrentValue;
			BigInteger ppVal = productPos.CurrentValue;
			BigInteger gnVal = goalNeg.CurrentValue;
			BigInteger pnVal = productNeg.CurrentValue;
						
			BigInteger A = gpVal;
			BigInteger B = ppVal;
			BigInteger X = gnVal;
			BigInteger Y = pnVal;
			
			if (A > aMax) { aMax = A; }
			if (B > bMax) { bMax = B; }
			if (X > xMax) { xMax = X; }
			if (Y > yMax) { yMax = Y; }

			//if (maxVal == 0) {
			//	maxVal = Sqrt * 2;
			//	while (maxVal + 1 > UInt32.MaxValue)
			//	{	maxVal = maxVal.Sqrt() * 2; }
			//}

			//gpVal = BigInteger.Max(0, gpVal - chartTruncateValue);
			//ppVal = BigInteger.Max(0, ppVal - chartTruncateValue);
			//gnVal = BigInteger.Max(0, gnVal - chartTruncateValue);
			//pnVal = BigInteger.Max(0, pnVal - chartTruncateValue);

			//if (gpVal > ChartAxisMaxValue
			// || ppVal > ChartAxisMaxValue
			// || gnVal > ChartAxisMaxValue
			// || pnVal > ChartAxisMaxValue  )
			//{
			//				//	throw new OverflowException($"Natural log overflowed {typeof(UInt32)}!? Wasn't expecting that...");
			//	//chartTruncateValue *= 10;
			//}



			//var a = (UInt32)BigInteger.Log(goalPos.CurrentValue);
			//var b = (UInt32)BigInteger.Log(productPos.CurrentValue);
			//var x = (UInt32)BigInteger.Log(goalNeg.CurrentValue);
			//var y = (UInt32)BigInteger.Log(productNeg.CurrentValue);

			//if (double.IsInfinity(a) || double.IsNaN(a)) { a = 0; }
			//if (double.IsInfinity(b) || double.IsNaN(b)) { b = 0; }
			//if (double.IsInfinity(x) || double.IsNaN(x)) { x = 0; }
			//if (double.IsInfinity(y) || double.IsNaN(y)) { y = 0; }

			if (A > ChartAxisMaxValue)
			{
				A = (A / ChartAxisMaxValue) + 1;
			}
			if (B > ChartAxisMaxValue)
			{
				B = (B / ChartAxisMaxValue) + 1;
			}
			if (X > ChartAxisMaxValue)
			{
				X = (X / ChartAxisMaxValue) + 1;
			}
			if (Y > ChartAxisMaxValue)
			{
				Y = (Y / ChartAxisMaxValue) + 1;
			}

			var a = (UInt32)A;
			var b = (UInt32)B;
			var x = (UInt32)X;
			var y = (UInt32)Y;

			Complex aComplex = new Complex((double)A, 0);
			double mag = aComplex.Magnitude;
			double phase = aComplex.Phase;

			//if (a == 0 || b == 0 || x == 0 || y == 0)
			//{
			//	return;
			//}
			//if (a - b == 0 || x - y == 0 || b - a == 0 || y - x == 0)
			//{
			//	return;
			//}

			//var a1 = Math.Sin(1) * a;   // BLUE
			//var b1 = Math.Sin(1) * b;   // BLUE
			//var x1 = Math.Sin(1) * x;   // RED
			//var y1 = Math.Cos(1) * y;   // RED

			if (chart1.Series[0].Points.Count > 10000)
			{
				int counter0 = 0;
				while (counter0 < 5000)
				{
					chart1.Series[0].Points.RemoveAt(counter0);
					counter0++;
				}
			}

			if (chart1.Series[1].Points.Count > 10000)
			{
				int counter1 = 0;
				while (counter1 < 5000)
				{
					chart1.Series[1].Points.RemoveAt(counter1);
					counter1++;
				}
			}

			if (a > 1 && b > 1 && Math.Max(a, b) - Math.Min(a, b) > 1)
			{
				chart1.Series[0].Points.AddXY(a, b);
			}
			if (x > 1 && y > 1 && Math.Max(x, y) - Math.Min(x, y) > 1)
			{
				chart1.Series[1].Points.AddXY(x, y);
			}



		}

		private UInt32 counterC = 0;

		private void UpdateChartC()
		{
			if (!isInitialized)
			{
				isInitialized = true;
				return;
			}

			BigInteger remainder = new BigInteger();
			BigInteger.DivRem(currentProgress.SemiPrime, p.CurrentValue, out remainder);

			var x = (UInt32)remainder;
			var y = counterC;

			//if (double.IsInfinity(x) || double.IsNaN(x)) { x = 0; }
			//if (double.IsInfinity(y) || double.IsNaN(y)) { y = 0; }

			if (x > ChartAxisMaxValue)
			{
				x = x % ChartAxisMaxValue;
			}
			if (y > ChartAxisMaxValue)
			{
				y = y % ChartAxisMaxValue;
			}

			if (chart1.Series[2].Points.Count > 10000)
			{
				int counter2 = 0;
				while (counter2 < 5000)
				{
					chart1.Series[2].Points.RemoveAt(counter2);
					counter2++;
				}
			}

			if (x > 1 && y > 1 && x - y > 1 && y - x > 1)
			{
				chart1.Series[2].Points.AddXY(x, y);
			}
			counterC += (UInt32)AutomatedLargeStepValue;
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
			SaveProgress.Save(filename, currentProgress);
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			string filename = Utils.FileDialog<OpenFileDialog>("XML Files(*.xml) | *.xml");
			if (string.IsNullOrWhiteSpace(filename))
			{
				return;
			}
			currentProgress = SaveProgress.Open(filename);
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

		#endregion
		#region Buffered TextBox

		private int textBoxBufferSize = 4096;
		private StringBuilder textBoxBuffer = new StringBuilder();
		private void FlushBuffer()
		{
			if (tbOutput.InvokeRequired)
			{
				tbOutput.Invoke(new MethodInvoker(() => FlushBuffer()));
			}
			else
			{
				tbOutput.AppendText(textBoxBuffer.ToString());
				textBoxBuffer.Clear();
			}
		}

		private void WriteBufferedOutput(string output)
		{
			textBoxBuffer.AppendLine(output);
			if (textBoxBuffer.Length > textBoxBufferSize)
			{
				FlushBuffer();
			}
		}

		#endregion
		#region Position Tooltip

		private void chart1_MouseClick(object sender, MouseEventArgs e)
		{
			Point position = e.Location;
			clickPosition = position;
			HitTestResult[] hitTest = chart1.HitTest(position.X, position.Y, false, ChartElementType.DataPoint);

			if (hitTest == null || hitTest.Length < 1)
			{
				return;
			}

			CreateTooltip(hitTest, position);
		}

		private void chart1_MouseMove(object sender, MouseEventArgs e)
		{
			if (clickPosition.HasValue)
			{
				if (e.Location.X > (clickPosition.Value.X + moveBuffer)
					|| e.Location.X < (clickPosition.Value.X - moveBuffer)
					|| e.Location.Y > (clickPosition.Value.Y + moveBuffer)
					|| e.Location.Y < (clickPosition.Value.Y - moveBuffer)
					)
				{
					tooltip.RemoveAll();
					clickPosition = null;
				}
			}
		}

		#endregion

		private void btnDisplayMax_Click(object sender, EventArgs e)
		{
			tbOutput.Clear();
			tbOutput.AppendText($"A: {aMax}{Environment.NewLine}");
			tbOutput.AppendText($"B: {bMax}{Environment.NewLine}");
			tbOutput.AppendText(Environment.NewLine);
			tbOutput.AppendText($"X: {xMax}{Environment.NewLine}");
			tbOutput.AppendText($"Y: {yMax}{Environment.NewLine}");
			tbOutput.AppendText(Environment.NewLine);
			tbOutput.AppendText(Environment.NewLine);
		}
	}
}
