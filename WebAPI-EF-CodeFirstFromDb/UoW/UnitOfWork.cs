using System;
using System.Collections.Generic;
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
        EFContext context = new EFContext();
        Repository.Repository repository;

        private static readonly UnitOfWork instance = new UnitOfWork();
        // Explicit static constructor to tell C# compiler  
        // not to mark type as beforefieldinit  
        static UnitOfWork()
        {
        }
        private UnitOfWork()
        {
        }
        public static UnitOfWork Instance
        {
            get
            {
                return instance;
            }
        }

        public Repository.Repository Repository
        {
            get
            {

                if (this.repository == null)
                {
                    this.repository = new Repository.Repository(context);
                }
                return repository;
            }
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

        public void Complete()
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