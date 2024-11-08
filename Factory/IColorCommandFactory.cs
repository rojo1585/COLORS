using COLORS.Commads.Interface;

namespace COLORS.Factory
{
    public interface IColorCommandFactory
    {
        IColorCommand CreateCommand(string color);
    }
}
