using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Core.Model;

namespace ResistorCalulatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IResistorCalculatorService
    {
        [OperationContract]
        Dictionary<int, BandDetail> GetBandList();

        [OperationContract]
        Dictionary<int, EntryDetail> GetEntryList();

        [OperationContract]
        Boolean SaveEntryList(List<EntryDetail> entryList);

        [OperationContract]
        String CalculateResistance(string first, string second, double multiplier, double tolerance);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
    }
}
