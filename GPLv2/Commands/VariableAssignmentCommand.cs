using GPL.Utilities;
using System.Text.RegularExpressions;

namespace GPL.Commands
{
    /// <summary>
    /// This is the Variable Assignment Command class
    /// </summary>
    public class VariableAssignmentCommand : ICommand
    {
        public string commandItem;
        readonly DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableAssignmentCommand"/> class.
        /// </summary>
        /// <param name="cordinatesStateManager">The drawing settings manager.</param>
        public VariableAssignmentCommand(string commanditem, DrawingSettings cordinatesStateManager)
        {
            this.commandItem = commanditem;
            this.stateManager = cordinatesStateManager;
        }

        /// <summary>
        /// Executes the variable assignment command.
        /// </summary>
        /// <param name="g">The graphics context for command execution.</param>
        public void Execute(Graphics g)
        {
            ProcessVariableAssignment(commandItem);
        }

        private void ProcessVariableAssignment(string command)
        {
            // Split the command into parts
            string[] commandParts = command.Split('=');
            if (commandParts.Length < 2)
            {
                throw new InvalidOperationException("Syntax error: Invalid variable assignment");
            }

            string commandName = commandParts[0].Trim();
            string commandValue = commandParts[1].Trim();

            // Check if the variable is already declared
            object variableValue = VariableManager.CheckVariable(commandName);

            if (variableValue != null)
            {
                // Check if the initial value is a valid integer
                if (int.TryParse(commandValue, out int initialValue))
                {
                    VariableManager.AssignVariable(commandName, initialValue);
                }
                else if (IsValidManipulationString(commandValue))
                {
                    ProcessVariableManipulation(commandName, commandValue);
                }
                else
                {
                    throw new InvalidOperationException($"Syntax error: Invalid initial value for variable assignment");
                }
            }
            else
            {
                // Variable not declared, declare it and assign the value
                if (int.TryParse(commandValue, out int initialValue))
                {
                    VariableManager.AssignVariable(commandName, initialValue);
                }
                else
                {
                    throw new InvalidOperationException($"Syntax error: Invalid initial value for variable assignment");
                }
            }
        }


        private void ProcessVariableManipulation(string variableName, string manipulationExpression)
        {
            // Split the manipulation expression into parts
            string[] manipulationParts = manipulationExpression.Split(new[] { '+', '-', '*', '/', '%' }, StringSplitOptions.RemoveEmptyEntries);

            if (manipulationParts.Length == 2)
            {
                // If there are two parts, assume it's a valid manipulation expression
                string operatorSymbol = manipulationExpression.Replace(manipulationParts[0], "").Replace(manipulationParts[1], "").Trim();

                int value;
                if (int.TryParse(manipulationParts[1], out value))
                {
                    // Perform the manipulation based on the operator
                    object variableValue = VariableManager.CheckVariable(variableName);
                    if (variableValue != null)
                    {
                        switch (operatorSymbol)
                        {
                            case "+":
                                VariableManager.AssignVariable(variableName, (int)variableValue + value);
                                break;
                            case "-":
                                VariableManager.AssignVariable(variableName, (int)variableValue - value);
                                break;
                            case "*":
                                VariableManager.AssignVariable(variableName, (int)variableValue * value);
                                break;
                            case "/":
                                if (value != 0)
                                {
                                    VariableManager.AssignVariable(variableName, (int)variableValue / value);
                                }
                                else
                                {
                                    throw new InvalidOperationException("Division by zero");
                                }
                                break;
                            case "%":
                                if (value != 0)
                                {
                                    VariableManager.AssignVariable(variableName, (int)variableValue % value);
                                }
                                else
                                {
                                    throw new InvalidOperationException("Modulus by zero");
                                }
                                break;

                            default:
                                throw new InvalidOperationException($"Syntax error: Invalid operator in variable manipulation");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Variable '{variableName}' not declared before manipulation");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Syntax error: Invalid value in variable manipulation");
                }
            }
            else
            {
                throw new InvalidOperationException($"Syntax error: Invalid variable manipulation expression");
            }
        }
        private bool IsValidManipulationString(string value)
        {
            return Regex.IsMatch(value, @"^\s*[a-zA-Z][a-zA-Z0-9]*\s*[\+\-\*/%]\s*\d+\s*$");
        }

    }
}
