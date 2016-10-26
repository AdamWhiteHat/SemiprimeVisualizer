using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing.Imaging;

namespace SemiprimeVisualizer
{
    public enum StepDirection
    {
        Up,
        Down
    }

    public partial class MainForm : Form
    {
        #region Properties

        public BigInteger AutomatedLargeStepValue;

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

            SemiPrime = 0;
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

            seriesP.Name = "SeriesP";
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
            seriesP.XValueType = ChartValueType.Single;
            seriesP.YValueType = ChartValueType.Single;

            seriesN.Name = "SeriesN";
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
            seriesN.XValueType = ChartValueType.Single;
            seriesN.YValueType = ChartValueType.Single;

            this.chart1.Series.Add(seriesP);
            this.chart1.Series.Add(seriesN);
        }

        private void InitializeNewSemiPrime(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            { return; }

            lastProduct = 0;
            SemiPrime = 0;
            maxVal = 0;
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
            if (product.CurrentValue > SemiPrime)
            {
                //numericUpDownP.DownButton();
                LargeStepDown(AutomatedLargeStepValue);
            }
            else if (SemiPrime > product.CurrentValue)
            {
                numericUpDownQ.UpButton();
            }
        }

        public void LargeStepDown(BigInteger toSubtract)
        {
            while (SemiPrime > product.CurrentValue)
            {
                numericUpDownQ.UpButton();
            }

            BigInteger toAdd = CalculateToAddValue(toSubtract, p.CurrentValue);
            p.CurrentValue -= toSubtract;
            q.CurrentValue += toAdd;
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

        private BigInteger CalculateToAddValue(BigInteger toSubtract, BigInteger currentValue)
        {
            BigInteger pDifference = currentValue - toSubtract;
            BigDecimal qValue = SemiPrime / currentValue;
            BigDecimal qDifference = SemiPrime / pDifference;

            BigInteger toAdd = (BigInteger)(qDifference - qValue) - 1;
            return toAdd;
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
            UpdateChart();

            if (product.CurrentValue == SemiPrime) // Semi-prime is factored: Solved!
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

        private void UpdateChart()
        {
            if (!isInitialized)
            {
                if (skipCounter++ > 10)
                {
                    chart1.Series[0].XValueType = ChartValueType.Double; //## HERE, ##
                    chart1.Series[1].XValueType = ChartValueType.Double;
                    isInitialized = true;
                }
                return;
            }

            BigInteger gpVal = goalPos.CurrentValue;
            BigInteger ppVal = productPos.CurrentValue;
            BigInteger gnVal = goalNeg.CurrentValue;
            BigInteger pnVal = productNeg.CurrentValue;

            //if (maxVal == 0) {
            //	maxVal = Sqrt * 2;
            //	while (maxVal + 1 > UInt32.MaxValue)
            //	{	maxVal = maxVal.Sqrt() * 2; }
            //}

            if (gpVal > ChartAxisMaxValue) gpVal = gpVal % ChartAxisMaxValue;
            if (ppVal > ChartAxisMaxValue) ppVal = ppVal % ChartAxisMaxValue;
            if (gnVal > ChartAxisMaxValue) gnVal = gnVal % ChartAxisMaxValue;
            if (pnVal > ChartAxisMaxValue) pnVal = pnVal % ChartAxisMaxValue;

            var a = (UInt32)gpVal; // ## AND HERE ##
            var b = (UInt32)ppVal;
            var x = (UInt32)gnVal;
            var y = (UInt32)pnVal;

            if (a == 0 || b == 0 || x == 0 || y == 0)
            {
                return;
            }
            if (a - b == 0 || x - y == 0 || b - a == 0 || y - x == 0)
            {
                return;
            }

            //var a1 = Math.Sin(1) * a;   // BLUE
            //var b1 = Math.Sin(1) * b;   // BLUE
            //var x1 = Math.Sin(1) * x;   // RED
            //var y1 = Math.Cos(1) * y;   // RED

            if (chart1.Series[0].Points.Count > 10000)
            {
                int counter = 0;
                while (counter < 5000)
                {
                    chart1.Series[0].Points.RemoveAt(counter);
                    chart1.Series[1].Points.RemoveAt(counter);
                    counter++;
                }
            }

            chart1.Series[0].Points.AddXY(a, b);
            chart1.Series[1].Points.AddXY(x, y);
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
        #region QuadraticResidue

        private void btnQuadraticResidue_Click(object sender, EventArgs e)
        {
            //timerQuadraticSearch.Start();
        }

        private void timerQuadraticSearch_Tick(object sender, EventArgs e)
        {
            timerQuadraticSearch.Stop();

            //int[] coefficients = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            //SmoothNumbers smoothNumbers = new SmoothNumbers(coefficients, 16);
            //IEnumerable<BigInteger> smoothEnumerable = smoothNumbers.GetCalculatedValues();
            //IEnumerable<BigInteger> bigEnoughEnumerable = smoothEnumerable.Where(n => n > Sqrt);

            //int counter = 0;
            //foreach (BigInteger number in bigEnoughEnumerable)
            //{
            //	WriteBufferedOutput(number.ToString() + "\t\t= " + smoothNumbers.ToString());

            //	if (counter++ > 100)
            //	{
            //		FlushBuffer();
            //		break;
            //	}
            //}

            //IEnumerable<BigInteger> differenceOfSquares = bigEnoughEnumerable.Where(n => (n.Square() - SemiPrime).IsSquare());

            //counter = 0;
            //WriteBufferedOutput(" ");			
            //WriteBufferedOutput("----------------------------");
            //WriteBufferedOutput("RESULTS:");

            //int numberToTake = 1;
            //WriteBufferedOutput(string.Join(Environment.NewLine, differenceOfSquares.Take(numberToTake).Select(bi => bi.ToString())));
            //FlushBuffer();

            //foreach (BigInteger result in differenceOfSquares) {
            //  WriteBufferedOutput(result.ToString());
            //	if (counter++ > 10000) { FlushBuffer(); break; } }
            //
            //QuadraticSearch sieve = new QuadraticSearch(SemiPrime, WriteBufferedOutput);
            //sieve.StartSearch();

            QuadraticSieve sieve = new QuadraticSieve(SemiPrime);
            IEnumerable<BigInteger> smooths = sieve.GetDifferenceOfSquares();

            WriteBufferedOutput(string.Join(Environment.NewLine, smooths.Take(5000)));
            FlushBuffer();
        }

        #endregion

        #region Position Tooltip

        private double? clickX = null;
        private double? clickY = null;

        private ToolTip tooltip = new ToolTip();
        private Point? clickPosition = null;
        private static int moveBuffer = 7;
        private static int leftPaddingTotal = 18;
        private static int rightPaddingTotal = 25;
        private static string formatString = "#,###,###,##0.###";

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            clickPosition = pos;
            HitTestResult[] hits = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            if (hits == null || hits.Length < 1)
            {
                return;
            }

            HitTestResult hit = hits[0];

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                double xVal = hit.ChartArea.AxisX.PixelPositionToValue(pos.X);
                double yVal = hit.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                string locationString = $"X={PadString(xVal.ToString(formatString))}";

                locationString = locationString.PadRight(rightPaddingTotal, ' ');
                locationString += $"  Y={PadString(yVal.ToString(formatString))}";

                tooltip.Show(locationString, this.chart1, e.Location.X, e.Location.Y - 15);
                tbOutput.AppendText(locationString + Environment.NewLine);

                if (!clickX.HasValue && !clickY.HasValue)
                {
                    clickX = xVal;
                    clickY = yVal;
                }
                else if (clickX.HasValue && clickY.HasValue)
                {
                    string diffXString = FormatDifference(clickX.Value, xVal);
                    string diffYString = FormatDifference(clickY.Value, yVal);

                    string differenceString = $"X={diffXString}";
                    differenceString = differenceString.PadRight(rightPaddingTotal, ' ');
                    differenceString += $"  Y={diffYString}";

                    tbOutput.AppendText("-------------------------------------------------------------" + Environment.NewLine);
                    tbOutput.AppendText(differenceString + Environment.NewLine);
                    tbOutput.AppendText(Environment.NewLine);

                    clickX = null;
                    clickY = null;
                }
            }
        }

        private string PadString(string input)
        {
            string result = input;

            if (input.Contains('.'))
            {
                int paddingDiff = leftPaddingTotal - input.IndexOf('.');
                if (paddingDiff > 0)
                {
                    result = result.Insert(0, new string(Enumerable.Repeat(' ', paddingDiff).ToArray()));
                }
            }

            return result;//result.PadLeft(leftPaddingTotal, ' ');
        }

        private string FormatDifference(double firstValue, double secondValue)
        {
            bool negative = false;
            double diffValue;

            if (secondValue > firstValue)
            {
                diffValue = secondValue - firstValue;
            }
            else
            {
                diffValue = firstValue - secondValue;
                negative = true;
            }

            string result = $"{(negative ? "-" : "+")} {diffValue.ToString(formatString)}".PadLeft(18, ' ');
                       
            return PadString(result);
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

    }
}
