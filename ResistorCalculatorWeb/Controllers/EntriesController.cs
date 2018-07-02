using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResistorCalculatorWeb.Data;
using ResistorCalculatorWeb.Models;

namespace ResistorCalculatorWeb.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;
        private BandsRepository _bandsRepository = null;

        // Entries constructor w/declared entries list for Home page
        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
            _bandsRepository = new BandsRepository();
        }

        // Home page
        public ActionResult ViewDelete(int? id)
        {
            // delete the entry if an id value is provided
            if (id != null)
                _entriesRepository.DeleteEntry(id.GetValueOrDefault(0));

            // get the list entries for the index page list
            List<Entry> entries = _entriesRepository.GetEntries();

            // delete entry if id is provided
            return View(entries);
        }

        // Add Entry page
        public ActionResult AddEdit(int? id)
        {
            // get the defined band specifications for the add page band color selections
            List<Band> bands = _bandsRepository.GetBands();

            // check if it is an Add or and Edit
            if (id == null)
            {
                ViewBag.Title = "Add Entry";
                ViewData["ID"] = 0;
                ViewData["Date"] = DateTime.Now.ToString("yyyy-MM-dd");
                ViewData["BandColor1ID"] = 0;
                ViewData["BandColor2ID"] = 0;
                ViewData["BandColor3ID"] = 0;
                ViewData["BandColor4ID"] = 0;
                ViewData["Resistance"] = "";
                ViewData["Notes"] = "";
            }
            else
            {
                ViewBag.Title = "Edit Entry";
                Entry entry = _entriesRepository.GetEntry(id.GetValueOrDefault(0));
                if (entry != null)
                {
                    ViewData["ID"] = entry.ID;
                    ViewData["Date"] = entry.EntryData.Date.ToString("yyyy-MM-dd");
                    ViewData["BandColor1ID"] = entry.EntryData.BandColor1ID;
                    ViewData["BandColor2ID"] = entry.EntryData.BandColor2ID;
                    ViewData["BandColor3ID"] = entry.EntryData.BandColor3ID;
                    ViewData["BandColor4ID"] = entry.EntryData.BandColor4ID;
                    ViewData["Resistance"] = entry.EntryData.Resistance;
                    ViewData["Notes"] = entry.EntryData.Notes.Replace("@@","\r\n");
                }
            }

            return View(bands);
        }

        // Add Entry post method
        [ActionName("AddEdit"),HttpPost]
        public ActionResult AddEditPost(string id, string date, string band1, string band2, string band3, string band4, string notes)
        {
            // seperate the defined values for each band from their ids
            int band1ID = Convert.ToInt32(band1.Split('|')[0]);
            int band2ID = Convert.ToInt32(band2.Split('|')[0]);
            int band3ID = Convert.ToInt32(band3.Split('|')[0]);
            int band4ID = Convert.ToInt32(band4.Split('|')[0]);
            string first = band1.Split('|')[1];
            string second = band2.Split('|')[1];
            double multiplier = Convert.ToDouble(band3.Split('|')[1]);
            double tolerance = Convert.ToDouble(band4.Split('|')[1]);

            // calculate the resistance and its range from the tolerance
            ResistorCalculatorService.ResistorCalculatorServiceClient service = new ResistorCalculatorService.ResistorCalculatorServiceClient();
            var resistance = service.CalculateResistance(first, second, multiplier, tolerance);

            // check if this is for an existing entry and therefore and update not an add
            Entry entry = new Entry(Convert.ToInt32(id), Convert.ToDateTime(date), band1ID, band2ID, band3ID, band4ID, resistance, notes);
            if (Convert.ToInt32(id) > 0)
                _entriesRepository.UpdateEntry(entry);
            else
                _entriesRepository.AddEntry(entry);

            return RedirectToAction("ViewDelete");
        }
    }
}