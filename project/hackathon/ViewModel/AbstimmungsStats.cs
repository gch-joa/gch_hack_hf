using System;
using System.Windows;

namespace hackathon.ViewModel
{
	public class AbstimmungsStats
	{
		private double _anzahlNein;

		private double _anzahlJa;

		public double AnzahlNein
		{
			get
			{
				return this._anzahlNein;
			}
			set
			{
				this._anzahlNein = value;
			}
		}

		public double AnzahlJa
		{
			get
			{
				return this._anzahlJa;
			}
			set
			{
				this._anzahlJa = value;
			}
		}

		public Point AnzahlJaInCoordinates
		{
			get
			{
				// in case we have 100%, the circle is not filled, since start and end point are the same
				double ja = Math.Abs(this._anzahlJa - 100) > 0.01 ? this._anzahlJa : 99.99;

				double angle = 2 * Math.PI * (ja / 100);
				double x = 50 * Math.Cos(angle);
				double y = 50 * Math.Sin(angle);

				return new Point(x, y);
			}
		}
	}
}