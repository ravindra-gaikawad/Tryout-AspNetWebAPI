using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Repository;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    public class VehicleService : IVehicleService
    {
        Repository.Repository repository = new Repository.Repository(new EFContext());

        public VehicleService()
        {

        }

        public void Add(Vehicle entity)
        {
            repository.Add<Vehicle>(entity);
        }

        public void Delete(Vehicle entity)
        {
            repository.Delete<Vehicle>(entity);
        }

        public void Edit(Vehicle entity)
        {
            repository.Edit<Vehicle>(entity);
        }

        public Vehicle Get(int id)
        {
            return repository.Get<Vehicle>(id);
        }

        public IQueryable<Vehicle> GetAll()
        {
            return repository.GetAll<Vehicle>();
        }
    }
}