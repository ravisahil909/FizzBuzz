using FizzBuzzAPI.Services.Interfaces;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzServiceFactory: IFizzBuzzServiceFactory
    {
        public IFizzBuzzService GetFizzBuzzService()
        {         
            return new FizzBuzzService();
        }
    }
}
