using COLORS.Modules;
using COLORS.Modules.Interface;
using COLORS.UI.Interfaces;

namespace COLORS.UI;

public class ColorProgramUI(IInterpeter _interpreter) : IUI
{
    public void Start()
    {
        while (true)
        {
            try
            {
                Console.Write("\n🎨 COLOR> ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("SALIR", StringComparison.CurrentCultureIgnoreCase))
                    break;

                var instructions = ColorParser.Parse(input);
                Console.WriteLine("\nEjecutando programa:");
                Console.WriteLine("----------------------------------------");
                _interpreter.Execute(instructions);
                Console.WriteLine("----------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
            }
        }

        Console.WriteLine("\n¡Gracias por usar COLOR! ¡Hasta pronto! 👋");
    }
}
