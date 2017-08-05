using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SemiprimeVisualizer
{
	public class FactorizationProgress
	{
		public BigInteger Sqrt { get; set; }
		public BigInteger SemiPrime { get; set; }
		public BigInteger P { get; set; }
		public BigInteger Q { get; set; }

		public BigInteger Product { get; set; }

		public FactorizationProgress()
		{
			SemiPrime = -1;
			Sqrt = -1;
			P = -1;
			Q = -1;
			Product = -1;
		}

		public FactorizationProgress(BigInteger semiPrime)
			: this()
		{
			SemiPrime = semiPrime;
			Sqrt = SemiPrime.Sqrt();

			P = Sqrt % 2 == 0 ? Sqrt - 1 : Sqrt;
			Q = Sqrt % 2 == 0 ? Sqrt + 1 : Sqrt;

			//Product = 0;
		}

	}
}
