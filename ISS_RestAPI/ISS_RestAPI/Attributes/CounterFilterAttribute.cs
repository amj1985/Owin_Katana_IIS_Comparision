using ISS_RestAPI.Manager;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ISS_RestAPI.Attributes
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
            Trace.WriteLine($"TOTAL: {ComparerManager.Instance.Counter.Total}");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}