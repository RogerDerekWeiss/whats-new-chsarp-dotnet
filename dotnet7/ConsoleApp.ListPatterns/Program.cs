int[] data = { 1, 2, 3 };

Console.WriteLine(data is [1, 2, 3]);
Console.WriteLine(data is [1, 2]);
Console.WriteLine(data is [1, 2, _]);  // Note discard symbol
Console.WriteLine(data is [1, 2, > 2]); // Note greater than operator 
Console.WriteLine(data is [0 or 1, <= 2, > 3]); // Note logical operators 





