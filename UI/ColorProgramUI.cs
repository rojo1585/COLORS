using COLORS.Modules;

namespace COLORS.UI;

public class ColorProgramUI
{
    private readonly ColorInterpreter interpreter;
    private readonly ColorParser parser;

    public ColorProgramUI()
    {
        interpreter = new ColorInterpreter();
        parser = new ColorParser();
    }

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

                var instructions = parser.Parse(input);
                Console.WriteLine("\nEjecutando programa:");
                Console.WriteLine("----------------------------------------");
                interpreter.Execute(instructions);
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
