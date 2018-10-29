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
        Repository.Repository repository = new Repository.Repository();

        public VehicleService()
        {

        }

        public void Add(Vehicle entity)
        {
            repository.Add(entity);
        }

        public void Delete(Vehicle entity)
        {
            repository.Delete(entity);
        }

        public void Edit(Vehicle entity)
        {
            repository.Edit(entity);
        }

        public Vehicle Get(int id)
        {
            return repository.Get(id);
        }

        public IQueryable<Vehicle> GetAll()
        {
            return repository.GetAll();
        }
    }
}