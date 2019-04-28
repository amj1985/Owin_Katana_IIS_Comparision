using ISS_RestAPI.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ISS_RestAPI.Attributes
{
    public class CounterFilterAttributeSynchronous : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _stopwatch = Stopwatch.StartNew();
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _stopwatch.Stop();
            ComparerManager.Instance.Update(_stopwatch.ElapsedMilliseconds);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}