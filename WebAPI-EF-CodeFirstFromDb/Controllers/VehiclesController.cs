namespace WebAPI_EF_CodeFirstFromDb.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using WebAPI_EF_CodeFirstFromDb.Models;
    using WebAPI_EF_CodeFirstFromDb.Service;

    public class VehiclesController : ApiController
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        public IQueryable<Vehicle> GetVehicles()
        {
            return this.vehicleService.GetAll();
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            Vehicle vehicle = this.vehicleService.Get(id);
            if (vehicle == null)
            {
                return this.NotFound();
            }

            return this.Ok(vehicle);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != vehicle.Id)
            {
                return this.BadRequest();
            }

            this.vehicleService.Edit(vehicle);

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.vehicleService.Add(vehicle);

            return this.CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = this.vehicleService.Get(id);
            if (vehicle == null)
            {
                return this.NotFound();
            }

            this.vehicleService.Delete(vehicle);

            return this.Ok(vehicle);
        }
    }
}