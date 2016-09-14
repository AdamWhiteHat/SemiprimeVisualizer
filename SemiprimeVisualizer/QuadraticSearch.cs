using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SemiprimeVisualizer
{
	public class QuadraticSearch
	{
		public BigInteger ToFactor { get; private set; }
		public BigInteger SquareRoot { get; private set; }

		public IEnumerable<BigInteger> NumberRange;
		public IEnumerable<BigInteger> DifferenceOfSquaresCollection;
		public IEnumerable<BigInteger> LargestPrimeFactorsCollection;
		public IEnumerable<BigInteger> FermatSquaresCollection;
		public IEnumerable<BigInteger> SmoothNumbersCollection;

		public QuadraticSearch(BigInteger numberToFactor)
		{
			ToFactor = numberToFactor;
			SquareRoot = ToFactor.Sqrt();
		}

		private IEnumerableRange CreateIEnumerableRange()
		{
			return new IEnumerableRange(SquareRoot, (ToFactor / 2) - 1, 1);
		}

		public IEnumerable<BigInteger> GetDifferenceOfSquares()
		{
			IEnumerableRange range = CreateIEnumerableRange();
			foreach (BigInteger num in range.GetEnumerableRange())
			{
				BigInteger temp = (BigInteger.Pow(num, 2) - ToFactor);
				yield return temp;
			}
			yield break;
		}

		public IEnumerable<BigInteger> SelectLargestFactor()
		{
			BigInteger num;
			IEnumerableRange range = CreateIEnumerableRange();
			foreach (BigInteger number in range.GetEnumerableRange())
			{
				num = new BigInteger(number.ToByteArray());
				if (num == 2)
				{
					yield return 2;
				}
				while (num % 2 == 0)
				{
					num = num / 2;
				}
				for (BigInteger i = 3; i * i <= num; i += 2)
				{
					while (num % i == 0)
					{
						num = num / i;
					}
				}
				yield return num;
			}
			yield break;
		}

		public IEnumerable<BigInteger> WhereFermatSquareFilter()
		{
			IEnumerableRange range = CreateIEnumerableRange();
			return range.GetEnumerableRange().Where(bi => IsSquare(bi));
		}

		public IEnumerable<BigInteger> WhereSmoothNumberFilter(BigInteger toFactor, IEnumerable<BigInteger> input)
		{
			IEnumerableRange range = CreateIEnumerableRange();
			return range.GetEnumerableRange().Where(bi => !IsCoprime(toFactor, bi));
		}
		
		public static bool IsSquare(BigInteger input)
		{
			return (BigInteger.Pow(input.Sqrt(), 2) == input);
		}

		public static BigInteger MakeSquare(BigInteger input)
		{
			return input * input;
		}

		public static bool IsCoprime(BigInteger value1, BigInteger value2)
		{
			return FindGCD(value1, value2) == 1;
		}

		public static BigInteger FindGCD(BigInteger to, params BigInteger[] args)
		{
			if (args == null) { throw new ArgumentNullException("args can not be null"); }
			if (args.Length < 2) { throw new ArgumentException("Must supply 2 or more arguments"); }
			return FindGCD(to, args.Aggregate(FindGCD));
		}

		public static BigInteger FindLCM(params BigInteger[] args)
		{
			if (args == null) { throw new ArgumentNullException("args can not be null"); }
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
