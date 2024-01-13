namespace GPL.Commands
{
    /// <summary>
    /// Represents a command interface that defines the Execute method for graphics operations.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the provided Graphics object.
        /// </summary>
        /// <param name="g">The Graphics object on which the command will be executed.</param>
        void Execute(Graphics g);
    }
}
