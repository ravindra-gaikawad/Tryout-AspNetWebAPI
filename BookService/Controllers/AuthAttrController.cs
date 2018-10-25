using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookService.Controllers
{
    /// <summary>
    /// you can restrict the controller, by using the [AllowAnonymous]
    /// </summary>
    [Authorize]
    public class AuthAttrController : ApiController
    {
        // GET: api/AuthAttr
        /// <summary>
        /// you can restrict the controller and then allow anonymous access to specific actions, by using the [AllowAnonymous]
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AuthAttr/5
        /// <summary>
        /// You can also limit access to specific users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Users = "Alice,Bob")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AuthAttr
        /// <summary>
        /// You can also limit access to users in specific roles
        /// </summary>
        /// <param name="value"></param>
        [Authorize(Roles = "Administrators")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AuthAttr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AuthAttr/5
        /// <summary>
        /// Authorization Inside a Controller Action
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (User.IsInRole("Administrators"))
            {
                // 
            }
        }
    }
}
