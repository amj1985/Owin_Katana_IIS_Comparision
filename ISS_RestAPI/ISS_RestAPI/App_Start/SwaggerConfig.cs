using System.Web.Http;
using WebActivatorEx;
using ISS_RestAPI;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ISS_RestAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\"; ;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                c.SingleApiVersion("v1", "IIS restapi")
                  .Description("A sample API for testing")
                  .Contact(cc => cc
                  .Name("Adria Manzano")
                  .Url("https://github.schibsted.io/adria-manzano/Owin_Katana_IIS_Comparison")
                  .Email("adria.manzano@schibsted.com"));

                c.IncludeXmlComments(commentsFile);

            }).EnableSwaggerUi();
        }
    }
}
