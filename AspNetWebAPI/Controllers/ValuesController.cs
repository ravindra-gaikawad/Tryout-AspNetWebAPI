using AspNetWebAPI.ActionResults;
using AspNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace AspNetWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // NOTE: Run GET methods one by one.

        public void Post()
        {
            // returns an empty HTTP response with status code 204(No Content)
        }

        /*
        public HttpResponseMessage GetContent()
        {
            // Web API converts the return value directly into an HTTP response message

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }
        */

        /*
        public HttpResponseMessage GetDomainModel()
        {
            // Web API uses a media formatter to write the serialized model into the response body

            // Get a list of products from a database.
            IEnumerable<Item> products = GetItemsFromDB();

            // Write the list to the response body.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
            return response;
        }
        */

        /*
        public IHttpActionResult GetTextResult()
        {
            // Web API calls the ExecuteAsync method to create an HttpResponseMessage. Then it converts the HttpResponseMessage into an HTTP response message

            return new TextResult("hello", Request);
        }
        */

        /*    
        public IHttpActionResult GetActionResult(int id)
        {
        // The ApiController class defines helper methods that return these built-in action results.
        
        Item product = GetItemsFromDB().ToList<Item>().Find(x => x.Id == id);
        if (product == null)
        {
            return NotFound(); // Returns a NotFoundResult
        }
        return Ok(product);  // Returns an OkNegotiatedContentResult
        }
        */
                
        public IEnumerable<Item> Get()
        {
            // For all other return types, Web API uses a media formatter to serialize the return value.

            return GetItemsFromDB();
        }
        
        private IEnumerable<Item> GetItemsFromDB()
        {
            return new Item[]
           {
            new Item { Id = 1, Title = "Compass Jeep", Category = "Buy"},
            new Item { Id = 2, Title = "MBA", Category = "Education"},
            new Item { Id = 3, Title = "WeightGain", Category = "Health"}
           };
        }
    }
}
