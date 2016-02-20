using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			//routes.IgnoreRoute("{html}", new { html = @".*\.htm(.*)?" });
			//routes.IgnoreRoute("Docs");
			//routes.IgnoreRoute("Home/Contact");

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Docs", "Docs/{param}", new { controller = "Docs", action = "Index" });
			routes.MapRoute("binding", "Binding/{action}", new { controller = "Binding", action = "Index" });
			routes.MapRoute("home", "{action}", new { controller = "Home" });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}