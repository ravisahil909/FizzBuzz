using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzAPI.Tests.ControllerTests
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzServiceFactory> _fizzBuzzServiceFactoryMock;
        private Mock<IFizzBuzzService> _fizzBuzzServiceMock;
        private FizzBuzzController _controller;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzzServiceFactoryMock = new Mock<IFizzBuzzServiceFactory>();
            _fizzBuzzServiceMock = new Mock<IFizzBuzzService>();

            // Setup the factory to return the mocked service
            _fizzBuzzServiceFactoryMock.Setup(factory => factory.GetFizzBuzzService())
                .Returns(_fizzBuzzServiceMock.Object);

            // Injecting mocked dependencies into the controller
            _controller = new FizzBuzzController(_fizzBuzzServiceFactoryMock.Object);
        }

        [Test]
        public void ProcessNumbers_ReturnsOkResult_WithValidNumbers()
        {
            // Arrange
            var inputValues = new List<object> { 3, 5, 15 };
            _fizzBuzzServiceMock.Setup(service => service.Process(3)).Returns("Fizz");
            _fizzBuzzServiceMock.Setup(service => service.Process(5)).Returns("Buzz");
            _fizzBuzzServiceMock.Setup(service => service.Process(15)).Returns("FizzBuzz");

            // Act
            var result = _controller.ProcessNumbers(inputValues) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var expectedOutput = new List<string> { "Fizz", "Buzz", "FizzBuzz" };
            CollectionAssert.AreEqual(expectedOutput, (List<string>)result.Value);
        }

        [Test]
        public void ProcessNumbers_ReturnsInvalidItem_ForNonIntegerValues()
        {
            // Arrange
            var inputValues = new List<object> { "abc", 3 };
            _fizzBuzzServiceMock.Setup(service => service.Process(3)).Returns("Fizz");
            _fizzBuzzServiceMock.Setup(service => service.ProcessInvalidItem()).Returns("Invalid item");

            // Act
            var result = _controller.ProcessNumbers(inputValues) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var expectedOutput = new List<string> { "Invalid item", "Fizz" };
            CollectionAssert.AreEqual(expectedOutput, (List<string>)result.Value);
        }

        [Test]
        public void ProcessNumbers_ReturnsEmptyList_WhenInputIsEmpty()
        {
            // Arrange
            var inputValues = new List<object>();

            // Act
            var result = _controller.ProcessNumbers(inputValues) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var expectedOutput = new List<string>();
            CollectionAssert.AreEqual(expectedOutput, (List<string>)result.Value);
        }

        [Test]
        public void ProcessNumbers_CallsServiceFactoryExactlyOnce()
        {
            // Arrange
            var inputValues = new List<object> { 1 };

            // Act
            _controller.ProcessNumbers(inputValues);

            // Assert
            _fizzBuzzServiceFactoryMock.Verify(factory => factory.GetFizzBuzzService(), Times.Once);
        }
    }
}
