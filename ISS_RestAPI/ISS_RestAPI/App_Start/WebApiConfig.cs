using System.Web.Http;
using System.Web.Http.Cors;

namespace ISS_RestAPI
{
    public static class WebApiConfig
    {
        private static EnableCorsAttribute _corsConfiguration = new EnableCorsAttribute("*", "*", "*");
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(_corsConfiguration);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
