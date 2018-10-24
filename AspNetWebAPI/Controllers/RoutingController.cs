using AspNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebAPI.Controllers
{
    public class RoutingController : ApiController
    {
        /// <summary>
        /// Instead of using the naming convention for HTTP methods, you can explicitly specify the HTTP method 
        /// for an action by decorating the action method with the HttpGet, HttpPut, HttpPost, or HttpDelete attribute.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]        
        public Item Find(int id)
        {
            return new Item { Id = id, Title = "Compass Jeep", Category = "Buy" };
        }

        /// <summary>
        /// To allow multiple HTTP methods for an action, or to allow HTTP methods other than GET, PUT, POST, and DELETE, 
        /// use the AcceptVerbs attribute, which takes a list of HTTP methods.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("POST", "HEAD")]
        public IHttpActionResult Add()
        {
            return Ok();
        }

        /// <summary>
        /// Routing by Action Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public string Details(int id)
        {
            return $"Received{id}";
        }

        /// <summary>
        /// To prevent a method from getting invoked as an action, use the NonAction attribute
        /// </summary>
        [NonAction]
        public void NonPublic()
        {

        }
    }
}
