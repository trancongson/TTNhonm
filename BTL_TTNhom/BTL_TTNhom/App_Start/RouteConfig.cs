﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_TTNhom
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "CartItem", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_TTNhom.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "CartItem", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_TTNhom.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "CartItem", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_TTNhom.Controllers" }
            );
        }
    }
}
