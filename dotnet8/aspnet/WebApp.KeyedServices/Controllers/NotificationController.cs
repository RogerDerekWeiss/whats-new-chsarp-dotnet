using Microsoft.AspNetCore.Mvc;
using WebApp.KeyedServices.Services;

namespace WebApp.KeyedServices.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController: ControllerBase
{
    private readonly IEnumerable<INotifyService> _services;

    public NotificationController(IServiceProvider serviceProvider)
    {
        _services = serviceProvider.GetKeyedServices<INotifyService>("notify");
    }
    
    [HttpGet("GetAllServices")]
    public IAsyncResult GetAllServices(string message)
    {
        foreach (var service in _services)
        {
            service.Notify($"{message} via {service.GetType().Name}");
        }
        
        return Task.CompletedTask;
    }
    
    [HttpGet("GetKafkaService")]
    public IAsyncResult GetKafkaService([FromKeyedServices("kafka")] IKafkaService kafkaService, string message)
    {
        kafkaService.Notify($"{message} via {kafkaService.GetType().Name}");
        
        return Task.CompletedTask;
    }
}