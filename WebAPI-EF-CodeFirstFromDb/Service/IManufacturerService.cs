using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI_EF_CodeFirstFromDb.Models;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    public interface IManufacturerService
    {
        Manufacturer Get(int id);
        Manufacturer Find<T>(Expression<Func<Manufacturer, bool>> predicate);
        IQueryable<Manufacturer> GetAll();
        void Add(Manufacturer entity);
        void Delete(Manufacturer entity);
        void Edit(Manufacturer entity);
    }
}
