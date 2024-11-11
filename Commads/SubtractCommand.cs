using COLORS.Commads.Interface;
using COLORS.Models;

namespace COLORS.Commads;

public class SubtractCommand : IColorCommand
{
    public ContainerValue Execute(List<ContainerValue> instruction)
    {
        decimal result = -1;
        foreach (var item in instruction.Select(i => i.Value))
        {
            if (result is -1)
                result = (decimal)item;
            else
                result -= (decimal)item;
        }

        return new ContainerValue(Helpers.CommandsHelper.TryGetColor(Literals.Color.Yellow), result);
    }
}
