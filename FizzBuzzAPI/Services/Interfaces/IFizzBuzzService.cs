namespace FizzBuzzAPI.Services.Interfaces
{
    public interface IFizzBuzzService
    {
        string Process(int number);
        string ProcessInvalidItem();
    }
}
