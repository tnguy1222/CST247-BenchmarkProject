using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CLC247_BenchMarkProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Bible", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Bible", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SearchByPhrase",
                url: "SearchByPhrase",
                defaults: new { controller = "Bible", action = "SearchByPhrase", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OnSearch",
                url: "OnSearch",
                defaults: new { controller = "Bible", action = "OnSearch", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OnSearchByPhrase",
                url: "OnSearchByPhrase",
                defaults: new { controller = "Bible", action = "OnSearchByPhrase", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
