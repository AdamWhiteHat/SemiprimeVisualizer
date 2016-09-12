using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SemiprimeVisualizer
{
	public static class TextBoxBehaviors
	{
		public static void RestoreCursorPosition(RichTextBoxBehavior textBox)
		{
			if (textBox.SavedCursorPosition != 0)
			{
				int curPos = textBox.SavedCursorPosition;
				textBox.SavedCursorPosition = 0;

				textBox.InnerTextBox.Focus();
				textBox.InnerTextBox.Select(curPos, 0);				
			}
		}

		public static void TrendHighlighting(RichTextBoxBehavior textBox)
		{
			Color trendColor;
			if (textBox.LastValue != 0 && textBox.LastValue != textBox.CurrentValue)
			{
				trendColor = (textBox.CurrentValue > textBox.LastValue)
					? Utils.AscendingColor // Rising
					: Utils.DecendingColor;// Falling				
			}
			else
			{
				trendColor = Color.LightGray;
			}

			if (textBox.InnerTextBox.BackColor != trendColor)
			{
				textBox.InnerTextBox.BackColor = trendColor;
			}
		}
	}
}
