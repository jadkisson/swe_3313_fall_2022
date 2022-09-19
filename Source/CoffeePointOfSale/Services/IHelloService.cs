namespace CoffeePointOfSale.Services;

public interface IHelloService
{
    string SayHello(string message = "Hello, world!");
}

public class HelloService : IHelloService
{
    public string SayHello(string message = "Hello, world!")
    {
        return message;
    }
}