# What's new in .NET 7 / C# 11

## New Data Types

> TimeOnly

> DateOnly


Nano and Microseconds in DateTime Constructors

```csharp
var dateTimeWithMicroSeconds = new DateTime(2023, 12, 31, 23, 59, 59, 500, 987); // with 987 Micro seconds
Console.WriteLine($"Date With micro seconds:  {dateTimeWithMicroSeconds:yyyy-MM-dd HH:mm:ss.ffffff}");
Console.WriteLine($"Date micro second part:  {dateTimeWithMicroSeconds.Microsecond}");
Console.WriteLine($"Date nano second part:  {dateTimeWithMicroSeconds.Nanosecond}");

```

# New Linq Sort Methods

```csharp
// Before C# 10
var sortedArrayAscLegacy = unsortedArray.OrderBy(x => x);
var sortedArrayDescLegacy = unsortedArray.OrderByDescending(x => x);
// After in C11
var sortedArrayAsc = unsortedArray.Order();  // defaults by the primary type
var sortedArrayDesc = unsortedArray.OrderDescending();

```

## Required members

```csharp
public class Person {
  public Person() {}

  [SetsRequiredMembers] // Without this, the required members will cause compiler error
  public Person(string name, string surname)
  {     
    Name = name; 
    Surname = surname;
  }

  public Guid Id { get; set; } = Guid. NewGuid(); 
  public required string Name { get; set; }   // Must be set via object initializer
  public required string Surname { get; set; } // Must be set via object initializer
}
```

## Raw String Literals

```csharp
// Number of dollar signs matches the string interpolation level (curly braces)
var htmlWithInterpolation = $$"""
            <html lang="en-us">  <-- {note the double quotes inside teh string -->
              {not part of string interpolation}
              <body>
                {{body}}  
              </body>
            </html>
          """;
```

## Generic Attributes

### Before, prior to C# 11

```csharp

class MyType 
{ }

class MyAttribute : Attribute
{
  private Type type;
  
  public MyAttribute(Type type)
  {
    _type = type;
  }
}

[MyAttribute(typeof(MyType))] 
class Myclass {}
```

#### Now in C# 11

```csharp

class MyType
{ }

class GenericAttribute<T> : Attribute
  where T : MyType
{
  private T _type;
}

[GenericAttribute<MyType>] 
class MyClass
{ }

```

# ASP.NET 

> A lot of work done on minimal apis, but not covered here.

## Rate Limiting

### Rate Limiting Algorithms

- **Fixed Window** : Limits the number of requests per time window. When the time window expires, a new time window starts.  *eg 20 requests per minute*
- **Sliding Window**: Limits the number of requests per time window, but the window slides with each request, discarding old requests. *eg 20 requests per minute, but the window slides with each request*
- **Token Bucket**: Limits the number of requests per available tokens that can be used per time period. each request will consume a token, doesn't care how quickly they are consumed. *eg 100 requests per minute,  can use them all over 10 seconds*  
- **Concurrency**: Limits the number of concurrent requests.  Does not cap the number of requests  per period. eg *20 concurrent requests*  

### Create your own

```csharp
{
    public class RedisSlidingWindowRateLimiter<TKey> : RateLimiter
    {
        ..
        ..
        
    }
```
or goto github project: [cristipufu/aspnetcore-redis-rate-limiting](https://github.com/cristipufu/aspnetcore-redis-rate-limiting/tree/master)


### Note
- Can chain multiple rate limiters
- Customize the response message

#### Declare the Rate Limiting options in the Program.cs / Startup.cs

```csharp

// Add Rate Limiter policies
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(policyName: "fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = 2;
        limiterOptions.Window = TimeSpan.FromSeconds(10);
        // Optional Queue for requests that exceed the limit
        limiterOptions.QueueLimit = 1;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

//Rate limiter middleware
app.UseRateLimiter();
```
#### Add the Rate Limiter with the policy name to the controller

```csharp
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class ProductsController : ControllerBase
    {
    }
```

## Output Caching


#### Declare
```csharp
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(policy => policy
        .Expire(TimeSpan.FromMinutes(10)));4
        
    options.AddPolicy("ProductsPolicy", policy => policy
        .Expire(TimeSpan.FromHours(1));
    
    options.AddPolicy("UserPolicy", policy => policy
        .Expire(TimeSpan.FromMinutes(5)));    
}  
var app = builder.Build();
app.UseOutputCache();
```

#### Add the Output Cache with the policy name to the controller

> Note: Does not work on authenticated endpoints 😭

```csharp
    [Route("api/[controller]")]
    [ApiController]
    [EnableOutputCaching("ProductsPolicy")]
    public class ProductsController : ControllerBase
    {
    }
```
#### Or add the attribute to the method

```csharp
    
[Route("api/[controller]")]
[Route("api/people")]
public class UserController : ControllerBase
    {
       
        [HttpGet]
        [OutputCache(PolicyName = "UserPolicy")]
        public ActionResult<List<User>> Get()
        {
            return Ok(users);
        }
 }
}    
```

## Request Decompression Middleware

Allows endpoints to accept requests that have compressed content.
Leverages the Content-Encoding HTTP header to determine the compression algorithm used.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRequestDecompression();
var app = builder.Build();

app.UseRequestDecompression();
```
