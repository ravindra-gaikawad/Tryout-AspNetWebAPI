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
    // https://techbrij.com/generic-repository-unit-of-work-entity-framework-unit-testing-asp-net-mvc
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext context;
        private DbContextTransaction transaction;

        public IRepository Repository { get; set; }

        public UnitOfWork(IRepository repository, DbContext context)
        {
            Repository = repository;
            this.context = context;
        }

        void IUnitOfWork.BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        void IUnitOfWork.CommitTransaction()
        {
            if (transaction == null)
                return;

            context.SaveChanges();
            transaction.Commit();

            transaction = null;
        }

        void IUnitOfWork.RollbackTransaction()
        {
            if (transaction == null)
                return;

            transaction.Rollback();

            transaction = null;
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