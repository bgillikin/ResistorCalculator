using System;
using System.ComponentModel.DataAnnotations;

namespace ResistorCalculatorWeb.Models
{
    // Represents a resitor that has been logged in the Resitor Calculator app.
    public class Entry
    {
        public int ID { get; set; }
        public ResistorCalculatorService.EntryDetail EntryData { get; set; }
        public Band Band1;
        public Band Band2;
        public Band Band3;
        public Band Band4;

        // Default constructor.
        public Entry()
        {
        }

        // fully qualified constructor for easily creating entries.
        public Entry(int id, DateTime date, int bandColor1, int bandColor2, int bandColor3, int bandColor4, string resistance, string notes = null)
        {
            ID = id;
            ResistorCalculatorService.EntryDetail entryData = new ResistorCalculatorService.EntryDetail();
            entryData.Date = date;
            entryData.BandColor1ID = bandColor1;
            entryData.BandColor2ID = bandColor2;
            entryData.BandColor3ID = bandColor3;
            entryData.BandColor4ID = bandColor4;
            entryData.Resistance = resistance;
            entryData.Notes = notes;
            EntryData = entryData;
        }

        // enrty detail object based constructor for easily creating entries.
        public Entry(int id, ResistorCalculatorService.EntryDetail entryData)
        {
            ID = id;
            EntryData = entryData;
        }
    }
}