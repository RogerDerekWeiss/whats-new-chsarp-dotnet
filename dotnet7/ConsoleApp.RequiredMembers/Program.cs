using System.Diagnostics.CodeAnalysis;

Console.WriteLine($"Using .NET {Environment.Version}");

var p1 = new Person { Name = "John", Surname = "Smith" }; 
//Person p2 = new("John", "Smith");

// Initialization attempts with missing required properties 
var p3 = new Person("John", "Smith");
Person p4 = new("John", "Smith");

public class Person {
    public Person() {}

    [SetsRequiredMembers] 
    public Person(string name, string surname)
    {
        Name = name; 
        Surname = surname;
    }

    public Guid Id { get; set; } = Guid. NewGuid(); 
    public required string Name { get; set; }  // Must be set via object initializer
    public required string Surname { get; set; }
}