﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WEB_API_CRUD_Logics
{
    /// <summary>
    /// Reference: https://www.c-sharpcorner.com/article/asp-net-web-api-crud-logics-using-entity-framework-without-writing-single-code/
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));
        }
    }
}
