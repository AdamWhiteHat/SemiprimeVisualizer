using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SemiprimeVisualizer
{
	public class EnumerableRange
	{
		public BigInteger RangeMin { get; private set; }
		public BigInteger RangeMax { get; private set; }
		public BigInteger CurrentValue { get; private set; }
		public BigInteger IncrementValue { get; private set; }

		private IEnumerable<BigInteger> enumerableRange;

		public EnumerableRange(BigInteger start, BigInteger stop, BigInteger increment)
		{
			RangeMin = start;
			RangeMax = stop;
			CurrentValue = RangeMin;
			IncrementValue = increment;
			Reset();
			enumerableRange = BuildEnumerableRange();
		}

		public IEnumerable<BigInteger> GetEnumerableRange()
		{
			return enumerableRange;
		}

		public void Reset()
		{
			CurrentValue = RangeMin;
		}

		private IEnumerable<BigInteger> BuildEnumerableRange()
		{
			while (CurrentValue < RangeMax)
			{
				yield return CurrentValue;
				CurrentValue += IncrementValue;
			}
			yield break;
		}
	}
}
