using System.Drawing;

var legacyPalette = new Color[] { Color.Bisque, Color.LemonChiffon, Color.Lavender }; 

Color[] lightPalette = [Color.Orange, Color.Pink, Color.White];
Color[] darkPalette = [Color.Brown, Color.DarkRed, Color.Black];

Color[] mixedPalette = [
    .. lightPalette,  // using the spread operator
    Color.Chocolate,
    .. darkPalette];

foreach (var color in mixedPalette)
{
    Console.WriteLine(color.Name);
}