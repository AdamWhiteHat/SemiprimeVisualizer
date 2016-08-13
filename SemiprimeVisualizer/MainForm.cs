using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Numerics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XmlConfiguration;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;
using System.Xml.Serialization.Configuration;
using System.IO;

namespace SemiprimeVisualizer
{
	public partial class MainForm : Form
	{
		private BigInteger SemiPrime;
		private BigDecimal Sqrt;
		private BigInteger P;
		private BigInteger Q;
		private BigInteger Product;

		private bool SuppressMatchHighlighting;

		private static BigDecimal OneHalf = 0.5f;

		public MainForm()
		{
			InitializeComponent();
			btnStep.Click += new EventHandler((s, e) => Step());
			timerAutoStep.Tick += new EventHandler((s, e) => Step());
			tbP.KeyDown += new KeyEventHandler((s, e) => ShouldSuppressMatchHighlighting(e));
			tbQ.KeyDown += new KeyEventHandler((s, e) => ShouldSuppressMatchHighlighting(e));

			tbSemiPrime.KeyDown += new KeyEventHandler((s, e) =>
			{
				if (e.KeyData == Keys.Enter) e.SuppressKeyPress = true;
			});
			tbSemiPrime.KeyUp += new KeyEventHandler((s, e) =>
			{
				if (e.KeyData == Keys.Enter) UpdateSemiPrime(tbSemiPrime.Text.Trim());
			});

			tbSemiPrime.Text = "57067243796841643470552710996456276113098761718504945554141189162814127223969";
			tbSquareRoot.Text = "238887512852475492197009959649799290286";

			UpdateSemiPrime(tbSemiPrime.Text.Trim());
		}

		private void UpdateSemiPrime(string input)
		{
			if (string.IsNullOrWhiteSpace(input)) { return; }
			SemiPrime = BigInteger.Parse(input);

			// Update semi-prime boxes
			tbSemiPrime0.Text = SemiPrime.ToString();
			tbSemiPrime1.Text = SemiPrime.ToString();

			//sqrt = BigDecimal.Pow(semiPrime, OneHalf);
			Sqrt = BigInteger.Parse(tbSquareRoot.Text);
			P = (BigInteger)BigDecimal.Ceiling(Sqrt);
			Q = (BigInteger)BigDecimal.Floor(Sqrt);

			UpdateControls();
		}

		bool isAutomated = false;
		string buttonTextSearch = "Automate search...";
		string buttonTextStop = "Stop";
		private void btnAutomate_Click(object sender, EventArgs e)
		{
			AutomationToggle();
		}

		private void AutomationToggle()
		{
			if (isAutomated)
			{
				isAutomated = false;
				btnAutomateSearch.Text = buttonTextSearch;
				timerAutoStep.Stop();
			}
			else
			{
				if (string.IsNullOrWhiteSpace(tbProduct.Text)) { return; }
				btnAutomateSearch.Text = buttonTextStop;
				timerAutoStep.Start();
				isAutomated = true;
			}
		}

		private void Step()
		{
			if (Product > SemiPrime)
			{
				numericUpDownP.DownButton();
			}
			else if (SemiPrime > Product)
			{
				numericUpDownQ.UpButton();
			}
		}

		private void ShouldSuppressMatchHighlighting(KeyEventArgs e)
		{
			bool isHighlighting = (e.Shift &&
									 e.KeyData != Keys.Left &&
									 e.KeyData != Keys.Right);

			bool isDeleting = (e.KeyData == Keys.Back ||
								e.KeyData == Keys.Delete);


			SuppressMatchHighlighting = (isHighlighting || isDeleting);
		}

		private void tbP_KeyUp(object sender, KeyEventArgs e)
		{
			// Simulate numeric control UP/DOWN
			if (e.KeyCode == Keys.Up)
			{
				numericUpDownP.UpButton();
				return;
			}
			else if (e.KeyData == Keys.Down)
			{
				numericUpDownP.DownButton();
				return;
			}

			ShouldSuppressMatchHighlighting(e);
		}

		private void tbQ_KeyUp(object sender, KeyEventArgs e)
		{
			// Simulate numeric control UP/DOWN
			if (e.KeyData == Keys.Up)
			{
				numericUpDownQ.UpButton();
				return;
			}
			else if (e.KeyData == Keys.Down)
			{
				numericUpDownQ.DownButton();
				return;
			}

			ShouldSuppressMatchHighlighting(e);
		}

		private void numericUpDownP_ValueChanged(object sender, EventArgs e)
		{
			P = P + (int)numericUpDownP.Value;
			numericUpDownP.Value = 0;
			UpdateControls();
		}

		private void numericUpDownQ_ValueChanged(object sender, EventArgs e)
		{
			Q = Q + (int)numericUpDownQ.Value;
			numericUpDownQ.Value = 0;
			UpdateControls();
		}

		private void tbP_TextChanged(object sender, EventArgs e)
		{
			P = BigInteger.Parse(tbP.Text);
			UpdateControls();
		}

		private void tbQ_TextChanged(object sender, EventArgs e)
		{
			Q = BigInteger.Parse(tbQ.Text);
			UpdateControls();
		}

