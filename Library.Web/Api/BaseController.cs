using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Web.Api
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage ModelError()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, 
                new { Errors = ModelState.Values
                    .SelectMany(m => m.Errors.Select(e => e.ErrorMessage)) });
        }
    }
}