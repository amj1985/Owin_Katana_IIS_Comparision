using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinService.Owin;

namespace WinService
{
    public class Runner
    {
        const string ServerAddress = "http://localhost:";
        public string Port { get ; private set; }
        private IDisposable _app;
        public Runner()
        {
            Port = ConfigurationManager.AppSettings["Port"];
        }
        public void Start()
        {
            _app = WebApp.Start<Startup>(new StartOptions($"{ServerAddress}{Port}"));

            if (_app != null)
            {
                Debug.WriteLine(string.Format("Server listening at {0}{1}", ServerAddress, Port));
                Process.Start($"{ServerAddress}{Port}/swagger");
            }
        }

        public void Stop()
        {
            if (_app != null)
            {
                _app.Dispose();
            }
        }
    }
}
