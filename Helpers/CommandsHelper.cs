using COLORS.Models;
using static COLORS.Models.Literals;


namespace COLORS.Helpers;

public static class CommandsHelper
{
    private static readonly Dictionary<Color, string> _colorsDescriptions = Literals.GetColorsDescriptions();
    public static string TryGetColor(Color color)
    {
        if (_colorsDescriptions.TryGetValue(color, out string? description))
            return description;

        return ErrorMessages.NotCommandFound;
    }
}
