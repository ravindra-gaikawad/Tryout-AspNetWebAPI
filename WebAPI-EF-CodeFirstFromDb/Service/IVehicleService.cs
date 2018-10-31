namespace WebAPI_EF_CodeFirstFromDb.Service
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using WebAPI_EF_CodeFirstFromDb.Models;

    public interface IVehicleService
    {
        Vehicle Get(int id);

        Vehicle Find<T>(Expression<Func<Vehicle, bool>> predicate);

        IQueryable<Vehicle> GetAll();

        void Add(Vehicle entity);

        void Delete(Vehicle entity);

        void Edit(Vehicle entity);
    }
}