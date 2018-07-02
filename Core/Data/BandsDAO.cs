using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using System.IO;

namespace Core.Data
{
    public class BandsDAO
    {

        public Dictionary<int, BandDetail> GetBandList()
        {
            Dictionary<int, BandDetail> bands = new Dictionary<int, BandDetail>();

            // open the raw data file for the band specification details
            StreamReader bandFile = new StreamReader("C:\\Temp\\BandDetails.txt");

            try
            {
                // add all the band specification detail recods to the dictionary
                string line = bandFile.ReadLine();
                while (line != null)
                {
                    // split the data line into the specification values
                    string[] data = line.Split(',');
                    int key = Convert.ToInt32(data[0]);
                    string color = data[1];
                    string code = data[2];
                    int? signifigantFigures = null;
                    if (data[3].Trim() != "")
                        signifigantFigures = Convert.ToInt32(data[3]);
                    double? multiplier = null;
                    if (data[4].Trim() != "")
                        multiplier = Convert.ToDouble(data[4]);
                    double? tolerance = null;
                    if (data[5].Trim() != "")
                        tolerance = Convert.ToDouble(data[5]);

                    // add the current band specification
                    bands.Add(key, new BandDetail(color, code, signifigantFigures, multiplier, tolerance));

                    // read the next data line
                    line = bandFile.ReadLine();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                bandFile.Close();
            }

            return bands;
        }
    }
}
