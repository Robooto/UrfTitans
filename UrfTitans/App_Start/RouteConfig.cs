using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrfTitans.Controllers;

namespace UrfTitans
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] { typeof(HomeController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" }, namespaces);

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" }, namespaces);

            routes.MapRoute("MostPlayed", "MostPlayed", new { controller = "Home", action = "MostPlayed" }, namespaces);

            routes.MapRoute("MostBanned", "MostBanned", new { controller = "Home", action = "MostBanned" }, namespaces);

            routes.MapRoute("Champ", "champ/{id}", new { controller = "Home", action = "Champ" }, namespaces);
        }
    }
}
