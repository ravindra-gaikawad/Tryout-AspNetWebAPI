using AspNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebAPI.Controllers
{
    [RoutePrefix("api/books")]
    public class AttrRoutingController : ApiController
    {
        /// <summary>
        /// GET api/books
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Book> Get()
        {
            return new List<Book>()
            {
                new Book { Id = 1, Title = "Power Of Now", Category = "Motivational"},
                new Book { Id = 2, Title = "Chhawa", Category = "Biography"},
                new Book { Id = 3, Title = "Yugandhar", Category = "Novel"}
            };
        }

        /// <summary>
        /// GET api/books/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        public Book Get(int id)
        {
            return new Book { Id = id, Title = "Power Of Now", Category = "Motivational" };
        }

        /// <summary>
        /// POST api/books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [Route("")]
        public HttpResponseMessage Post(Book book)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new Book { Id = 4, Title = "Power Of Now", Category = "Motivational" });
            return response;
        }

        /// <summary>
        /// Use a tilde (~) on the method attribute to override the route prefix
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [Route("~/api/authors/{authorId:int}/books")]
        public IEnumerable<Book> GetByAuthor(int authorId)
        {
            return new List<Book>()
            {
                new Book { Id = 7, Title = "Chhawa", Category = "Biography"},
                new Book { Id = 26, Title = "Yugandhar", Category = "Novel"}
            };
        }
    }
}
