Console.WriteLine($"Using .NET {System.Environment.Version}");

const string body = "Hello World!";

var htmlWithInterpolation = $$"""
            <html lang=\"en-us\">
              {not part of string interpolation}
              <body>
                {{body}}  
              </body>
            </element>
          """;

Console.WriteLine(htmlWithInterpolation);          