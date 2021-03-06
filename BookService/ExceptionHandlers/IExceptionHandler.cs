﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace BookService.ExceptionHandlers
{
    public interface IExceptionHandler
    {
        Task HandleAsync(ExceptionHandlerContext context,
                         CancellationToken cancellationToken);
    }
}