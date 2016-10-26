using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

namespace SemiprimeVisualizer
{
	/// <summary>
	/// Arbitrary precision decimal.
	/// All operations are exact, except for division. Division never determines more digits than the given precision.
	/// Based on http://stackoverflow.com/a/4524254
	/// Author: Jan Christoph Bernack (contact: jc.bernack at googlemail.com)
	/// </summary>
	public struct BigDecimal
		: IComparable
		, IComparable<BigDecimal>
	{
		/// <summary>
		/// Specifies whether the significant digits should be truncated to the given precision after each operation.
		/// </summary>
		public static bool AlwaysTruncate = false;

		/// <summary>
		/// Sets the maximum precision of division operations.
		/// If AlwaysTruncate is set to true all operations are affected.
		/// </summary>
		public static int Precision = 5000;

		public BigInteger Mantissa { get; set; }
		public int Exponent { get; set; }

		public BigDecimal(bool alwaysTruncate, int precision)
		{
			AlwaysTruncate = alwaysTruncate;
			Precision = precision;
			Mantissa = 0;
			Exponent = 0;
		}

		public BigDecimal(BigInteger value)
			: this()
		{
			Mantissa = value;
			Exponent = 0;
		}

		public BigDecimal(BigInteger mantissa, int exponent)
			: this()
		{
			Mantissa = mantissa;
			Exponent = exponent;
			Normalize();
			if (AlwaysTruncate)
			{
				Truncate();
			}
		}

		/// <summary>
		/// Removes trailing zeros on the mantissa
		/// </summary>
		public void Normalize()
		{
			if (Mantissa.IsZero)
			{
				Exponent = 0;
			}
			else
			{
				BigInteger remainder = 0;
				while (remainder == 0)
				{
					var shortened = BigInteger.DivRem(Mantissa, 10, out remainder);
					if (remainder == 0)
					{
						Mantissa = shortened;
						Exponent++;
					}
				}
			}
		}

        /// <summary>
        /// Truncate the number to the given precision by removing the least significant digits.
        /// </summary>
        /// <returns>The truncated number</returns>
        public BigDecimal Truncate(int precision)
        {
            // Copy this instance (remember its a struct)
            var shortened = this;
            // Cave some time because the number of digits is not needed to remove trailing zeros
            shortened.Normalize();
            // Remove the least significant digits, as long as the number of digits is higher than the given Precision
            while (NumberOfDigits(shortened.Mantissa) > precision)
            {
                shortened.Mantissa /= 10;
                shortened.Exponent++;
            }
            // Normalize again to make sure there are no trailing zeros left
            shortened.Normalize();
            return shortened;
        }


        public BigDecimal Truncate()
		{
			return Truncate(Precision);
		}

        private static int NumberOfDigits(BigInteger value)
        {
            // do not count the sign
            //return (value * value.Sign).ToString().Length;
            // faster version
            return (int)Math.Ceiling(BigInteger.Log10(value * value.Sign));
        }


        #region Conversions

        public static explicit operator BigInteger(BigDecimal v)
		{
			v.Normalize();
			BigInteger exp = BigInteger.Pow(10, v.Exponent);
			return BigInteger.Multiply(v.Mantissa, exp);
		}

		public static implicit operator BigDecimal(BigInteger value)
		{
			return new BigDecimal(value);
		}

		public static implicit operator BigDecimal(int value)
		{
			return new BigDecimal(value, 0);
		}

		public static implicit operator BigDecimal(double value)
		{
			var mantissa = (BigInteger)value;
			var exponent = 0;
			double scaleFactor = 1;
			while (Math.Abs(value * scaleFactor - (double)mantissa) > 0)
			{
				exponent -= 1;
				scaleFactor *= 10;
				mantissa = (BigInteger)(value * scaleFactor);
			}
			return new BigDecimal(mantissa, exponent);
		}

		public static implicit operator BigDecimal(decimal value)
		{
			var mantissa = (BigInteger)value;
			var exponent = 0;
			decimal scaleFactor = 1;
			while ((decimal)mantissa != value * scaleFactor)
			{
				exponent -= 1;
				scaleFactor *= 10;
				mantissa = (BigInteger)(value * scaleFactor);
			}
			return new BigDecimal(mantissa, exponent);
		}

		public static explicit operator double(BigDecimal value)
		{
			return (double)value.Mantissa * Math.Pow(10, value.Exponent);
		}

		public static explicit operator float(BigDecimal value)
		{
			return Convert.ToSingle((double)value);
		}

		public static explicit operator decimal(BigDecimal value)
		{
			return (decimal)value.Mantissa * (decimal)Math.Pow(10, value.Exponent);
		}

		public static explicit operator int(BigDecimal value)
		{
			return (int)(value.Mantissa * BigInteger.Pow(10, value.Exponent));
		}

		public static explicit operator uint(BigDecimal value)
		{
			return (uint)(value.Mantissa * BigInteger.Pow(10, value.Exponent));
		}

		#endregion

		#region Operators

		public static BigDecimal operator +(BigDecimal value)
		{
			return value;
		}

		public static BigDecimal operator -(BigDecimal value)
		{
			value.Mantissa *= -1;
			return value;
		}

		public static BigDecimal operator ++(BigDecimal value)
		{
			return value + 1;
		}

		public static BigDecimal operator --(BigDecimal value)
		{
			return value - 1;
		}

		public static BigDecimal operator +(BigDecimal left, BigDecimal right)
		{
			return Add(left, right);
		}

		public static BigDecimal operator -(BigDecimal left, BigDecimal right)
		{
			return Add(left, -right);
		}

		private static BigDecimal Add(BigDecimal left, BigDecimal right)
		{
			return left.Exponent > right.Exponent
				? new BigDecimal(AlignExponent(left, right) + right.Mantissa, right.Exponent)
				: new BigDecimal(AlignExponent(right, left) + left.Mantissa, left.Exponent);
		}

		public static BigDecimal operator *(BigDecimal left, BigDecimal right)
		{
			return new BigDecimal(left.Mantissa * right.Mantissa, left.Exponent + right.Exponent);
		}

		public static BigDecimal operator /(BigDecimal dividend, BigDecimal divisor)
		{
			var exponentChange = Precision - (NumberOfDigits(dividend.Mantissa) - NumberOfDigits(divisor.Mantissa));
			if (exponentChange < 0)
			{
				exponentChange = 0;
			}
			dividend.Mantissa *= BigInteger.Pow(10, exponentChange);
			return new BigDecimal(dividend.Mantissa / divisor.Mantissa, dividend.Exponent - divisor.Exponent - exponentChange);
		}

		public static bool operator ==(BigDecimal left, BigDecimal right)
		{
			return left.Exponent == right.Exponent && left.Mantissa == right.Mantissa;
		}

		public static bool operator !=(BigDecimal left, BigDecimal right)
		{
			return left.Exponent != right.Exponent || left.Mantissa != right.Mantissa;
		}

		public static bool operator <(BigDecimal left, BigDecimal right)
		{
			return left.Exponent > right.Exponent ? AlignExponent(left, right) < right.Mantissa : left.Mantissa < AlignExponent(right, left);
		}

		public static bool operator >(BigDecimal left, BigDecimal right)
		{
			return left.Exponent > right.Exponent ? AlignExponent(left, right) > right.Mantissa : left.Mantissa > AlignExponent(right, left);
		}

		public static bool operator <=(BigDecimal left, BigDecimal right)
		{
			return left.Exponent > right.Exponent ? AlignExponent(left, right) <= right.Mantissa : left.Mantissa <= AlignExponent(right, left);
		}

		public static bool operator >=(BigDecimal left, BigDecimal right)
		{
			return left.Exponent > right.Exponent ? AlignExponent(left, right) >= right.Mantissa : left.Mantissa >= AlignExponent(right, left);
		}

		/// <summary>
		/// Returns the mantissa of value, aligned to the exponent of reference.
		/// Assumes the exponent of value is larger than of reference.
		/// </summary>
		private static BigInteger AlignExponent(BigDecimal value, BigDecimal reference)
		{
			return value.Mantissa * BigInteger.Pow(10, value.Exponent - reference.Exponent);
		}

		#endregion

		#region Additional mathematical functions

		public static BigDecimal Ceiling(BigDecimal value)
		{
			value.Normalize();
			return new BigDecimal(value.Mantissa + 1);
		}

		public static BigDecimal Floor(BigDecimal value)
		{
			value.Normalize();
			return new BigDecimal(value.Mantissa);
		}

		public static BigDecimal Exp(double exponent)
		{
			var tmp = (BigDecimal)1;
			while (Math.Abs(exponent) > 100)
			{
				var diff = exponent > 0 ? 100 : -100;
				tmp *= Math.Exp(diff);
				exponent -= diff;
			}
			return tmp * Math.Exp(exponent);
		}

		public static BigDecimal Exp(BigInteger exponent)
		{
			BigDecimal tmp = (BigDecimal)1;
			while (BigInteger.Abs(exponent) > 100)
			{
				int diff = exponent > 0 ? 100 : -100;
				tmp *= Math.Exp(diff);
				exponent -= diff;
			}
			double exp = (double)exponent;
			return tmp * Math.Exp(exp);
		}

		public static BigDecimal Pow(BigInteger value, BigInteger exponent)
		{
			var tmp = (BigDecimal)1;
			while (BigInteger.Abs(exponent) > 100)
			{
				var diff = exponent > 0 ? 100 : -100;
				tmp *= BigInteger.Pow(value, -1); //BigInteger.ModPow(value, diff, );
				exponent -= diff;
			}
			return tmp * BigInteger.Pow(value, (int)exponent);
		}

		public static BigDecimal Pow(double basis, double exponent)
		{
			var tmp = (BigDecimal)1;
			while (Math.Abs(exponent) > 100)
			{
				var diff = exponent > 0 ? 100 : -100;
				tmp *= Math.Pow(basis, diff);
				exponent -= diff;
			}
			return tmp * Math.Pow(basis, exponent);
		}

        #endregion

        public override string ToString()
        {
            string result = Mantissa.ToString();

            if (Exponent == 0)
            {
                return result;
            }

            int decimalPosition = result.Length + Exponent;

            return result.Insert(decimalPosition, ".");
        }

        public bool Equals(BigDecimal other)
		{
			return other.Mantissa.Equals(Mantissa) && other.Exponent == Exponent;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			return obj is BigDecimal && Equals((BigDecimal)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Mantissa.GetHashCode() * 397) ^ Exponent;
			}
		}

