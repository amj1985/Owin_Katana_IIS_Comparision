using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WinService.Extensions;
using WinService.Middleware;

namespace WinService.Owin
{
    public class Startup
    {
        private readonly HttpConfiguration _configuration;
        private Bootstrapper _moduleBootstrapper;
        public Startup()
        {
            _configuration = new HttpConfiguration();
            _moduleBootstrapper = new Bootstrapper();

        }
        public void Configuration(IAppBuilder app)
        {
            _configuration.Formatters.Add(new JsonMediaTypeFormatter());
            _configuration.Formatters
                .JsonFormatter.SerializerSettings.ContractResolver = new CamelCaseExceptDictionaryKeysResolver();
            _configuration.MapHttpAttributeRoutes();
            _configuration.EnableCors();
            _moduleBootstrapper.Run(_configuration);
            // register middleware
            // app.Use(typeof(TraceMiddleware));
            app.UseWebApi(_configuration);
        }
    }
}
