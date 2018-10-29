using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;

namespace WebAPI_EF_CodeFirstFromDb.Repository
{
    public class Repository : IRepository<Vehicle>,IDisposable
    {
        private EFContext context = new EFContext();

        //public Repository(EFContext context)
        //{
        //    this.context = context;
        //}

        public IQueryable<Vehicle> GetAll()
        {
            return context.Vehicles.AsQueryable();
        }

        public Vehicle Get(int id)
        {
            return context.Vehicles.Find(id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            Save();
        }

        public void Delete(Vehicle vehicle)
        {            
            context.Vehicles.Remove(vehicle);
            Save();
        }

        public void Edit(Vehicle vehicle)
        {
            context.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Save()
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