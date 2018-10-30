using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_EF_CodeFirstFromDb.Models;
using WebAPI_EF_CodeFirstFromDb.Service;
using WebAPI_EF_CodeFirstFromDb.UoW;

namespace WebAPI_EF_CodeFirstFromDb.Controllers
{
    public class VehiclesController : ApiController
    {
        private readonly IVehicleService vehicleService;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IVehicleService vehicleService,IUnitOfWork unitOfWork)
        {
            this.vehicleService = vehicleService;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Vehicles
        public IQueryable<Vehicle> GetVehicles()
        {
            return vehicleService.GetAll();
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> GetVehicle(int id)
        {
            Vehicle vehicle = vehicleService.Get(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            vehicleService.Edit(vehicle);
            unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vehicleService.Add(vehicle);
            unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public async Task<IHttpActionResult> DeleteVehicle(int id)
        {
            Vehicle vehicle = vehicleService.Get(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            vehicleService.Delete(vehicle);
            unitOfWork.Complete();

            return Ok(vehicle);
        }
    }
}