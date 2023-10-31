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
            foreach (var command in commands)
            {
                command.Execute(g);
            }
            commands.Clear(); // Clear executed commands


        }



    }
}
