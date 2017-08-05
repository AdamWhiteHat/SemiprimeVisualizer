using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SemiprimeVisualizer
{
	public partial class MainForm : Form
	{
		private double? clickX = null;
		private double? clickY = null;

		private ToolTip tooltip = new ToolTip();
		private Point? clickPosition = null;
		private static int moveBuffer = 7;
		private static int leftPaddingTotal = 18;
		private static int rightPaddingTotal = 25;
		private static string formatString = "#,###,###,##0.###";

		public void CreateTooltip(HitTestResult[] hitTest, Point position)
		{
			HitTestResult hit = hitTest[0];

			if (hit.ChartElementType == ChartElementType.DataPoint)
			{
				double xVal = hit.ChartArea.AxisX.PixelPositionToValue(position.X);
				double yVal = hit.ChartArea.AxisY.PixelPositionToValue(position.Y);

				string locationString = $"X={PadString(xVal.ToString(formatString))}";

				locationString = locationString.PadRight(rightPaddingTotal, ' ');
				locationString += $"  Y={PadString(yVal.ToString(formatString))}";

				tooltip.Show(locationString, this.chart1, position.X, position.Y - 15);

				tbGraphClickLocation.AppendText(locationString + Environment.NewLine);

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

					tbGraphClickLocation.AppendText(differenceString);

					clickX = null;
					clickY = null;
				}
			}
		}

		private static string PadString(string input)
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

		private static string FormatDifference(double firstValue, double secondValue)
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
	}
}
