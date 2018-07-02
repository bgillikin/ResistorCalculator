using System;
using System.Collections.Generic;

namespace ResistorCalculatorWeb.Models
{
    // Represents a color band.
    public class Band
    {
        public int ID;
        public ResistorCalculatorService.BandDetail Specification { get; set; }

        // Default constructor.
        public Band()
        {
        }

        // fully qualifed constructor for band, color, code, significant figures, multiplier, and tolerance.
        public Band(int key, string color, string code, int? significantFigures, double? multiplier, double? tolerance)
        {
            // set the id to the key value provided
            ID = key;

            // set the band sepocifiation details from the provided data
            Specification.Color = color;
            Specification.Code = color;
            Specification.SignificantFigures = significantFigures;
            Specification.Mulitplier = multiplier;
            Specification.Tolerance = tolerance;
        }

        // Constructors a band for the provided band specification
        public Band(int key, ResistorCalculatorService.BandDetail band)
        {
            // set the id to the key value provided
            ID = key;

            // set the band sepcification to the object provided
            Specification = band;
        }
    }
}