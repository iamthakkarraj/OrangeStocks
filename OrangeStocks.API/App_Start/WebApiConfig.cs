﻿using Swashbuckle.Application;
using System.Web.Http;

namespace OrangeStocks.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
              name: "swagger_root",
              routeTemplate: "",
              defaults: null,
              constraints: null,
              handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));

        }
    }
}
