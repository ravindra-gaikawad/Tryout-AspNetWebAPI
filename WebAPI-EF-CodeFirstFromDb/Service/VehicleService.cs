using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Repository;
using WebAPI_EF_CodeFirstFromDb.UoW;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IManufacturerService manufacturerService;
        private readonly IRepository repository;

        public VehicleService(IManufacturerService manufacturerService, IRepository repository)
        {
            this.manufacturerService = manufacturerService;
            this.repository = repository;
        }

        void IVehicleService.Add(Vehicle entity)
        {
            Manufacturer manufacturer = manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                manufacturerService.Add(new Manufacturer()
                { ManufacturerName = entity.Manufacturer });
            }

            repository.Add<Vehicle>(entity);
        }

        void IVehicleService.Delete(Vehicle entity)
        {
            repository.Delete<Vehicle>(entity);
        }

        void IVehicleService.Edit(Vehicle entity)
        {
            Manufacturer manufacturer = manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                manufacturerService.Add(new Manufacturer()
                { ManufacturerName = entity.Manufacturer });
            }

            repository.Edit<Vehicle>(entity);
        }

        Vehicle IVehicleService.Find<T>(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Vehicle IVehicleService.Get(int id)
        {
            return repository.Get<Vehicle>(id);
        }

        IQueryable<Vehicle> IVehicleService.GetAll()
        {
            return repository.GetAll<Vehicle>();
        }
    }
}