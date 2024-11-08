using COLORS.Commads.Interface;
using COLORS.Models;

namespace COLORS.Commads;

public class SumCommand : IColorCommand
{
    public ContainerValue Execute(List<ContainerValue> instruction)
    {
        return new ContainerValue(Helpers.CommandsHelper.TryGetColor(Literals.Color.Red), instruction.Sum(i => (decimal)i.Value));
    }
}
