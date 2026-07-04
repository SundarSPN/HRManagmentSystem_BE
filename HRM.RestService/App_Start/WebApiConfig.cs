using BusinessLogicLayer;
using HRM.RestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;
using LoggerLayer;

namespace Model.RestService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            container.RegisterType<IMasterBL, MasterBL>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeBL, EmployeeBL>(new HierarchicalLifetimeManager());
            container.RegisterSingleton<ILogger, Logger>();
            config.DependencyResolver = new UnityResolver(container);


            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
