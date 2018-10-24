using AspNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebAPI.Controllers
{
    public class StemController : ApiController
    {
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item Get()
        {
            return new Item { Id = 999, Title = "No Id", Category = "Buy" };
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item Get(int id)
        {
            return new Item { Id = id, Title = "Id", Category = "Buy" };
        }
    }
}
