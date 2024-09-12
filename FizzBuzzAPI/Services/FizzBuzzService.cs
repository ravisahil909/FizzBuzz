using FizzBuzzAPI.Services.Interfaces;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzService: IFizzBuzzService
    {
        public string Process(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            return $"Divided {number} by 3 and 5";
        }

        public string ProcessInvalidItem()
        {
            return "Invalid item";
        }
    }
}
