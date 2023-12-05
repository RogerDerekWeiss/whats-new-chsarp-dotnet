var date = new DateTime(2023, 11, 11);

DisplayDate(ref date);
Console.WriteLine($"Outer Date: {date:dddd dd MMM yyy}");

void DisplayDate(ref readonly DateTime date) // ref readonly
{
    Console.WriteLine($"Inner Date: {date:dddd dd MMM yyy}");
    // date = date.AddDays(1); // compiler won't allow this to be set
}