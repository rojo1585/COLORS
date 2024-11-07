namespace COLORS.Models;

public static class Literals
{
    public enum Color
    {
        Red,
        Blue
    }

    private static Dictionary<Color, string> colorsDescriptions = new()
    {
        { Color.Red , "RED" }
    };

    public static Dictionary<Color, string> GetColorsDescriptions()
    {
        return colorsDescriptions;
    }
    public static class ErrorMessages
    {
        public static string NotCommandFound { get; set; } = "Not Color Command exist";
    }

}
