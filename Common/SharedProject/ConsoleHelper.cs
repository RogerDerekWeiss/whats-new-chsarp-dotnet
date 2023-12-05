
namespace SharedProject
{
    public class ConsoleHelper
    {
        public static void WriteLine(string message, ConsoleColor? color = ConsoleColor.White)
        {
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}