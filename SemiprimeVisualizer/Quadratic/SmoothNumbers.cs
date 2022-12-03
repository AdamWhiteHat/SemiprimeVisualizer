using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace SemiprimeVisualizer
{
	public class SmoothNumbers
	{
		public List<int> Coefficients { get; private set; }
		private PermutationSet exponentPermutation;
		private IEnumerable<BigInteger> cache;

		// Optimal value for B (factoringBase) is thought to be exp((logN loglogN)^(1/2)).
		public SmoothNumbers(int[] coefficients, int maxExponent)
		{
			cache = null;
			Coefficients = coefficients.ToList();
			Coefficients.Sort();

			int[] exponentValues = Enumerable.Range(1, maxExponent + 1).Select(i => i).ToArray();
			List<List<int>> termsList = Coefficients.Select(a => new List<int>(exponentValues)).ToList();

			exponentPermutation = new PermutationSet(termsList);
		}

		public IEnumerable<BigInteger> GetCalculatedValues()
		{
			if (cache == null)
			{
				cache = getCalculatedEnumerable();
			}
			return cache;
		}

		private int[] lastValues = null;
		private IEnumerable<BigInteger> getCalculatedEnumerable()
		{
			IEnumerable<int[]> ExponentMatrix = exponentPermutation.GetPermutations();
			foreach (int[] exponents in ExponentMatrix)
			{
				lastValues = exponents;
				int n = 0;
				yield return Coefficients.Select(c => BigInteger.Pow(c, exponents[n++])).Aggregate(BigInteger.Add);
			}
			yield break;
		}

		public override string ToString()
		{
			if (lastValues == null) { return "(null)"; }
			if (lastValues.Length < 1) { return "(empty)"; }

			int n = 0;
			return string.Join(" + ", Coefficients.Select(c => string.Format("{0}^{1}", c, lastValues[n++])));
		}
	}
}
