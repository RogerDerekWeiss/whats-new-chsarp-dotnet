Console.WriteLine($"Using .NET {System.Environment.Version}");

var unsortedArray = new[] { 77, 13, 19 }; 

// Before C# 10
var sortedArrayAscLegacy = unsortedArray.OrderBy(x => x);
var sortedArrayDescLegacy = unsortedArray.OrderByDescending(x => x);
// After in C11
var sortedArrayAsc = unsortedArray.Order();  // defaults by the primary type
var sortedArrayDesc = unsortedArray.OrderDescending();

