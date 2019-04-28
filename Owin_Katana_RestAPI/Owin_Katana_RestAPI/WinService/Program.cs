using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Runner>(s =>
                {
                    s.ConstructUsing(name => new Runner());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription(string.Format("Owin self hosted api ENV: {0}", ConfigurationManager.AppSettings["Env"]));
            });
        }
    }
}
