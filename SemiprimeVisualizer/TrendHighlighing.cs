using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;
using System.Drawing;

namespace SemiprimeVisualizer
{
	public class TrendHighlighing : IDisposable
	{
		private RichTextBox richTextBox;

		private BigInteger lastValue;
		private BigInteger currentValue { get { return BigInteger.Parse(richTextBox.Text); } }
		
		public TrendHighlighing(RichTextBox textBox)
		{
			lastValue = 0;
			richTextBox = textBox;
			richTextBox.TextChanged += textBox_TextChanged;
		}

		// Not unregistering events will make the object ineligible for GC
		// as the control still holds a reference to it.
		// Not really a concern in this case, as it lives for the lifetime of the application anyhow
		// Still, this is a good habit of getting into.
		public void Dispose()
		{
			richTextBox.TextChanged -= textBox_TextChanged;
			richTextBox = null;
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			BigInteger currValue = currentValue;
			if (lastValue != 0 && lastValue != currentValue)
			{
				Color trendColor;
				if (currentValue > lastValue)
				{
					trendColor = Utils.AscendingColor;// Rising
				}
				else
				{
					trendColor = Utils.DecendingColor;// Falling
				}


				if (richTextBox.BackColor != trendColor)
				{
					richTextBox.BackColor = trendColor;
				}
			}

			lastValue = currValue;
		}
	}
}
