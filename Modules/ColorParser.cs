using COLORS.Models;

namespace COLORS.Modules
{
    public class ColorParser
    {
        private readonly Dictionary<string, ColorValue> variables;

        public ColorParser()
        {
            variables = [];
        }

        public List<ColorInstruction> Parse(string colorCode)
        {
            var instructions = new List<ColorInstruction>();
            var tokens = colorCode.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int i = 0;

            while (i < tokens.Length)
            {
                string token = tokens[i];

                if (IsColorCommand(token.ToUpper()))
                {
                    var color = token.ToUpper();
                    ColorValue left = ParseValue(tokens[i + 1]);
                    ColorValue right = ParseValue(tokens[i + 2]);
                    string? variableName = null;

                    if (i + 3 < tokens.Length && IsVariableAssignment(tokens[i + 3]))
                    {
                        variableName = tokens[i + 3].Substring(1);
                        i += 1; // Avanzar después de la asignación de variable
                    }

                    instructions.Add(new ColorInstruction(color, left, right, variableName));
                    i += 3; // Avanzar después de la instrucción completa
                }
                else if (IsVariableDefinition(token))
                {
                    string variableName = token.Substring(1);
                    ColorValue value = ParseValue(tokens[i + 1]);
                    variables[variableName] = value;
                    i += 2; // Avanzar después de la definición de variable
                }
                else
                {
                    throw new ArgumentException($"Token inválido: {token}");
                }
            }

            return instructions;
        }

        private ColorValue ParseValue(string token)
        {
            if (double.TryParse(token, out double number))
            {
                return new ColorValue(number, "GRAY");
            }
            else if (variables.TryGetValue(token, out var variable))
            {
                return variable;
            }
            else
            {
                throw new ArgumentException($"Valor inválido: {token}");
            }
        }

        private static bool IsColorCommand(string token)
        {
            return token switch
            {
                "RED" or "AZUL" or "VERDE" or "AMARILLO" => true,
                _ => false
            };
        }

        private static bool IsVariableDefinition(string token)
        {
            return token.StartsWith('@');
        }

        private static bool IsVariableAssignment(string token)
        {
            return token.StartsWith('=');
        }
    }
}
