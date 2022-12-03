using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemiprimeVisualizer
{
	public partial class MainForm : Form
	{
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
			//

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

			QuadraticSieve sieve = new QuadraticSieve(currentProgress.SemiPrime);
			IEnumerable<BigInteger> smooths = sieve.GetDifferenceOfSquares();

			WriteBufferedOutput(string.Join(Environment.NewLine, smooths.Take(5000)));
			FlushBuffer();
		}
	}
}
