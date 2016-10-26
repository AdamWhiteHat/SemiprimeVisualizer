using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SemiprimeVisualizer
{
	public class QuadraticSearch
	{
		public BigInteger SemiPrime;
		private Action<string> LoggingMethod;
		private QuadraticSieve quadraticSieve;

		private List<BigInteger> DifferenceOfSquares = new List<BigInteger>();
		private List<BigInteger> LargestPrimeFactors = new List<BigInteger>();
		private List<BigInteger> FermatSquares = new List<BigInteger>();
		private List<BigInteger> SmoothNumbers = new List<BigInteger>();
		private IEnumerable<BigInteger> differenceOfSquaresEnumerator;  //private IEnumerable<BigInteger> largestPrimeFactorEnumerator;
		private IEnumerable<BigInteger> fermatSquaresEnumerator;
		private IEnumerable<BigInteger> smoothNumbersEnumerator;

		public QuadraticSearch(BigInteger semiPrime, Action<string> loggingMethod)
		{
			quadraticSieve = null;
			SemiPrime = semiPrime;
			LoggingMethod = loggingMethod;
		}

		public void StartSearch()
		{
			if (quadraticSieve == null)
			{
				quadraticSieve = new QuadraticSieve(SemiPrime);
				differenceOfSquaresEnumerator = quadraticSieve.GetDifferenceOfSquares();
			}

			if (differenceOfSquaresEnumerator != null)
			{
				int skipCnt = 0;
				if (DifferenceOfSquares.Count > 0)
				{
					skipCnt = DifferenceOfSquares.Count;
				}
				List<BigInteger> newDifferenceOfSquares = differenceOfSquaresEnumerator.Skip(skipCnt).Take(1).ToList();
				DifferenceOfSquares.AddRange(newDifferenceOfSquares);

				string relations = string.Join(Environment.NewLine, newDifferenceOfSquares) + Environment.NewLine;
				LoggingMethod.Invoke(relations);

				BigInteger a = newDifferenceOfSquares.First();
				BigInteger a2 = a.Square();

				BigInteger b2 = a2 - SemiPrime;
				BigInteger b = b2.Sqrt();

				BigInteger congruence = (b % SemiPrime);
				bool hasCongruence = (congruence == a);
				bool keep = !hasCongruence;

				LoggingMethod.Invoke(congruence.ToString() + ": " + keep.ToString() + Environment.NewLine);


				//WriteOutput("Difference of Squares");
				//WriteOutput(result + Environment.NewLine);

				//LargestPrimeFactors.AddRange(quadraticSearch.SelectLargestFactor());

				//int index = 0;
				//Dictionary<BigInteger, List<int>> primeFactorIndexDictionary = new Dictionary<BigInteger, List<int>>();
				//foreach (BigInteger factor in LargestPrimeFactors)
				//{
				//	if (primeFactorIndexDictionary.ContainsKey(factor))
				//	{
				//		primeFactorIndexDictionary[factor].Add(index++);
				//	}
				//	else
				//	{
				//		List<int> newList = new List<int>();
				//		newList.Add(index++);
				//		primeFactorIndexDictionary.Add(factor, newList);
				//	}
				//}

				//IOrderedEnumerable<KeyValuePair<BigInteger, List<int>>> orderedPrimeFactors = primeFactorIndexDictionary.OrderBy(kvp => kvp.Key);

				//result = string.Join(Environment.NewLine, orderedPrimeFactors.Select(kvp => string.Format("{0} :\t[{1}]", kvp.Key, string.Join(", ", kvp.Value))));

				////WriteOutput("Largest Prime Factors");
				////WriteOutput(result + Environment.NewLine);

				//List<KeyValuePair<BigInteger, List<int>>> smoothNumbers = orderedPrimeFactors.Where(kvp => kvp.Value.Count > 2).ToList();

				//List<KeyValuePair<BigInteger, List<BigInteger>>> FoundFactors = new List<KeyValuePair<BigInteger, List<BigInteger>>>();

				//foreach (KeyValuePair<BigInteger, List<int>> smoothFactors in smoothNumbers)
				//{
				//	if (smoothFactors.Key == 1)
				//	{
				//		continue;
				//	}

				//	List<BigInteger> factors = new List<BigInteger>();
				//	foreach (int indx in smoothFactors.Value)
				//	{
				//		factors.Add(DifferenceOfSquares[indx]);
				//	}
				//	//WriteOutput(string.Format("Common Prime Factor: {0} of [{1}]", smoothFactors.Key, string.Join(", ", factors)));

				//	BigInteger sum = factors.Aggregate(BigInteger.Multiply);

				//	if (QuadraticSearch.IsSquare(sum))
				//	{
				//		//WriteOutput(string.Format("*FoundSquare: {0}\r\n*Factors: {1}", smoothFactors.Key, string.Join(", ", factors)));
				//		FoundFactors.Add(new KeyValuePair<BigInteger, List<BigInteger>>(smoothFactors.Key, factors));
				//	}
				//}

				//if (DifferenceOfSquares.Count > 10000)
				//{
				//	if (FermatSquares.Count < 100)
				//	{
				//		if (fermatSquaresEnumerator == null)
				//		{
				//			fermatSquaresEnumerator = quadraticSearch.WhereFermatSquareFilter();
				//		}

				//		if (fermatSquaresEnumerator != null)
				//		{
				//			int skipB = 0;
				//			if (FermatSquares.Count > 0)
				//			{
				//				skipB = FermatSquares.Count;
				//			}
				//			List<BigInteger> newSquares = fermatSquaresEnumerator.Skip(skipB).Take(1).ToList();
				//			FermatSquares.AddRange(newSquares);
				//			result = string.Join(Environment.NewLine, newSquares);

				//			//WriteOutput("(a^2)-n squares");
				//			//WriteOutput(result + Environment.NewLine);
				//		}
				//	}
				//	else
				//	{
				//		if (smoothNumbersEnumerator == null)
				//		{
				//			smoothNumbersEnumerator = quadraticSearch.WhereSmoothNumberFilter(quadraticSearch.ToFactor, FermatSquares);
				//		}

				//		if (smoothNumbersEnumerator != null)
				//		{
				//			int skipC = 0;
				//			if (SmoothNumbers.Count > 0)
				//			{
				//				skipC = SmoothNumbers.Count;
				//			}
				//			List<BigInteger> newSmoothNumbers = smoothNumbersEnumerator.Skip(skipC).Take(10).ToList();
				//			SmoothNumbers.AddRange(newSmoothNumbers);
				//			result = string.Join(Environment.NewLine, newSmoothNumbers);

				//			//WriteOutput("Smooth Numbers");
				//			//WriteOutput(result + Environment.NewLine);
				//		}
				//	}
				//}
			}
		}

	}
}
