using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Repository;
using WebAPI_EF_CodeFirstFromDb.UoW;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    public class VehicleService : IVehicleService
    {
        public VehicleService()
        {

        }

        public void Add(Vehicle entity)
        {
            UnitOfWork.Instance.Repository.Add<Vehicle>(entity);
        }

        public void Delete(Vehicle entity)
        {
            UnitOfWork.Instance.Repository.Delete<Vehicle>(entity);
        }

        public void Edit(Vehicle entity)
        {
            UnitOfWork.Instance.Repository.Edit<Vehicle>(entity);
        }

        public Vehicle Get(int id)
        {
            return UnitOfWork.Instance.Repository.Get<Vehicle>(id);
        }

        public IQueryable<Vehicle> GetAll()
        {
            return UnitOfWork.Instance.Repository.GetAll<Vehicle>();
        }
    }
}