using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    public class UoWActionFilter : IAutofacActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public UoWActionFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine("UnitOfWork: Ending.");

            if (actionExecutedContext == null)
            {
                return Task.FromResult(0);
            }

            try
            {
                if (actionExecutedContext.Exception == null && actionExecutedContext.Response.StatusCode != System.Net.HttpStatusCode.BadRequest)
                {
                    unitOfWork.CommitTransaction();
                    System.Diagnostics.Debug.WriteLine("UoW Committed");
                }
                else
                {
                    try
                    {
                        unitOfWork.RollbackTransaction();
                        System.Diagnostics.Debug.WriteLine("UoW Rollback");
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            finally
            {
                
            }
            
            return Task.FromResult(0);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine("UoW Begin");
            unitOfWork.BeginTransaction();            
            return Task.FromResult(0);
        }
    }
}