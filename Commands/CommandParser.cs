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
            if (commands != null && commands.Count > 0)
            {
                foreach (var command in commands)
                {
                    command.Execute(g);
                }
              //  commands.Clear();
            }
        }
    }
}
