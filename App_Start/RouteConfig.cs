using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //enable attribute routing
            routes.MapMvcAttributeRoutes();

            //MapRoute can overload, in this example we use three arguments (or 4 if you include the optional paramter constraints)
            //1. string name, 2. the url to hit, 3. the controller to be called upon hit, and 4. the constraints. In this case we are saying we want year to ONLY be accept 
            //with 2015 or 2016 and month should be two digits
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action ="ByReleaseDate"},
            //    new { year = @"2015|2016", month = @"\d{2}"}
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
