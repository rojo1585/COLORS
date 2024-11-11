using COLORS.Commads;
using COLORS.Commads.Interface;

namespace COLORS.Factory
{
    public class ColorCommandFactory : IColorCommandFactory
    {
        public IColorCommand CreateCommand(string color)
        {
            return color switch
            {
                "RED" => new SumCommand(),
                "BLUE" => new MultiplyCommand(),
                _ => throw new ArgumentException($"Comando de color {color} no reconocido")
            };
        }
    }
}
