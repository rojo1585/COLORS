using COLORS.Helpers;
using COLORS.Models;

namespace COLORS.Modules
{
    public static class ColorParser
    {

        public static List<ColorInstruction> Parse(string colorCode)
        {
            var currentCommandName = string.Empty;
            bool continueCommand = false;
            bool continueVariableValue = false;
            string CurrenVariableName = string.Empty;
            List<ContainerValue> commandValues = [];
            var instructions = new List<ColorInstruction>();
            var tokens = colorCode.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (IsEndInstruction(token))
                {
                    continueCommand = false;
                    continueVariableValue = false;
                    commandValues.Clear();
                    instructions.Add(new ColorInstruction(currentCommandName, commandValues, CurrenVariableName));
                }
                else if (Literals.TryGetCastColor(token, out string cast))
                {
                    currentCommandName = cast;
                    continueCommand = true;
                    continue;
                }
                else if (IsVariableDefinition(token.ToUpper()) && !continueCommand)
                {
                    continueVariableValue = true;
                    CurrenVariableName = token.ToUpper();
                    continue;
                }

                if (continueVariableValue)
                {
                    ContainerValue value = ParseValue(token, CurrenVariableName);
                    StoregeManager.Variables.TryAdd(CurrenVariableName, value);
                    continue;
                }
                if (IsVariableAssignment(token))
                {
                    continue;
                }
                if (continueCommand)
                {
                    commandValues.Add(ParseValue(token, currentCommandName));
                }
            }
            instructions.Add(new ColorInstruction(currentCommandName, commandValues, CurrenVariableName));
            return instructions;
        }

        private static ContainerValue ParseValue(string value, string? Name)
        {
            if (decimal.TryParse(value, out decimal number))
            {
                return new ContainerValue(Name, number, number.GetType());
            }
            else if (StoregeManager.Variables.TryGetValue(value, out var variable))
            {
                return variable;
            }
            else
            {
                return new ContainerValue(Name, value, value.GetType());
            }
        }

        private static bool IsVariableDefinition(string token)
        {
            return token.StartsWith('@');
        }

        private static bool IsVariableAssignment(string token)
        {
            return token.StartsWith('=');
        }
        private static bool IsEndInstruction(string token)
        {
            return token.StartsWith(';') || token.StartsWith(',');
        }
    }
}
