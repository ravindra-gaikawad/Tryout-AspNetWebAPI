using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookService.Controllers
{
    public class ErrorsController : ApiController
    {
        // GET: api/Errors
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Errors/5
        /// <summary>
        /// The HttpResponseException type is a special case. 
        /// This exception returns any HTTP status code that you specify in the exception constructor. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// For more control over the response, 
        /// you can also construct the entire response message and include it with the HttpResponseException
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
            if (value == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Null value cannot be accepted"),
                    ReasonPhrase = "Data Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }

        /// <summary>
        /// An exception filter is executed when a controller method throws any unhandled exception 
        /// that is not an HttpResponseException exception.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
            throw new AccessViolationException();
        }

        /// <summary>
        /// The HttpError object provides a consistent way to return error information in the response body.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var message = string.Format("Product with id = {0} not found", id);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
        }
    }
}
