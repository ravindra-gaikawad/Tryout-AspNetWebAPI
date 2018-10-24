using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookService.ExceptionHandlers
{
    public class ExceptionHandlerContext
    {
        public ExceptionContext ExceptionContext { get; set; }
        public IHttpActionResult Result { get; set; }
    }
}