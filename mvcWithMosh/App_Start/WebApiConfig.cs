using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace mvcWithMosh
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var settings =  config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //for api paramerters to be camelCase.
            settings.Formatting = Formatting.Indented;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}