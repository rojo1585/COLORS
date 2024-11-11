namespace COLORS.Models;

public static class Literals
{
    public enum Color
    {
        Red,
        Blue,
        Yellow
    }

    private static readonly Dictionary<Color, string> colorsDescriptions = new()
    {
        { Color.Red , "RED" },
        { Color.Blue, "BLUE"},
        { Color.Yellow, "YELLOW"}
    };
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
