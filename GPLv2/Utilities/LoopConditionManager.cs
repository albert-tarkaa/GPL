using System.Text.RegularExpressions;

namespace GPL.Utilities
{
    public class LoopConditionManager
    {
        public static bool Process(string condition)
        {
            // Use a regex pattern to extract operands and operator
            Match match = Regex.Match(condition, @"^\s*([a-zA-Z][a-zA-Z0-9]*|[0-9]+)\s*([<>=!]+)\s*([a-zA-Z][a-zA-Z0-9]*|[0-9]+)\s*$");

            if (match.Success)
            {
                string operand1String = match.Groups[1].Value;
                string operatorSymbol = match.Groups[2].Value;
                string operand2String = match.Groups[3].Value;

                int operand1 = ProcessOperand(operand1String);

                int operand2 = ProcessOperand(operand2String);

                switch (operatorSymbol)
                {
                    case "<":
                        return operand1 < operand2;
                    case ">":
                        return operand1 > operand2;
                    case "=":
                        return operand1 == operand2;
                    case "!=":
                        return operand1 != operand2;
                    default:
                        throw new InvalidOperationException("Unsupported operator in while loop condition");
                }
            }

            throw new InvalidOperationException("Invalid while loop condition");
        }

        private static int ProcessOperand(string operand)
        {
            if (int.TryParse(operand, out int operandValue))
            {
                // Operand is a constant
                return operandValue;
            }
            else if (VariableManager.CheckVariable(operand) is int variableValue)
            {
                // Operand is a variable
                return variableValue;
            }
            else
            {
                throw new InvalidOperationException($"Invalid operand in while loop condition: {operand}");
            }
        }
    }

}
