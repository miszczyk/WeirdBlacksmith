using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeirdBlacksmith
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // MY ROUTES
            routes.IgnoreRoute("{resource}.png/{*pathInfo}");
            routes.IgnoreRoute("{resource}.jpg/{*pathInfo}");

            routes.MapRoute(
              name: "MyCollection",
              url: "see-my-treasures",
              defaults: new { controller = "Home", action = "MyWeapons", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Changepassword",
              url: "forgot-my-secret-password",
              defaults: new { controller = "Manage", action = "ChangePassword", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Account",
              url: "my-info",
              defaults: new { controller = "Home", action = "AccountMenu", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "Forge",
               url: "forge-your-weapon",
               defaults: new { controller = "Home", action = "Forge", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Collection",
              url: "watch-weapons-collection",
              defaults: new { controller = "Home", action = "Collection", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Registration",
              url: "join-the-forge",
              defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Login",
              url: "enter-the-forge",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "NotLogged",
             url: "you-cant-forge-now",
             defaults: new { controller = "Home", action = "NotLoggedIn", id = UrlParameter.Optional }
         );


            // my routes - end
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
