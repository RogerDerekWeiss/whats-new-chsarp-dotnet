using System.Diagnostics;
using System.Text.Json;
using SharedProject;
using Console = SharedProject.ConsoleHelper;

const string filePath = "large-file.json";
var json = FileHelper.ReadFileContents(filePath);

Console.WriteLine($"Framework Version: {Environment.Version}", ConsoleColor.Blue);
Console.WriteLine($"{filePath} file size: {FileHelper.GetFileSize(filePath)}", ConsoleColor.Yellow);

var sw = Stopwatch.StartNew();
//TODO: Replace Object with your own class type
var objectClass = JsonSerializer.Deserialize<Object>(json); 
sw.Stop();

Console.WriteLine($"ElapsedTime: {sw.ElapsedMilliseconds} ms");