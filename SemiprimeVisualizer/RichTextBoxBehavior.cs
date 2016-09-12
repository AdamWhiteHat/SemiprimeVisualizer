using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SemiprimeVisualizer
{
	public delegate void RichTextBoxUpdateHander(RichTextBoxBehavior richTextBox);

	public class RichTextBoxBehavior : IDisposable
	{
		public int SavedCursorPosition;
		public int PaddingLength { get { return _paddingLength; } set { _paddingLength = value > 15 ? 0 : value; } }
		private int _paddingLength = 0;
		public RichTextBox InnerTextBox { get; private set; }
		public RichTextBoxUpdateHander OnUpdateBehaviorMethod { get; set; }
		public BigInteger LastValue { get; protected set; }
		public BigInteger CurrentValue
		{
			get
			{
				string textValue = InnerTextBox.Text;
				if (string.IsNullOrWhiteSpace(InnerTextBox.Text)) { return BigInteger.Zero; }
				string sanitized = GetSanitizedString(textValue);
				return BigInteger.Parse(sanitized);
			}
			set
			{
				if (CurrentValue != value)
				{
					InnerTextBox.Text = value.ToString().PadLeft(PaddingLength);
				}
			}
		}

		public RichTextBoxBehavior(RichTextBox textBox, RichTextBoxUpdateHander onUpdateHandler)
		{
			if (textBox == null) throw new ArgumentNullException();
			LastValue = 0;
			InnerTextBox = textBox;
			OnUpdateBehaviorMethod = onUpdateHandler;
			InnerTextBox.TextChanged += textBox_TextChanged;
		}

		private static readonly string Numbers = "0123456789";
		private static string GetSanitizedString(string input)
		{
			if (!string.IsNullOrWhiteSpace(input))
			{
				string result = input.Trim();
				result = result.TrimStart(new char[] { '0' });
				if (!string.IsNullOrWhiteSpace(result))
				{
					result = new string(result.Where(c => Numbers.Contains(c)).ToArray());
					return result;
				}
			}
			return "0";
		}

		// Not unregistering events will make the object ineligible for GC
		// as the control still holds a reference to it.
		// Not really a concern in this case, as it lives for the lifetime of the application anyhow
		// Still, this is a good habit of getting into.
		public void Dispose()
		{
			InnerTextBox.TextChanged -= textBox_TextChanged;
			InnerTextBox = null;
			OnUpdateBehaviorMethod = null;
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			if (OnUpdateBehaviorMethod != null)
			{
				OnUpdateBehaviorMethod.Invoke(this);
			}

			//int textLength = InnerTextBox.TextLength;
			//if (textLength < 30 && textLength > PaddingLength)
			//{
			//	PaddingLength = textLength;
			//}

			LastValue = CurrentValue;
		}

	}
}
