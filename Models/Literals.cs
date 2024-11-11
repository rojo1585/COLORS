namespace COLORS.Models;

public static class Literals
{
    public enum Color
    {
        Red,
        Blue
    }

    private static readonly Dictionary<Color, string> colorsDescriptions = new()
    {
        { Color.Red , "RED" },
        { Color.Blue, "BLUE"}
    };
    public static readonly List<List<string>> ColorsVariants = [
        ["BLUE", "Blue", "blue","AZUL","Azul", "azul"],
        ["RED", "Red", "red","ROJO","Rojo", "rojo"]
        ];
    public static Dictionary<Color, string> GetColorsDescriptions()
    {
        return colorsDescriptions;
    }
    public static class ErrorMessages
    {
        public static string NotCommandFound { get; set; } = "Not Color Command exist";
    }

    public static bool TryGetCastColor(string color, out string cast)
    {

        cast = color.ToUpper() switch
        {
            "AZUL" or "BLUE" => "BLUE",
            "ROJO" or "RED" => "RED",
            "AMARILLO" or "YELLOW" => "YELLOW",
            _ => ""
        };

        return !string.IsNullOrEmpty(cast);
    }

}
