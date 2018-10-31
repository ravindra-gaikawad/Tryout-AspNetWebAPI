namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAPI_EF_CodeFirstFromDb.Models;

    public class Repository : IDisposable, IRepository
    {
        private DbContext context;
        private bool disposed = false;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get<T>(int id)
            where T : BaseEntity
        {
            return this.context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll<T>()
            where T : BaseEntity
        {
            return this.context.Set<T>().AsQueryable();
        }

        public void Add<T>(T entity)
            where T : BaseEntity
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity)
            where T : BaseEntity
        {
            this.context.Set<T>().Remove(entity);
        }

        public void Edit<T>(T entity)
            where T : BaseEntity
        {
            this.context.Set<T>().AddOrUpdate(entity);
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