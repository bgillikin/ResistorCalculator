﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ResistorCalculatorWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Entries", action = "ViewDelete", id = null }
                defaults: new { controller = "Entries", action = "ViewDelete", id = UrlParameter.Optional }
            );
        }
    }
}
