namespace WebApp.KeyedServices.Services;

public class SmsService: ISmsService
{
    public void Notify(string message)
    {
        Console.WriteLine("SmsService: " + message);
    }
}

public interface ISmsService : INotifyService
{
}
