using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using car_dealershipWebAPI.Models;
using car_dealershipWebAPI.Repos;
using car_dealershipWebAPI.Util;

namespace car_dealershipWebAPI.Repos
{
    public class VehicleRepository : IVehicleRepository
    {
        public Vehicle Get(string id)
        {
            var vehicle = ReadJsonData.Instance.Vehicles.Where(v => id.Contains(v._id)).FirstOrDefault();
            return vehicle;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            var vehicles = ReadJsonData.Instance.Vehicles;
            return vehicles;
        }
    }
}