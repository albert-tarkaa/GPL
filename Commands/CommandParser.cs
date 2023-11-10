namespace GPL.Commands
{
    public class CommandParser
    {

        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands(Graphics g, bool fill = false, Color color = default)
        {
            if (commands.Count > 0 || commands != null)
            {
                foreach (var command in commands)
                {
                    command.Execute(g, fill, color);
                }
                commands.Clear();
            }
        }
    }
}
