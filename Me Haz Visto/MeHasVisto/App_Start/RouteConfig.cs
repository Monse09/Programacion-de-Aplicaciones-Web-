using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MeHasVisto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //instruir de ignorar todo intento al servido de acceder a un recurso(String, imagen)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Es un metodo que permite defirnir un patron de ruta
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}