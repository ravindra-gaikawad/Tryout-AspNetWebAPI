using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Repository;

namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    // References: 
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    // https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext context;

        public IRepository Repository { get; set; }

        public UnitOfWork(IRepository repository, DbContext context)
        {
            Repository = repository;
            this.context = context;
        }

        void IUnitOfWork.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.CommitTransaction()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Complete()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}