using System;
using System.Windows;

namespace hackathon.ViewModel
{
    public class AbstimmungsStats
    {
        private double _anzahlJa;

        public double AnzahlNein { get; set; }

        public double AnzahlJa
        {
            get { return _anzahlJa; }
            set { _anzahlJa = value; }
        }

        public Point AnzahlJaInCoordinates
        {
            get
            {
                // in case we have 100%, the circle is not filled, since start and end point are the same
                double ja = Math.Abs(_anzahlJa - 100) > 0.01 ? _anzahlJa : 99.99;

                double angle = 2*Math.PI*(ja/100);
                double x = 50*Math.Cos(angle);
                double y = 50*Math.Sin(angle);

                return new Point(x, y);
            }
        }

        public bool UseLargeArc { get; set; }

        public string Name { get; set; }
    }
}