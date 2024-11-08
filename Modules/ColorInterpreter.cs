using COLORS.Factory;
using COLORS.Helpers;
using COLORS.Models;
using COLORS.Modules.Interface;

namespace COLORS.Modules;

public class ColorInterpreter(IColorCommandFactory _commandFactory) : IInterpeter
{
    public void Execute(List<ColorInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            if (!string.IsNullOrEmpty(instruction.VariableName) && StoregeManager.Variables.TryGetValue(instruction.VariableName, out ContainerValue? value))
                instruction.Operands.Add(value);

            var command = _commandFactory.CreateCommand(instruction.Color);
            var result = command.Execute(instruction.Operands);

            if (result is { })
                Console.WriteLine($"Resultado de {instruction.Color}: {result.Value}");
        }
    }
}
