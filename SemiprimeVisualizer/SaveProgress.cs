using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SemiprimeVisualizer
{
	public class SaveProgress
	{
		public static void Save(string filename, FactorizationProgress progress)
		{
			XDocument xdoc = new XDocument(
								new XElement("Root",
									new XElement("SemiPrime", progress.SemiPrime.ToString()),
									new XElement("Sqrt", progress.Sqrt.ToString()),
									new XElement("P", progress.P.ToString()),
									new XElement("Q", progress.Q.ToString()),
									new XElement("Product", progress.Product.ToString())
								)
							);

			xdoc.Save(filename);
		}

		public static FactorizationProgress Open(string filename)
		{
			XDocument xdoc = XDocument.Load(filename);
			IEnumerable<XElement> elements = xdoc.Root.Descendants();

			string semiprime = elements.Where(n => n.Name == "SemiPrime").Single().Value;
			string sqrt = elements.Where(n => n.Name == "Sqrt").Single().Value;
			string pStr = elements.Where(n => n.Name == "P").Single().Value;
			string qStr = elements.Where(n => n.Name == "Q").Single().Value;
			string prod = elements.Where(n => n.Name == "Product").Single().Value;

			BigInteger semiPrime = 0;
			BigInteger sqr = 0;
			BigInteger oP = new BigInteger();
			BigInteger oQ = new BigInteger();
			BigInteger oProd = new BigInteger();

			BigInteger.TryParse(sqrt, out sqr);
			BigInteger.TryParse(semiprime, out semiPrime);
			BigInteger.TryParse(pStr, out oP);
			BigInteger.TryParse(qStr, out oQ);
			BigInteger.TryParse(prod, out oProd);

			FactorizationProgress result = new FactorizationProgress();

			result.SemiPrime = semiPrime;
			result.Sqrt = sqr;
			result.P = oP;
			result.Q = oQ;
			result.Product = oProd;

			return result;
		}
	}
}
