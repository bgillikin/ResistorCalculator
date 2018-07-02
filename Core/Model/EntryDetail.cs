using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class EntryDetail
    {
        public int ID;
        public DateTime Date;
        public int BandColor1ID;
        public int BandColor2ID;
        public int BandColor3ID;
        public int BandColor4ID;
        public string Resistance;
        public string Notes;

        // generic contructor
        public EntryDetail()
        {
        }

        // fully qualified constructor
        public EntryDetail(int key, DateTime date, int bandColor1ID, int bandColor2ID, int bandColor3ID, int bandColor4ID, string resistance, string notes)
        {
            this.ID = key;
            this.Date = date;
            this.BandColor1ID = bandColor1ID;
            this.BandColor2ID = bandColor2ID;
            this.BandColor3ID = bandColor3ID;
            this.BandColor4ID = bandColor4ID;
            this.Resistance = resistance;
            this.Notes = notes;
        }
    }
}
