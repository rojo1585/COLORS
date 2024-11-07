using COLORS.Commads.Interface;
using COLORS.Models;

namespace COLORS.Commads;

public class RedCommand : IColorCommand
{
    public ColorValue Execute(ColorValue left, ColorValue right)
    {
        return new ColorValue(left.Number + right.Number, Helpers.CommandsHelper.TryGetColor(Literals.Color.Red));
    }
}
