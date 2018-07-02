using System.Collections.Generic;
using System.Linq;
using ResistorCalculatorWeb.Models;

namespace ResistorCalculatorWeb.Data
{
    /// <summary>
    /// Repository for activities.
    /// 
    /// Note: The code in this class is not to be considered a "best practice" 
    /// example of how to do data persistence, but rather as workaround for
    /// not having a database to persist data to.
    /// </summary>
    public class BandsRepository
    {
        /// <summary>
        /// Returns a collection of activities.
        /// </summary>
        /// <returns>A list of activities.</returns>
        public List<Band> GetBands()
        {
            return Data.Bands
                .OrderBy(b => b.ID)
                .ToList();
        }
    }
}