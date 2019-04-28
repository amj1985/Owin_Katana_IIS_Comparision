using Autofac;
using Autofac.Integration.WebApi;
using RestApi.Controllers;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using WinService.Configuration;

namespace WinService
{
    public class Bootstrapper
    {
        private ContainerBuilder builder;

        public void Run(HttpConfiguration configuration)
        {
            this.Initialize(configuration);
        }
        public void Initialize(HttpConfiguration configuration)
        {
            this.CreateContainerBuilder()
                .EnableSwagger(configuration)
                .EnableCors(configuration)
                .RegisterApi(configuration)
                .RegisterServices(configuration);
        }

        public Bootstrapper CreateContainerBuilder()
        {
            builder = new ContainerBuilder();
            return this;
        }
        public Bootstrapper RegisterApi(HttpConfiguration configuration)
        {
            ICollection<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(typeof(ComparerController).Assembly);
            builder.RegisterApiControllers(assemblies.ToArray());

            return this;
        }
        public Bootstrapper EnableCors(HttpConfiguration configuration)
        {

            var cors = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(cors);
            return this;
        }
        public Bootstrapper EnableSwagger(HttpConfiguration configuration)
        {
            if (ConfigurationManager.AppSettings["Env"] != "production")
            {
                SwaggerConfig.Register(configuration);
            }
            return this;
        }
        public Bootstrapper RegisterServices(HttpConfiguration configuration)
        {

            // Register Services;

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return this;
        }
    }
}
