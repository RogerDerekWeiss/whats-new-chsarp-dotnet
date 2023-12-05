using ConsoleApp.ConcurrentWorkerServiceStartup;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<HostOptions>(options =>
{
     options.ServicesStartConcurrently = true;
     options.ServicesStopConcurrently = true;
});

builder.Services.AddHostedService<Worker1>();
builder.Services.AddHostedService<Worker2>();

var host = builder.Build();
host.Run();