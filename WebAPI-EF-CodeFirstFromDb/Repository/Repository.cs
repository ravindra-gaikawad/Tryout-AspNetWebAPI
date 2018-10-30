using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;

namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    public class Repository: IDisposable, IRepository
    {
        private EFContext context = new EFContext();
       
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

        public void Save()
        {
            
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
            context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Edit<T>(T entity) where T : BaseEntity
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}