		private void UpdateControls()
		{
			// Finish calculations
			Product = BigInteger.Multiply(P, Q);

			// Update other boxes
			tbP.Text = P.ToString();
			tbQ.Text = Q.ToString();
			tbProduct.Text = Product.ToString();


			if (Product > SemiPrime)
			{
				tbProduct.BackColor = Color.FromArgb(255, 192, 192); //Color.MistyRose;
			}
			else if (Product < SemiPrime)
			{
				tbProduct.BackColor = Color.FromKnownColor(KnownColor.Control);
			}
			else if (Product == SemiPrime)
			{
				if (timerAutoStep.Enabled)
				{
					AutomationToggle();
				}
				tbP.Enabled = false;
				tbQ.Enabled = false;
				tbProduct.Enabled = false;
				tbSemiPrime0.Enabled = false;
				btnAutomateSearch.Enabled = false;
				tbP.BackColor = Color.MintCream;
				tbQ.BackColor = Color.MintCream;
				tbProduct.BackColor = Color.MintCream;
				tbSemiPrime0.BackColor = Color.MintCream;
				MessageBox.Show("Product is equal to Semi-Prime!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			if (SuppressMatchHighlighting)
			{
				SuppressMatchHighlighting = false;
			}
			else
			{
				HighlightMatching(tbP, tbQ);
			}

			HighlightMatching(tbSemiPrime1, tbProduct);
			DecimalExpansion();
		}

		private void DecimalExpansion()
		{
			BigDecimal prime = new BigDecimal(SemiPrime);
			BigDecimal p = new BigDecimal(P);
			BigDecimal q = new BigDecimal(Q);

			BigDecimal quotientP = prime / p;
			BigDecimal quotientQ = prime / q;

			string stringP = quotientP.ToString().Substring(0, 600);
			string stringQ = quotientQ.ToString().Substring(0, 600);

			tbOutput.Clear();
			tbOutput.AppendText(string.Format("Semi-prime / P = {0}", Environment.NewLine));
			tbOutput.AppendText(stringP);
			tbOutput.AppendText(Environment.NewLine + Environment.NewLine);
			tbOutput.AppendText(string.Format("Semi-prime / Q = {0}", Environment.NewLine));
			tbOutput.AppendText(stringQ);
			//tbOutput.AppendText(Environment.NewLine);
		}

		private static void HighlightMatching(TextBox source, TextBox copy)
		{
			int selectionLength = GetMatchingLength(source.Text, copy.Text);

			if (source.SelectionStart != 0) { source.SelectionStart = 0; }
			if (copy.SelectionStart != 0) { copy.SelectionStart = 0; }

			if (source.SelectionLength != selectionLength) { source.SelectionLength = selectionLength; }
			if (copy.SelectionLength != selectionLength) { copy.SelectionLength = selectionLength; }
		}

		private static void HighlightMatching(RichTextBox source, RichTextBox copy)
		{
			int selectionLength = GetMatchingLength(source.Text, copy.Text);

			if (source.SelectionStart != 0) { source.SelectionStart = 0; }
			if (copy.SelectionStart != 0) { copy.SelectionStart = 0; }

			if (source.SelectionLength != selectionLength) { source.SelectionLength = selectionLength; }
			if (copy.SelectionLength != selectionLength) { copy.SelectionLength = selectionLength; }
		}

		private static int GetMatchingLength(string source, string copy)
		{
			if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(copy)) { return 0; }
			if (source == copy) { return source.Length; }

			int counter = 0;
			while (counter <= source.Length
					&& counter <= copy.Length
					&& source[counter] == copy[counter])
			{
				counter++;
			}
			return counter;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string filename = FileDialog<SaveFileDialog>();


			XDocument xdoc = new XDocument(
								new XElement("Root",
									new XElement("SemiPrime", SemiPrime.ToString()),
									new XElement("Sqrt", Sqrt.ToString()),
									new XElement("P", P.ToString()),
									new XElement("Q", Q.ToString()),
									new XElement("Product", Product.ToString()),
									new XElement("Residues", tbOutput.Text)
								)
							);

			xdoc.Save(filename);

		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			string filename = FileDialog<SaveFileDialog>();

			XDocument xdoc = XDocument.Load(filename);

			IEnumerable<XElement> elements = xdoc.Root.Descendants();

			string semiprime = elements.Where(n => n.Name == "SemiPrime").Single().Value;
			string sqrt = elements.Where(n => n.Name == "Sqrt").Single().Value;

			string p = elements.Where(n => n.Name == "P").Single().Value;
			string q = elements.Where(n => n.Name == "Q").Single().Value;

			string product = elements.Where(n => n.Name == "Product").Single().Value;
			string residues = elements.Where(n => n.Name == "Residues").Single().Value;

			BigInteger.TryParse(semiprime, out SemiPrime);
			BigInteger sqr = 0;
			BigInteger.TryParse(sqrt, out sqr);
			Sqrt = sqr;

			BigInteger.TryParse(p, out P);
			BigInteger.TryParse(q, out Q);

			BigInteger.TryParse(product, out Product);
			tbOutput.Text = residues;
		}

		private string FileDialog<TFileDialog>() where TFileDialog : FileDialog, new()
		{
			string result = string.Empty;
			using (FileDialog openFile = new TFileDialog())
			{
				openFile.DefaultExt = ".xml";
				openFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				if (openFile.ShowDialog() == DialogResult.OK)
				{
					result = openFile.FileName;
				}
			}
			return result;
		}


	}
}
