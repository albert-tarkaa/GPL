namespace GPL.Commands
{
    public class CommandParser
    {

        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands(Graphics g)
        {
            try
            {
                if (commands != null && commands.Count > 0)
                {
                    foreach (var command in commands)
                    {
                        command.Execute(g);
                    }
                    commands.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing commands: {ex.Message}");
            }
            
        }
    }
}
