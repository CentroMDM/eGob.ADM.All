using DllToken;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MDM.eGob.ADM.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            var URLOrigins = ConfigurationManager.AppSettings["URLOriginsCors"];
            var cors = new EnableCorsAttribute(
              origins: URLOrigins, headers: "*", methods: "*" //,
                );

            config.EnableCors(cors); //Habilitamos Cors

            config.MessageHandlers.Add(new TokenValidationHandler());


            config.Formatters.Add(config.Formatters.JsonFormatter);


            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"/*/{id}",*/
                //defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
