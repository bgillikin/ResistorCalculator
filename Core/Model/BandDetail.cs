using System;

namespace Core.Model
{
    public class BandDetail
    {
        // specifications for a color band on a resistor to be used for calculating the resitance in ohms
        public string Color;
        public string Code;
        public int? SignificantFigures;
        public double? Mulitplier;
        public double? Tolerance;

        // generic contructor
        public BandDetail()
        {
        }

        // fully qualified constructor
        public BandDetail(string color, string code, int? significantFigures, double? multiplier, double? tolerance)
        {
            this.Color = color;
            this.Code = code;
            this.SignificantFigures = significantFigures;
            this.Mulitplier = multiplier;
            this.Tolerance = tolerance;
        }
    }
}