		public int CompareTo(object obj)
		{
			if (ReferenceEquals(obj, null) || !(obj is BigDecimal))
			{
				throw new ArgumentException();
			}
			return CompareTo((BigDecimal)obj);
		}

		public int CompareTo(BigDecimal other)
		{
			return this < other ? -1 : (this > other ? 1 : 0);
		}

		public static BigDecimal E;

		// This sets E
		static BigDecimal()
		{
			BigInteger mantissa = BigInteger.Parse("27182818284590452353602874713526624977572470936999595749669676277240766303535475945713821785251664");

			/*	MORE....
			27427466391932003059921817413596629043572900334295260595630738132328627943490763233829880753195251019011573834187930702154089149934884167509244761460668082264800168477411853742345442437107539077744992069551702761838606261331384583000752044933826560297606737113200709328709127443747047230696977209310141692836819025515108657463772111252389784425056953696770785449969967946864454905987931636889230098793127736178215424999229576351482208269895193668033182528869398496465105820939239829488793320362509443117301238197068416140397019837679320683282376464804295311802328782509819455815301756717361332069811250996181881593041690351598888519345807273866738589422879228499892086805825749279610484198444363463244968487560233624827041978623209002160990235304369941849146314093431738143640546253152096183690888707016768396424378140592714563549061303107208510383750510115747704171898610687396965521267154688957035035402123407849819334321068170121005627880235193033224745015853904730419957777093503660416997329725088687696640355570716226844716256079882651787134195124665201030592123667719432527867539855894489697096409754591856956380236370162112047742722836489613422516445078182442352948636372141740238893441247963574370263755294448337998016125492278509257782562092622648326277933386566481627725164019105900491644998289315056604725802778631864155195653244258698294695930801915298721172556347546396447910145904090586298496791287406870504895858671747985466775757320568128845920541334053922000113786300945560688166740016984205580403363795376452030402432256613527836951177883863874439662532249850654995886234281899707733276171783928034946501434558897071942586398772754710962953741521115136835062752602326484728703920764310059584116612054529703023647254929666938115137322753645098889031360205724817658511806303644281231496550704751025446501172721155519486685080036853228183152196003735625279449515828418829478761085263981395599006737648292244375287184624578036
			192981971399147564488262603903381441823262515097482798777996437308997038886778227138360577297882412561
			190717663946507063304527954661855096666185664709711344474016070462621568071748187784437143698821855967
			095910259686200235371858874856965220005031173439207321139080329363447972735595527734907178379342163701
			205005451326383544000186323991490705479778056697853358048966906295119432473099587655236812859041383241
			160722602998330535370876138939639177957454016137223618789365260538155841587186925538606164779834025435
			128439612946035291332594279490433729908573158029095863138268329147711639633709240031689458636060645845
			925126994655724839186564209752685082307544254599376917041977780085362730941710163434907696423722294352
			366125572508814779223151974778060569672538017180776360346245927877846585065605078084421152969752189087
			401966090665180351650179250461950136658543663271254963990854914420001457476081930221206602433009641270
			489439039717719518069908699860663658323227870937650226014929101151717763594460202324930028040186772391
			028809786660565118326004368850881715723866984224220102495055188169480322100251542649463981287367765892
			768816359831247788652014117411091360116499507662907794364600585194199856016264790761532103872755712699
			251827568798930276176114616254935649590379804583818232336861201624373656984670378585330527583333793990
			752166069238053369887956513728559388349989470741618155012539706464817194670834819721448889879067650379
			590366967249499254527903372963616265897603949857674139735944102374432970935547798262961459144293645142
			8617158587339746791897571211956187385783644758448423555581050025611492391518893");*/
			E = new BigDecimal(mantissa, -3647);
		}
	}
}
