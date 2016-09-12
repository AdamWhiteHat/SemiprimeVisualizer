using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SemiprimeVisualizer
{
	public class Utils
	{
		public static readonly string Numbers = "0123456789";

		#region Colors
		public static readonly Color GreenColor = Color.LightGreen;
		public static readonly Color RedColor = Color.FromArgb(255, 192, 192);

		public static readonly Color MatchingColor = GreenColor;
		public static readonly Color MisMatchingColor = RedColor;

		public static readonly Color AscendingColor = GreenColor;
		public static readonly Color DecendingColor = RedColor;

		public static readonly Color GreaterThanColor = GreenColor;
		public static readonly Color LessThanColor = RedColor;
		#endregion

		#region Methods
		public static void HighlightRichTextBox(RichTextBox source, int length)
		{
			// Save settings to restore after done
			string savedText = source.Text;
			int savedSourceSelectionStart = source.SelectionStart;
			int savedSourceSelectionLength = source.SelectionLength;
			if (savedSourceSelectionStart < 0) savedSourceSelectionStart = 0;
			if (savedSourceSelectionLength < 0) savedSourceSelectionLength = 0;

			source.SuspendLayout();
			source.ResetText();
			source.Text = savedText;

			// Set matching color			
			source.Select(0, length);
			source.SelectionBackColor = MatchingColor;
			source.DeselectAll();
			source.ResumeLayout();

			// Restore saved selection
			source.Select(savedSourceSelectionStart, savedSourceSelectionLength);
		}

		public static int GetMatchingLength(string source, string copy)
		{
			if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(copy)) { return 0; }
			if (source == copy) { return source.Length; }

			int counter = 0;
			while (counter < source.Length
					&& counter < copy.Length
					&& source[counter] == copy[counter])
			{
				counter++;
			}

			return counter;
		}

		public static string GetSanitizedString(string input)
		{
			return string.IsNullOrEmpty(input) ? ""
				: new string(input.TrimStart(new char[] { '0' }).Where(c => Numbers.Contains(c)).ToArray()).Trim().Replace(",", "");
		}

		public static string TruncateString(string number, int length)
		{
			if (number.Length > length)
			{
				number = number.Substring(0, length);
			}
			return number;
		}
		#endregion

		#region Numeric Up/Down Step Feature

		public static void IncrementNumber(RichTextBox ctrl, decimal value)
		{
			if (value != 0)
			{
				string p = ctrl.Text;
				int cursor = ctrl.SelectionStart;
				if (cursor != 0)
				{
					string leftOfCaret = p.Substring(0, cursor);
					//if (!leftOfCaret.All(c => c == '9') || value < 0) {
					BigInteger pTemp = BigInteger.Parse(leftOfCaret);
					pTemp += (int)value;

					string newNumber = string.Concat(pTemp.ToString(), p.Substring(cursor));

					int savedSelectionStart = ctrl.SelectionStart;
					int savedSelectionLength = ctrl.SelectionLength;
					ctrl.Text = newNumber;
					ctrl.SelectionStart = savedSelectionStart;
					ctrl.SelectionLength = savedSelectionLength;
				}
				//UpdateControls();
			}
		}

		#endregion

		#region Open/Save State

		public static string FileDialog<TFileDialog>() where TFileDialog : FileDialog, new()
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

		#endregion
	}
}
