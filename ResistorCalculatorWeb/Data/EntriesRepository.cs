using System;
using System.Collections.Generic;
using System.Linq;
using ResistorCalculatorWeb.Models;

namespace ResistorCalculatorWeb.Data
{
    public class EntriesRepository
    {
        // Returns a collection of entries.
        public List<Entry> GetEntries()
        {
            return Data.Entries
                .Join(
                    Data.Bands, // set the first band object
                    e => e.EntryData.BandColor1ID, 
                    b => b.ID,  
                    (e, b) =>  
                    {
                        e.Band1 = b; 
                        return e; 
                    }
                    )
                .Join(
                    Data.Bands, // set the second band object
                    e => e.EntryData.BandColor2ID, 
                    b => b.ID,  
                    (e, b) =>  
                    {
                        e.Band2 = b; 
                        return e; 
                    }
                    )
                .Join(
                    Data.Bands, // set the thrid band object
                    e => e.EntryData.BandColor3ID, 
                    b => b.ID,  
                    (e, b) =>  
                    {
                        e.Band3 = b; 
                        return e; 
                    }
                    )
                .Join(
                    Data.Bands, // set the fourth band object
                    e => e.EntryData.BandColor4ID, 
                    b => b.ID,  
                    (e, b) =>  
                    {
                        e.Band4 = b; 
                        return e; 
                    }
                    )
                .OrderByDescending(e => e.EntryData.Date)
                .ThenByDescending(e => e.ID)
                .ToList();
        }

        // Returns a single entry for the provided ID.
        public Entry GetEntry(int id)
        {
            Entry entry = Data.Entries
                .Where(e => e.ID == id)
                .SingleOrDefault();

            // Ensure that the band 1 property is not null.
            if (entry.Band1 == null)
            {
                entry.Band1 = Data.Bands
                    .Where(b => b.ID == entry.EntryData.BandColor1ID)
                    .SingleOrDefault();
            }

            // Ensure that the band 2 property is not null.
            if (entry.Band2 == null)
            {
                entry.Band2 = Data.Bands
                    .Where(b => b.ID == entry.EntryData.BandColor2ID)
                    .SingleOrDefault();
            }

            // Ensure that the band 3 property is not null.
            if (entry.Band3 == null)
            {
                entry.Band3 = Data.Bands
                    .Where(b => b.ID == entry.EntryData.BandColor3ID)
                    .SingleOrDefault();
            }

            // Ensure that the band 4 property is not null.
            if (entry.Band4 == null)
            {
                entry.Band4 = Data.Bands
                    .Where(b => b.ID == entry.EntryData.BandColor4ID)
                    .SingleOrDefault();
            }

            return entry;
        }

        // Adds an entry.
        public void AddEntry(Entry entry)
        {
            //// Get the next available entry ID.
            //int nextAvailableEntryId = Data.Entries
            //    .Max(e => e.ID) + 1;

            //entry.EntryData.ID = nextAvailableEntryId;

            // add the entry to the local entries list first
            Data.Entries.Add(entry);

            // save the entire local entry list to the service
            Data.SaveEntryData();
        }

        // Updates an entry.
        public void UpdateEntry(Entry entry)
        {
            // Find the index of the entry that we need to update.
            int entryIndex = Data.Entries.FindIndex(e => e.ID == entry.ID);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", entry.ID));
            }

            // update the associated entry in the local entry list first
            Data.Entries[entryIndex] = entry;

            // save the entire local entry list to the service
            Data.SaveEntryData();
        }

        // Deletes an entry.
        public void DeleteEntry(int id)
        {
            // Find the index of the entry that we need to delete.
            int entryIndex = Data.Entries.FindIndex(e => e.ID == id);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", id));
            }

            // remove the selected entry from the local entry list first
            Data.Entries.RemoveAt(entryIndex);

            // save the entire local entry list to the service
            Data.SaveEntryData();
        }
    }
}