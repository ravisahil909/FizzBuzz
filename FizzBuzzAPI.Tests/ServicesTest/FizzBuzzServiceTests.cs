using FizzBuzzAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzAPI.Tests.ServicesTest
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _service;

        [SetUp]
        public void Setup()
        {
            _service = new FizzBuzzService();
        }

        // Parameterized test for numbers divisible by 3 (Fizz)
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void Process_ReturnsFizz_ForMultiplesOfThree(int number)
        {
            var result = _service.Process(number);
            Assert.AreEqual("Fizz", result);
        }

        // Parameterized test for numbers divisible by 5 (Buzz)
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        public void Process_ReturnsBuzz_ForMultiplesOfFive(int number)
        {
            var result = _service.Process(number);
            Assert.AreEqual("Buzz", result);
        }

        // Parameterized test for numbers divisible by both 3 and 5 (FizzBuzz)
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void Process_ReturnsFizzBuzz_ForMultiplesOfThreeAndFive(int number)
        {
            var result = _service.Process(number);
            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void ProcessInvalidItem_ReturnsInvalidItem()
        {
            var result = _service.ProcessInvalidItem();
            Assert.AreEqual("Invalid item", result);
        }
    }
}
