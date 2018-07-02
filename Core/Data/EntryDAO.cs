using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using System.IO;

namespace Core.Data
{
    public class EntryDAO
    {

        public Dictionary<int, EntryDetail> GetEntryList()
        {
            Dictionary<int, EntryDetail> entries = new Dictionary<int, EntryDetail>();

            // open the raw data file for the band specification details
            StreamReader entryFile = new StreamReader("C:\\Temp\\EntryDetails.txt");

            try
            {
                // add all the band specification detail recods to the dictionary
                string line = entryFile.ReadLine();
                while (line != null)
                {
                    // split the data line into the specification values
                    string[] data = line.Substring(0, line.IndexOf('|') - 1).Split(',');
                    string notes = line.Substring(line.IndexOf('|') + 1);
                    int key = Convert.ToInt32(data[0]);
                    DateTime date = Convert.ToDateTime(data[1]);
                    int bandColor1ID = Convert.ToInt32(data[2]);
                    int bandColor2ID = Convert.ToInt32(data[3]);
                    int bandColor3ID = Convert.ToInt32(data[4]);
                    int bandColor4ID = Convert.ToInt32(data[5]);
                    string resistance = data[6];

                    // add the current band specification
                    entries.Add(key, new EntryDetail(key, date, bandColor1ID, bandColor2ID, bandColor3ID, bandColor4ID, resistance, notes));

                    // read the next data line
                    line = entryFile.ReadLine();
                }
            }
            catch
            {
                // re-throw the erro to get the full stack trace
                throw;
            }
            finally
            {
                // ensure the entry file is alwys closed before returning
                entryFile.Close();
            }

            return entries;
        }

        public bool SaveEntryList(List<EntryDetail> entryList)
        {
            // set initia return status to success
            bool status = true;

            // open the entry file for output as an empty file
            StreamWriter entryFile = new StreamWriter("C:\\Temp\\EntryDetails.txt", false);
            try
            {
                // add all the entries bacj to the empty entry file
                int i = 1;
                foreach (EntryDetail entry in entryList)
                {
                    string line = i.ToString() + "," + entry.Date.ToString("yyyy-MM-dd") + "," + entry.BandColor1ID.ToString() + "," + entry.BandColor2ID.ToString() + "," + 
                        entry.BandColor3ID.ToString() + "," + entry.BandColor4ID.ToString() + "," + entry.Resistance + "|" + entry.Notes.Replace("\r\n", "@@");
                    entryFile.WriteLine(line);
                    i++;
                }
            }
            catch
            {
                // set the status to failure and re-throw the erro to get the full stack trace
                status = false;
                throw;
            }
            finally
            {
                // ensure the entry file is alwys closed before returning
                entryFile.Close();
            }
            return status;
        }
    }
}
