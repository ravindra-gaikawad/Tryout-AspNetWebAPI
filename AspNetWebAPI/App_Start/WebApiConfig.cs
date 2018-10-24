using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AspNetWebAPI
{
    /// <summary>
    /// Reference: https://docs.microsoft.com/en-us/aspnet/web-api/
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Attribute routing.
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "Root",
                routeTemplate: "api/root/{controller}/{id}",
                defaults: new { controller = "stem", id = RouteParameter.Optional },
                constraints: new { id = @"\d+" }
            );

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
