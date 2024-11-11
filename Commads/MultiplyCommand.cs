using COLORS.Commads.Interface;
using COLORS.Models;

namespace COLORS.Commads;

public class MultiplyCommand : IColorCommand
{
    public ContainerValue Execute(List<ContainerValue> instruction)
    {
        decimal result = 1;
        foreach (var item in instruction)
        {
            result *= (decimal)item.Value;
        }
        return new ContainerValue(Helpers.CommandsHelper.TryGetColor(Literals.Color.Blue), result);
    }
}
