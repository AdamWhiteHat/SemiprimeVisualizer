

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SemiprimeVisualizer
{
	public class QuadraticSieve
	{
		public BigInteger ToFactor { get; private set; }
		public BigInteger SquareRoot { get; private set; }

		public IEnumerable<BigInteger> NumberRangeA;
		public IEnumerable<BigInteger> NumberRangeB;
		public IEnumerable<BigInteger> DifferenceOfSquaresCollection;
		public IEnumerable<BigInteger> LargestPrimeFactorsCollection;
		public IEnumerable<BigInteger> FermatSquaresCollection;
		public IEnumerable<BigInteger> SmoothNumbersCollection;

		private EnumerableRange enumerableRangeA;
		private EnumerableRange enumerableRangeB;


		public QuadraticSieve(BigInteger numberToFactor)
		{
			ToFactor = numberToFactor;
			SquareRoot = ToFactor.Sqrt();
			enumerableRangeA = new EnumerableRange(SquareRoot, (ToFactor / 2) - 1, 1);
			enumerableRangeB = new EnumerableRange(SquareRoot, SquareRoot + 1000, 1);
			NumberRangeA = enumerableRangeA.GetEnumerableRange();
			NumberRangeB = enumerableRangeB.GetEnumerableRange();
		}

		public IEnumerable<BigInteger> GetDifferenceOfSquares()
		{
			if (DifferenceOfSquaresCollection == null)
			{
				DifferenceOfSquaresCollection = getDifferenceOfSquaresEnumerator();
			}
			return DifferenceOfSquaresCollection;
		}

		private IEnumerable<BigInteger> getDifferenceOfSquaresEnumerator()
		{
			int counter = 1;
			BigInteger temp = new BigInteger();
			//	NumberRangeA.Where(n => (n.Square() - ToFactor).IsSquare());
			foreach (BigInteger a in NumberRangeA)
			{
				foreach (BigInteger b in NumberRangeB)
				{
					temp = ((a * b) - ToFactor);
					if (temp.IsSquare())
					{
						yield return temp;
					}
				}
				enumerableRangeB = new EnumerableRange(SquareRoot + counter, SquareRoot + 1000 + counter++, 1);
				NumberRangeB = enumerableRangeB.GetEnumerableRange();
			}

			yield break;
		}

		public IEnumerable<BigInteger> WhereFermatSquareFilter()
		{
			if (FermatSquaresCollection == null)
			{
				FermatSquaresCollection = NumberRangeA.Where(bi => bi.IsSquare());
			}
			return FermatSquaresCollection;
		}

		public IEnumerable<BigInteger> WhereSmoothNumberFilter(BigInteger toFactor, IEnumerable<BigInteger> input)
		{
			if (SmoothNumbersCollection == null)
			{
				SmoothNumbersCollection = NumberRangeA.Where(bi => !IsCoprime(toFactor, bi));
			}
			return SmoothNumbersCollection;
		}

		public IEnumerable<BigInteger> SelectLargestFactor()
		{
			BigInteger num;
			foreach (BigInteger number in NumberRangeA)
			{
				num = new BigInteger(number.ToByteArray());
				if (num == 2)
					yield return 2;
				while (num % 2 == 0)
					num = num / 2;
				for (BigInteger i = 3; i * i <= num; i += 2)
					while (num % i == 0)
						num = num / i;
				yield return num;
			}
			yield break;
		}
		
		public static bool IsCoprime(BigInteger value1, BigInteger value2)
		{
			return FindGCD(value1, value2) == 1;
		}

		public static BigInteger FindGCD(BigInteger to, params BigInteger[] args)
		{
			if (args == null) { throw new ArgumentNullException("Parameter args can not be null"); }
			if (args.Length < 2) { throw new ArgumentException("Must supply 2 or more arguments"); }
			return FindGCD(to, args.Aggregate(FindGCD));
		}

		public static BigInteger FindLCM(params BigInteger[] args)
		{
			if (args == null) { throw new ArgumentNullException("Parameter args can not be null"); }
			if (args.Length < 2) { throw new ArgumentException("Must supply 2 or more arguments"); }
			return args.Aggregate(FindLCM);
		}

		public static BigInteger FindGCD(BigInteger value1, BigInteger value2)
		{
			while (value1 != 0 && value2 != 0)
			{
				if (value1 > value2)
				{
					value1 %= value2;
				}
				else
				{
					value2 %= value1;
				}
			}
			return BigInteger.Max(value1, value2);
		}

		public static BigInteger FindLCM(BigInteger num1, BigInteger num2)
		{
			return (num1 * num2) / FindGCD(num1, num2);
		}
	}
}
