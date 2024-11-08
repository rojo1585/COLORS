using COLORS.Models;

namespace COLORS.Modules;

public class ColorInstruction(string color, List<ContainerValue> operands, string? variableName = null)
{
    public string Color { get; set; } = color;
    public List<ContainerValue> Operands { get; set; } = operands;
    public string? VariableName { get; set; } = variableName;

    public ColorInstruction(string color, ContainerValue operand1, ContainerValue operand2, string? variableName = null)
        : this(color, [operand1, operand2], variableName)
    {
    }
}