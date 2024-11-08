using COLORS.Models;

namespace COLORS.Commads.Interface;

public interface IColorCommand
{
    ContainerValue Execute(List<ContainerValue> instruction);
}
