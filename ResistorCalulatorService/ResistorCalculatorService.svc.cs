using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Core.Model;
using Core.Data;

namespace ResistorCalulatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ResistorCalculatorService : IResistorCalculatorService
    {
        // return a list of available resistor band specifications
        public Dictionary<int, BandDetail> GetBandList()
        {
            // get a list of all the band specifications
            BandsDAO bankDAO = new BandsDAO();
            Dictionary<int, BandDetail> bandList = bankDAO.GetBandList();

            return bandList;
        }

        // return a list of entry details for previous saved resistors
        public Dictionary<int, EntryDetail> GetEntryList()
        {
            // get a list of all the band specifications from the data object
            EntryDAO entryDAO = new EntryDAO();
            Dictionary<int, EntryDetail> bandList = entryDAO.GetEntryList();

            return bandList;
        }

        public Boolean SaveEntryList(List<EntryDetail> entryList)
        {
            EntryDAO entryDAO = new EntryDAO();
            return entryDAO.SaveEntryList(entryList);
        }

        public String CalculateResistance(string first, string second, double multiplier, double tolerance)
        {
            double rootValue = Convert.ToDouble(first + second) * multiplier;
            double resistanceMin = rootValue * (1 - tolerance);
            double resistanceMax = rootValue * (1 + tolerance);
            string resistance = resistanceMin.ToString() + " - " + resistanceMax.ToString();

            return resistance;
        }
    }
}
