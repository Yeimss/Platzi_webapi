namespace webapi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "HelloWorld";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
