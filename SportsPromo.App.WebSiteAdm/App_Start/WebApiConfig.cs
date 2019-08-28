using SportsPromo.App.WebSiteAdm.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Unity.AspNet.Mvc;


namespace SportsPromo.App.WebSiteAdm
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.DependencyResolver = new DependencyResolver(UnityConfig.Container); ;
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApiPut",
                routeTemplate: "api/{controller}/put/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiGet",
                routeTemplate: "api/{controller}/get/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiList",
                routeTemplate: "api/{controller}/{action}/{page}/{sort}/{direction}",
                defaults: new { page = 1, sort = RouteParameter.Optional, direction = RouteParameter.Optional }
            );
            /*config.Routes.MapHttpRoute(
                name: "DefaultApiList2",
                routeTemplate: "api/{controller}/{action}"
            );*/


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
