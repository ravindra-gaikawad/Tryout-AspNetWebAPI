using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.UoW;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    public class ManufacturerService : IManufacturerService
    {
        public void Add(Manufacturer entity)
        {
            UnitOfWork.Instance.Repository.Add<Manufacturer>(entity);
        }

        public void Delete(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        public Manufacturer Find<T>(Expression<Func<Manufacturer, bool>> predicate)
        {
            var queryable =  UnitOfWork.Instance.Repository.GetAll<Manufacturer>();
            return queryable.Where(predicate).ToList().FirstOrDefault();
        }

        public Manufacturer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Manufacturer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}