using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_dealershipWebAPI.Controllers;
using car_dealershipWebAPI.Models;
using car_dealershipWebAPI.Repos;

namespace car_dealershipWebAPI.Tests.Controllers
{
    [TestClass]
    public class VehicleControllerTest
    {
        private IVehicleRepository _vehicleRepository;

        [TestMethod]
        public void Get()
        {
            _vehicleRepository = new VehicleRepository();
            // Arrange
            var controller = new VehicleController(_vehicleRepository);

            // Act
            var result = controller.Get();
            var vehicles = result as OkNegotiatedContentResult<IEnumerable<Vehicle>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(9, vehicles.Content.Count());
            Assert.AreEqual("59d2698c2eaefb1268b69ee5", vehicles.Content.ElementAt(0)._id);
            Assert.AreEqual("59d2698c05889e0b23959106", vehicles.Content.ElementAt(1)._id);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            _vehicleRepository = new VehicleRepository();
            // Arrange
            var controller = new VehicleController(_vehicleRepository);

            // Act
            var result = controller.Get("59d2698c2eaefb1268b69ee5");
            var vehicle = result as OkNegotiatedContentResult<Vehicle>;

            // Assert
            Assert.AreEqual("Chevy", vehicle.Content.make);
        }

    }
}
