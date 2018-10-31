namespace WebAPI_EF_CodeFirstFromDb.Service
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using WebAPI_EF_CodeFirstFromDb.Models;
    using WebAPI_EF_CodeFirstFromDb.Repository;

    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository repository;

        public ManufacturerService(IRepository repository)
        {
            this.repository = repository;
        }

        void IManufacturerService.Add(Manufacturer entity)
        {
            this.repository.Add<Manufacturer>(entity);
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
            var queryable = this.repository.GetAll<Manufacturer>();
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