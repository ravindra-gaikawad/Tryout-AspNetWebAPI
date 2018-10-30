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
        void IManufacturerService.Add(Manufacturer entity)
        {
            UnitOfWork.Instance.Repository.Add<Manufacturer>(entity);
        }

        void IManufacturerService.Delete(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        void IManufacturerService.Edit(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        Manufacturer IManufacturerService.Find<T>(Expression<Func<Manufacturer, bool>> predicate)
        {
            var queryable = UnitOfWork.Instance.Repository.GetAll<Manufacturer>();
            return queryable.Where(predicate).ToList().FirstOrDefault();
        }

        Manufacturer IManufacturerService.Get(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<Manufacturer> IManufacturerService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}