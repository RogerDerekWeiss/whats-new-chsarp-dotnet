Console.WriteLine($"Using .NET {System.Environment.Version}");

DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine("DateOnly: " + dateOnly);

TimeOnly timeOnly = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
Console.WriteLine("TimeOnly: " + timeOnly);


var dateTimeWithMicroSeconds = new DateTime(2023, 12, 31, 23, 59, 59, 500, 987); // with 987 Micro seconds
Console.WriteLine($"Date With micro seconds:  {dateTimeWithMicroSeconds:yyyy-MM-dd HH:mm:ss.ffffff}");
Console.WriteLine($"Date micro second part:  {dateTimeWithMicroSeconds.Microsecond}");
Console.WriteLine($"Date nano second part:  {dateTimeWithMicroSeconds.Nanosecond}");


