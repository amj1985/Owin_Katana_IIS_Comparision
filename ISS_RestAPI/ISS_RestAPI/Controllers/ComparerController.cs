using ISS_RestAPI.Attributes;
using ISS_RestAPI.Manager;
using System.Threading.Tasks;
using System.Web.Http;

namespace ISS_RestAPI.Controllers
{
    public class ComparerController : ApiController
    {
        public ComparerController()
        {

        }     
        // GET: api/test
        /// <summary>
        /// Register new call via action filter (asynchronous mode)
        /// </summary>
        /// <returns></returns>
        [CounterFilterAttribute]
        [HttpGet]
        [Route("api/test")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok();
        }
        /// <summary>
        /// Register new call via action filter (synchronous mode)
        /// </summary>
        /// <returns></returns>
        [CounterFilterAttributeSynchronous]
        [HttpGet]
        [Route("api/testsync")]
        public IHttpActionResult GetSync()
        {
            return Ok();
        }
        /// <summary>
        /// Get results
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/results")]
        public async Task<IHttpActionResult> GetResults()
        {
            return Ok(ComparerManager.Instance.Counter);
        }
        /// <summary>
        /// Reset comparer manager
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/reset")]
        public async Task<IHttpActionResult> Reset()
        {
            ComparerManager.Instance.Initialize();
            return Ok();
        }
    }
}
