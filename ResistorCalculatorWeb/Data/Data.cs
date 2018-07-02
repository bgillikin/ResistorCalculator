using System;
using System.Collections.Generic;
using ResistorCalculatorWeb.Models;

namespace ResistorCalculatorWeb.Data
{
    /// <summary>
    /// Provides an in-memory data store.
    /// 
    /// Note: The code in this class is not to be considered a "best practice" 
    /// example of how to do data persistence, but rather as workaround for
    /// not having a database to persist data to.
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// The collection of activities.
        /// </summary>
        public static List<Band> Bands { get; set; }

        // The collection of entries.
        public static List<Entry> Entries { get; set; }

        // Static constructor used to initialize the data.
        static Data()
        {
            InitData();
        }

        private static void InitData()
        {

            // get dictionary of all avaiable bands and their specification from the web service 
            // this is done first so we can use them with the entries data
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();
            Dictionary<int, ResistorCalculatorService.BandDetail> bandColors = service.GetBandList();
            List<Band> bands = new List<Band>();
            foreach (KeyValuePair<int, ResistorCalculatorService.BandDetail> band in bandColors)
            {
                ResistorCalculatorService.BandDetail bandItem = (ResistorCalculatorService.BandDetail)band.Value;
                Band bandColor = new Band(band.Key, bandItem);
                bands.Add(bandColor);
            }

            // get dictionary of all avaiable bands and their specification from the web service
            Dictionary<int, ResistorCalculatorService.EntryDetail> entryList = service.GetEntryList();
            List<Entry> entries = new List<Entry>();
            foreach (KeyValuePair<int, ResistorCalculatorService.EntryDetail> entry in entryList)
            {
                ResistorCalculatorService.EntryDetail entryItem = (ResistorCalculatorService.EntryDetail)entry.Value;
                Entry entryData = new Entry(entryItem.ID, entryItem);
                entries.Add(entryData);
            }

            // set the static lists
            Bands = bands;
            Entries = entries;
        }

        public static void SaveEntryData()
        {
            // build a list of only the entry detail data objects
            List<ResistorCalculatorService.EntryDetail> entryList = new List<ResistorCalculatorService.EntryDetail>();
            foreach(Entry entry in Entries)
            {
                entryList.Add(entry.EntryData);
            }

            // save all the entry detail data from the list thru the service
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();
            service.SaveEntryList(entryList.ToArray());
        }
    }
}