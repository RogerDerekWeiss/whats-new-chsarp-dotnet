namespace WebApp.KeyedServices.Services;

public class EmailService: IEmailService
{
    public void Notify(string message)
    {
        Console.WriteLine("EmailService: " + message);
    }
}

public interface IEmailService: INotifyService
{
}