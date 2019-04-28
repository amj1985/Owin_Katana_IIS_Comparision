using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WinService.Configuration
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                c.SingleApiVersion("v1", "Owin self hosted restapi")
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
