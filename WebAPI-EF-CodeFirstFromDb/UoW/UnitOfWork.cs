namespace WebAPI_EF_CodeFirstFromDb.UoW
{
    using System;
    using System.Data.Entity;
    using WebAPI_EF_CodeFirstFromDb.Repository;

    // References:
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    // https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/
    // https://techbrij.com/generic-repository-unit-of-work-entity-framework-unit-testing-asp-net-mvc
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext context;
        private DbContextTransaction transaction;
        private bool disposed = false;

        public UnitOfWork(IRepository repository, DbContext context)
        {
            this.context = context;
        }

        void IUnitOfWork.BeginTransaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        void IUnitOfWork.CommitTransaction()
        {
            if (this.transaction == null)
            {
                return;
            }

            this.context.SaveChanges();
            this.transaction.Commit();

            this.transaction = null;
        }

        void IUnitOfWork.RollbackTransaction()
        {
            if (this.transaction == null)
            {
                return;
            }

            this.transaction.Rollback();

            this.transaction = null;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}