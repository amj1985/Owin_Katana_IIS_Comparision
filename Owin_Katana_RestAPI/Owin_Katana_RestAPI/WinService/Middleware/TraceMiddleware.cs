using Microsoft.Owin;
using RestApi.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinService.Middleware
{
    public class TraceMiddleware : OwinMiddleware
    {
        public TraceMiddleware(OwinMiddleware next)
           : base(next)
        {
        }
        public async override Task Invoke(IOwinContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            await Next.Invoke(context);
            stopWatch.Stop();
            if (context.Request.Path.Value.Equals("/api/test"))
            { 
                ComparerManager.Instance.Update(stopWatch.ElapsedMilliseconds);
                Debug.WriteLine(ComparerManager.Instance.Counter.Average);
                Debug.WriteLine(ComparerManager.Instance.Counter.Total);
            }
        }
    }
}
