using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using car_dealershipWebAPI.Models;
using car_dealershipWebAPI.Repos;

namespace car_dealershipWebAPI.Controllers
{
    /// <summary>
    /// Gets Vehicles from Vehicle Inventory JSON file
    /// </summary>
    public class VehicleController : ApiController
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Gets Vehicle by ID
        /// </summary>
        /// <param name="id">id of vehicle</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Vehicles/{id}")]
        [ResponseType(typeof(Vehicle))]
        public virtual IHttpActionResult Get(string id)
        {
            var vehicle = _vehicleRepository.Get(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        /// <summary>
        /// Gets all vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Vehicles")]
        [ResponseType(typeof(IEnumerable<Vehicle>))]
        public virtual IHttpActionResult Get()
        {
            var vehicles = _vehicleRepository.GetAll();
            if (vehicles == null)
            {
                return NotFound();
            }

            return Ok(vehicles);
        }

       
    }
}
