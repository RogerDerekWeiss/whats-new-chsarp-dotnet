using System.Net;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const int TimeWindowInSeconds = 10;

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(policyName: "fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = 2;
        limiterOptions.Window = TimeSpan.FromSeconds(TimeWindowInSeconds);
        // Optional Queue for requests that exceed the limit
        limiterOptions.QueueLimit = 1;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    options.OnRejected = async (context, _) =>
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests; // (429) // not the default ServiceUnavailable (503) 
        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later!!!.");
    };
});

  
    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter(); 
app.UseAuthorization();
app.MapControllers();

app.Run();
