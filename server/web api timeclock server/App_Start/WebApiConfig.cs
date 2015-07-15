using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace web_api_timeclock_server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Allow CORS
            config.EnableCors();


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "TestRoute",
                routeTemplate: "api/tests/{action}",
                defaults: new { request = "info", controller = "tests" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
