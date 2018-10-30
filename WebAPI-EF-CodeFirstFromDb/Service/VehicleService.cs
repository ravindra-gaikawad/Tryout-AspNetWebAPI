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
        private readonly IUnitOfWork unitOfWork;

        public VehicleService(IManufacturerService manufacturerService, IUnitOfWork unitOfWork)
        {
            this.manufacturerService = manufacturerService;
            this.unitOfWork = unitOfWork;
        }

        void IVehicleService.Add(Vehicle entity)
        {
            Manufacturer manufacturer = manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                manufacturerService.Add(new Manufacturer()
                { ManufacturerName = entity.Manufacturer });
            }

            unitOfWork.Repository.Add<Vehicle>(entity);
        }

        void IVehicleService.Delete(Vehicle entity)
        {
            unitOfWork.Repository.Delete<Vehicle>(entity);
        }

        void IVehicleService.Edit(Vehicle entity)
        {
            Manufacturer manufacturer = manufacturerService.Find<Manufacturer>(x => x.ManufacturerName == entity.Manufacturer);

            if (manufacturer == null)
            {
                manufacturerService.Add(new Manufacturer()
                { ManufacturerName = entity.Manufacturer });
            }

            unitOfWork.Repository.Edit<Vehicle>(entity);
        }

        Vehicle IVehicleService.Find<T>(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Vehicle IVehicleService.Get(int id)
        {
            return unitOfWork.Repository.Get<Vehicle>(id);
        }

        IQueryable<Vehicle> IVehicleService.GetAll()
        {
            return unitOfWork.Repository.GetAll<Vehicle>();
        }
    }
}