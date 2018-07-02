using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistorCalculatorWeb;
using ResistorCalculatorWeb.Controllers;

namespace ResistorCalculatorWeb.Tests.Controllers
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void GetBandList()
        {
            // Arrange
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();

            // Act
            Dictionary<int, ResistorCalculatorService.BandDetail> bandList = service.GetBandList();
            
            // Assert
            Assert.AreEqual(bandList.Count, 14);
        }

        [TestMethod]
        public void GetEntryList()
        {
            // Arrange
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();

            // Act
            Dictionary<int, ResistorCalculatorService.EntryDetail> entryList = service.GetEntryList(); 
            
            // Assert
            Assert.AreEqual(entryList.Count, entryList.Last().Key);
        }

        [TestMethod]
        public void SaveEntryList()
        {
            // Arrange
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();

            // Act
            // get the original entry list
            Dictionary<int, ResistorCalculatorService.EntryDetail> entryList = service.GetEntryList();

            // build an new list of just the entry detail adn save back to service
            List<ResistorCalculatorService.EntryDetail> entries = new List<ResistorCalculatorService.EntryDetail>();
            foreach(KeyValuePair<int,ResistorCalculatorService.EntryDetail> entry in entryList)
            {
                ResistorCalculatorService.EntryDetail entryDetail = entry.Value;
                entries.Add(entryDetail);
            }
            service.SaveEntryList(entries.ToArray());

            // get the updated entry list post save to service
            Dictionary<int, ResistorCalculatorService.EntryDetail> entryList2 = service.GetEntryList();

            // Assert
            Assert.AreEqual(entryList.Count, entryList2.Count);
        }

        [TestMethod]
        public void CalculateResistance()
        {
            // Arrange
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();

            // Act
            // calculate the resitance locally for Red - Violet - Green - Brown
            double rootValue = 27 * 100000;
            double resistanceMin = rootValue * (.99);
            double resistanceMax = rootValue * (1.01);
            string resistanceLocal = resistanceMin.ToString() + " - " + resistanceMax.ToString();

            // calculate the resistance from the service by their values Red(2) - Violet(7) - Green(100000) - Brown(.01)
            string resistanceService = service.CalculateResistance("2", "7", 100000, .01);

            // Assert
            Assert.AreEqual(resistanceLocal, resistanceService);
        }
    }
}
