namespace WebApp.KeyedServices.Services;

public interface IKafkaService: INotifyService
{
}

public class KakfaService: IKafkaService
{
    public void Notify(string message)
    {
        Console.WriteLine("KakfaService: " + message);
    }
}