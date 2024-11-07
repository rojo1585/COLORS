using COLORS.Commads;
using COLORS.Commads.Interface;
using COLORS.Models;

namespace COLORS.Modules;

internal class ColorInterpreter
{
    private readonly Dictionary<string, ColorValue> variables;
    private readonly Dictionary<string, IColorCommand> commands;

    public ColorInterpreter()
    {
        variables = [];
        commands = new Dictionary<string, IColorCommand>
            {
                { "RED", new RedCommand() }
            };
    }

    public void Execute(List<ColorInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            if (commands.TryGetValue(instruction.Color, out var command))
            {
                var result = command.Execute(instruction.LeftOperand, instruction.RightOperand);
                Console.WriteLine($"Resultado de {instruction.Color}: {result.Number}");

                if (!string.IsNullOrEmpty(instruction.VariableName))
                {
                    variables[instruction.VariableName] = result;
                }
            }
        }
    }

    public ColorValue GetVariable(string name)
    {
        return variables.TryGetValue(name, out var value) ? value : new ColorValue(0, "GRAY");
    }
}
