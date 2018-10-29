using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_EF_CodeFirstFromDb.Models;

namespace WebAPI_EF_CodeFirstFromDb.Service
{
    interface IVehicleService
    {
        Vehicle Get(int id);
        IQueryable<Vehicle> GetAll();
        void Add(Vehicle entity);
        void Delete(Vehicle entity);
        void Edit(Vehicle entity);
    }
}