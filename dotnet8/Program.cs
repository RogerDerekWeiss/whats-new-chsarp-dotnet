var ur1 = new UserRecord("John", "Smith");
var ur2 = new UserRecord("John", "Smith");


Console.WriteLine($"are records equal {ur1 == ur2}");

var upc1 = new UserPrimaryConstructor("Sally", "Jones");
var upc2 = new UserPrimaryConstructor("Sally", "Jones");

Console.WriteLine($"are classes equal {upc1 == upc2}");

var us1 = new UserStruct("Bob", "Green");
var us2 = new UserStruct("Bob", "Green");

Console.WriteLine($"are structs equal {us1 == us2}"); // Need equalty operator overload

public class UserExplicitConstructor
{
    public UserExplicitConstructor(string userName, string fullName)
    {
        UserName = userName;
        FullName = fullName;
    }
    
    public string UserName { get; }
    public string FullName { get; }
}

// See https://sharplab.io/#v2:EYLgtghglgdgPgAQMwAIECYUFUDOBTAJwAoEBGABhQDMBXAGzoDkIw8AaFWAFxQgHM8AShQBYAFABvcShlpU3FAEEBElAK4BuFPk0oAvigC8vARumzkaCigBi9JizxGAfNXvNWZsXvHigA==

public class UserPrimaryConstructor(string userName, string fullName)
{
    public string UserName { get; } = userName;
    public string FullName { get; } = fullName;
}

public record UserRecord(string UserName, string FullName);

public struct UserStruct(string UserName, string FullName)
{
    public static bool operator ==(UserStruct us1, UserStruct us2) 
    {
        return us1.Equals(us2);
    }

    public static bool operator !=(UserStruct us1, UserStruct us2) 
    {
        return !us1.Equals(us2);
    }
}


