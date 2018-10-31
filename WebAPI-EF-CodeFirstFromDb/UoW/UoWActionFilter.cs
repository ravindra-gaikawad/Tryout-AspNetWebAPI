namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Autofac.Integration.WebApi;

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
                    this.unitOfWork.CommitTransaction();
                    System.Diagnostics.Debug.WriteLine("UoW Committed");
                }
                else
                {
                    try
                    {
                        this.unitOfWork.RollbackTransaction();
                        System.Diagnostics.Debug.WriteLine("UoW Rollback");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            return Task.FromResult(0);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine("UoW Begin");
            this.unitOfWork.BeginTransaction();
            return Task.FromResult(0);
        }
    }
}