using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SemiprimeVisualizer
{
	/// <summary>
	/// Aquired from http://mjs5.com/2016/01/20/c-biginteger-helper-constructors
	/// </summary>
	public static class BigIntegerExtensionMethods
	{
		/// <summary>
		/// Returns the square root of a BigInteger number
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns></returns>
		public static BigInteger Sqrt(this BigInteger number)
		{
			BigInteger n = 0, p = 0;
			if (number == BigInteger.Zero)
			{
				return BigInteger.Zero;
			}
			var high = number >> 1;
			var low = BigInteger.Zero;

			while (high > low + 1)
			{
				n = (high + low) >> 1;
				p = n * n;
				if (number < p)
				{
					high = n;
				}
				else if (number > p)
				{
					low = n;
				}
				else
				{
					break;
				}
			}
			return number == p ? n : low;
		}

		/// <summary>
		/// Returns the NTHs root of a BigInteger with Remainder
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="root">The root.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns></returns>
		/// <exception cref="System.Exception">
		/// root must be greater than or equal to 1
		/// or
		/// value must be a positive integer
		/// </exception>
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
