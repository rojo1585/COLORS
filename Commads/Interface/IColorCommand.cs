using COLORS.Models;

namespace COLORS.Commads.Interface;

public interface IColorCommand
{
    ColorValue Execute(ColorValue left, ColorValue right);
}
