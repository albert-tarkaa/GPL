using System.Collections.Generic;
using System.Drawing;

namespace GPL.Commands
{
    /// <summary>
    /// Parses and executes a collection of commands.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// The list of commands to be executed.
        /// </summary>
        public List<ICommand> Commands = new List<ICommand>();

        /// <summary>
        /// Adds a command to the list for execution.
        /// </summary>
        /// <param name="command">The command to add.</param>
        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }

        /// <summary>
        /// Executes all added commands here.
        /// </summary>
        /// <param name="g">The graphics context for command execution.</param>
        public void ExecuteCommands(Graphics g)
        {
            try
            {
                if (Commands != null && Commands.Count > 0)
                {
                    foreach (var command in Commands)
                    {
                        command.Execute(g);
                    }
                    Commands.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing commands: {ex.Message}");
            }
        }
    }
}
