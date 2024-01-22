using System.Text.RegularExpressions;

namespace GPL.Utilities
{
    /// <summary>
    /// Manages loop conditions for loops.
    /// </summary>
    public class LoopConditionManager
    {
        /// <summary>
        /// Processes the specified condition and evaluates the result.
        /// </summary>
        /// <param name="condition">The condition to process.</param>
        /// <returns>True if the condition is satisfied; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the condition is invalid or contains unsupported operators.</exception>
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

        /// <summary>
        /// Processes the specified operand, either extracting a constant value or checking a variable value.
        /// </summary>
        /// <param name="operand">The operand to process.</param>
        /// <returns>The processed operand value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the operand is invalid.</exception>
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
