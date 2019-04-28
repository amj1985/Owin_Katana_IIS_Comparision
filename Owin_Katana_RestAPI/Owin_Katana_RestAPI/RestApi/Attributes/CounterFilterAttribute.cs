using RestApi.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestApi.Attributes
{
    public class CounterFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            _stopwatch = Stopwatch.StartNew();
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _stopwatch.Stop();
            ComparerManager.Instance.Update(_stopwatch.ElapsedMilliseconds);
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}
