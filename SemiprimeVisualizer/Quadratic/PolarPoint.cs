using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

namespace SemiprimeVisualizer
{

	public class PolarPoint
	{
		public double Angle { get; private set; }
		public double Y { get; private set; }

		public PolarPoint(double angle, double y)
		{
			this.Angle = angle;
			this.Y = y;
		}

		public PolarPoint(double value)
			: this(new Complex(value, 0))
		{ }		

		public PolarPoint(Complex complexNumber)
		{
			this.Angle = complexNumber.Phase;
			this.Y = complexNumber.Magnitude;
		}
	}
}
