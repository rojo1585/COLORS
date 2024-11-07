using COLORS.Models;

namespace COLORS.Modules;

public class ColorInstruction(string color, ColorValue left, ColorValue right, string? variableName = null)
{
    public string Color { get; set; } = color;
    public ColorValue LeftOperand { get; set; } = left;
    public ColorValue RightOperand { get; set; } = right;
    public string? VariableName { get; set; } = variableName;
}
