using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;

namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    public class Repository : IDisposable, IRepository
    {
        private EFContext context;

        public Repository(EFContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        public T Get<T>(int id) where T : BaseEntity
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity
        {
            return context.Set<T>().AsQueryable();
        }

        public void Add<T>(T entity) where T : BaseEntity
        {
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            context.Set<T>().Remove(entity);
        }

        public void Edit<T>(T entity) where T : BaseEntity
        {
            context.Set<T>().AddOrUpdate(entity);
        }
    }
}