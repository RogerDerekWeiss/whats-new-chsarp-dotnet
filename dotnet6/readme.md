# Whats new in .NET 6 / C# 10 

## File-scoped namespaces

```csharp
namespace MyNamespace;  // file scoped namespace        
```

## Global using directives

```csharp
global using System;  // global using directive
```

## Property deconstructors

```csharp
public class Person {
  public string Name { get; set; } = "John";
  public string Surname { get; set; } = "Doe";
}
```

```csharp
// Usage
var person = new Person();
var (name, surname) = person;
```
