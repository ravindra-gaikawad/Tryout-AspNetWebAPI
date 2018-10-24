using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.ExceptionHandlers
{
    public class ExceptionLoggerContext
    {
        public ExceptionContext ExceptionContext { get; set; }
        public bool CanBeHandled { get; set; }
    }
}