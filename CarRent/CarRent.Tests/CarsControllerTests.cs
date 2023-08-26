using CarRent.Controllers;
using CarRent.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarRent.Tests
{
    [TestClass]
    public class CarsControllerTests
    {
        [TestMethod]
        public async Task Index_ReturnsViewWithCars()
        {
            // Arrange
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.GetAll())
                           .ReturnsAsync(new List<Car>
                           {
                           new Car { Id = 1, Brand = "Toyota" },
                           new Car { Id = 2, Brand = "Honda" }
                           });

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            var model = viewResult.Model as IEnumerable<Car>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count()); // Assuming 2 cars in the mock data
        }

        [TestMethod]
        public async Task Filter_ReturnsFilteredView_WhenSearchStringIsNotEmpty()
        {
            // Arrange
            var searchString = "Toyota";
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.GetAll())
                           .ReturnsAsync(new List<Car>
                           {
                               new Car { Id = 1, Brand = "Toyota", ModelType = "Camry" },
                               new Car { Id = 2, Brand = "Honda", ModelType = "Civic" }
                           });

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = await controller.Filter(searchString);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            var model = viewResult.Model as List<Car>;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count);
            Assert.AreEqual("Toyota", model[0].Brand);
        }

        [TestMethod]
        public async Task Filter_ReturnsOriginalView_WhenSearchStringIsEmpty()
        {
            // Arrange
            var searchString = ""; // Empty search string
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.GetAll())
                           .ReturnsAsync(new List<Car>
                           {
                               new Car { Id = 1, Brand = "Toyota", ModelType = "Camry" },
                               new Car { Id = 2, Brand = "Honda", ModelType = "Civic" }
                           });

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = await controller.Filter(searchString);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            var model = viewResult.Model as List<Car>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count); // Both cars should be in the result
        }

        [TestMethod]
        public async Task Details_ReturnsViewWithCarDetails_WhenCarExists()
        {
            // Arrange
            var carId = 1;
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.GetByIdAsync(carId))
                           .ReturnsAsync(new Car { Id = carId, Brand = "Toyota", ModelType = "Camry" });

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = await controller.Details(carId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            var model = viewResult.Model as Car;
            Assert.IsNotNull(model);
            Assert.AreEqual(carId, model.Id);
            Assert.AreEqual("Toyota", model.Brand);
            Assert.AreEqual("Camry", model.ModelType);
        }

        [TestMethod]
        public async Task Details_ReturnsViewWithNoCar_WhenCarDoesNotExist()
        {
            // Arrange
            var carId = 1; // Assuming car doesn't exist
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.GetByIdAsync(carId))
                           .ReturnsAsync((Car)null);

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = await controller.Details(carId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsNull(viewResult.Model);
        }

        [TestMethod]
        public void DetailsRemove_DeletesCarAndRedirectsToIndex()
        {
            // Arrange
            var carId = 1;
            var mockCarsService = new Mock<ICarsService>();
            mockCarsService.Setup(service => service.Delete(carId));

            var controller = new CarsController(mockCarsService.Object);

            // Act
            var result = controller.DetailsRemove(carId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
    }
}
