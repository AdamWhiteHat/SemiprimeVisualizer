using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SemiprimeVisualizer
{
	public class IEnumerableRange
	{
		private BigInteger RangeMin;
		private BigInteger RangeMax;
		private BigInteger CurrentValue;
		private BigInteger IncrementValue;

		public IEnumerableRange(BigInteger start, BigInteger stop, BigInteger increment)
		{
			RangeMin = start;
			RangeMax = stop;
			CurrentValue = RangeMin;
			IncrementValue = increment;
		}

		public IEnumerable<BigInteger> GetEnumerableRange()
		{
			CurrentValue = RangeMin;

			while (CurrentValue < RangeMax)
			{
				yield return CurrentValue;
				CurrentValue = CurrentValue + IncrementValue;
			}
			yield break;
		}
	}
}
