using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Showcase
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //RouteTable.Routes.Remove(RouteTable.Routes["Admin"]);

            routes.MapRoute(
                name: "Post",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Blog", action = "Post", title = UrlParameter.Optional },
                namespaces: new string[] { "Showcase.Controllers" }
            );

            routes.MapRoute(
                name: "Blog",
                url: "{controller}/{action}",
                defaults: new { controller = "Blog", action = "Index" },
                namespaces: new string[] { "Showcase.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Showcase.Controllers" }
            );
        }
    }
}
