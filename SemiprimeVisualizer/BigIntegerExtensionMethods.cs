using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SemiprimeVisualizer
{
	/// <summary>
	/// Sqrt and NRoot acquired from http://mjs5.com/2016/01/20/c-biginteger-helper-constructors
	/// </summary>
	public static class BigIntegerExtensionMethods
	{
		private static BigInteger Fifteen = new BigInteger(15);
		public static bool IsSquare(this BigInteger input)
		{
			if (input == BigInteger.Zero) { return false; }

			int bitwiseAnd = (int)(input & Fifteen);

			if (bitwiseAnd > 9)
			{
				return false; // return immediately in 6 cases out of 16.
			}

			//if (bitwiseAnd == 0 || bitwiseAnd == 1 || bitwiseAnd == 4 || bitwiseAnd == 9)  // squares in base 16 end in 0, 1, 4, or 9
			if (bitwiseAnd != 2 && bitwiseAnd != 3 && bitwiseAnd != 5 && bitwiseAnd != 6 && bitwiseAnd != 7 && bitwiseAnd != 8)
			{
				BigInteger sqrt = input.Sqrt();
				BigInteger sqr = sqrt.Square();
				bool dividedEvenly = (sqr == input);
				return dividedEvenly;   // return (input.Sqrt().Square() == input);
			}
			return false;

		}

		public static BigInteger Square(this BigInteger input)
		{
			return input * input;
		}

		// Returns the square root of a BigInteger number
		public static BigInteger Sqrt(this BigInteger input)
		{
			BigInteger n = 0, p = 0;
			if (input == BigInteger.Zero)
			{
				return BigInteger.Zero;
			}
			var high = input >> 1;
			var low = BigInteger.Zero;

			while (high > low + 1)
			{
				n = (high + low) >> 1;
				p = n * n;
				if (input < p)
				{
					high = n;
				}
				else if (input > p)
				{
					low = n;
				}
				else
				{
					break;
				}
			}
			return input == p ? n : low;
		}

		public static BigInteger Sqrt2(BigInteger num)
		{
			if (num == BigInteger.Zero) { return 0; }   // Avoid zero divide  

			BigInteger n = (num / 2) + 1; // Initial estimate, never low  
			BigInteger n1 = (n + (num / n)) / 2;
			while (n1 < n)
			{
				n = n1;
				n1 = (n + (num / n)) / 2;
			}
			return n;
		}

		// Returns the NTHs root of a BigInteger with Remainder.
		// The root must be greater than or equal to 1 or value must be a positive integer.
		public static BigInteger NthRoot(this BigInteger value, int root, ref BigInteger remainder)
		{
			if (root < 1)
			{
				throw new Exception("root must be greater than or equal to 1");
			}
			if (value.Sign == -1)
			{
				throw new Exception("value must be a positive integer");
			}

			if (value == BigInteger.One)
			{
				remainder = 0;
				return BigInteger.One;
			}
			if (value == BigInteger.Zero)
			{
				remainder = 0;
				return BigInteger.Zero;
			}
			if (root == 1)
			{
				remainder = 0;
				return value;
			}

			var upperbound = value;
			var lowerbound = BigInteger.Zero;

			while (true)
			{
				var nval = (upperbound + lowerbound) >> 1;
				var tstsq = BigInteger.Pow(nval, root);
				if (tstsq > value)
				{
					upperbound = nval;
				}
				if (tstsq < value)
				{
					lowerbound = nval;
				}
				if (tstsq == value)
				{
					lowerbound = nval;
					break;
				}
				if (lowerbound == upperbound - 1)
				{
					break;
				}
			}
			remainder = value - BigInteger.Pow(lowerbound, root);
			return lowerbound;
		}
	}
}
