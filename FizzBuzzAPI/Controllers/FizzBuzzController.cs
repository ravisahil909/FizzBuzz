using FizzBuzzAPI.Services;
using FizzBuzzAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzServiceFactory _fizzBuzzServiceFactory;

        public FizzBuzzController(IFizzBuzzServiceFactory fizzBuzzServiceFactory)
        {
            _fizzBuzzServiceFactory = fizzBuzzServiceFactory;
        }

        [HttpPost]
        public IActionResult ProcessNumbers([FromBody] List<object> values)
        {
            var fizzBuzzService = _fizzBuzzServiceFactory.GetFizzBuzzService();
            

            var result = new List<string>();

            foreach (var value in values)
            {
                if (int.TryParse(value.ToString(), out int number))
                {
                    result.Add(fizzBuzzService.Process(number));
                }
                else
                {
                    result.Add(fizzBuzzService.ProcessInvalidItem());
                }
            }

            return Ok(result);
        }

    }
}
