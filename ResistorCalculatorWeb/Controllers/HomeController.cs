using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResistorCalculatorWeb.Data;
using ResistorCalculatorWeb.Models;

namespace ResistorCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private BandsRepository _bandsRepository = null;

        // Entries constructor w/declared entries list for Home page
        public HomeController()
        {
            _bandsRepository = new BandsRepository();
        }

        // About dialog
        public ActionResult About()
        {
            // get the defined band specifications for the add page band color selections
            List<Band> bands = _bandsRepository.GetBands();

            return View(bands);
        }

        // Contact information
        public ActionResult Contact()
        {
            return View();
        }
    }
}