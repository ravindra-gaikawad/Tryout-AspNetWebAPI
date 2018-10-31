namespace WebAPI_EF_CodeFirstFromDb.Service
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using WebAPI_EF_CodeFirstFromDb.Models;
    using WebAPI_EF_CodeFirstFromDb.Repository;

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
            Manufacturer manufacturer = this.manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                this.manufacturerService.Add(
                    new Manufacturer()
                    {
                        ManufacturerName = entity.Manufacturer
                    });
            }

            this.repository.Add<Vehicle>(entity);
        }

        void IVehicleService.Delete(Vehicle entity)
        {
            this.repository.Delete<Vehicle>(entity);
        }

        void IVehicleService.Edit(Vehicle entity)
        {
            Manufacturer manufacturer = this.manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                this.manufacturerService.Add(
                    new Manufacturer()
                    {
                        ManufacturerName = entity.Manufacturer
                    });
            }

            this.repository.Edit<Vehicle>(entity);
        }

        Vehicle IVehicleService.Find<T>(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Vehicle IVehicleService.Get(int id)
        {
            return this.repository.Get<Vehicle>(id);
        }

        IQueryable<Vehicle> IVehicleService.GetAll()
        {
            return this.repository.GetAll<Vehicle>();
        }
    }
}