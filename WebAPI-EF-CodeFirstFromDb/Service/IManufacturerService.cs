namespace WebAPI_EF_CodeFirstFromDb.Service
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using WebAPI_EF_CodeFirstFromDb.Models;

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
