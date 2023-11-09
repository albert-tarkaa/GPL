using System.Text.RegularExpressions;

namespace GPL.Commands
{
    public class CommandFactory
    {
        string CommandItem { get; set; }
        public PictureBox GPLPanel { get; }
        private readonly CordinatesStateManager stateManager;
        public CommandParser CommandParser { get; }
        private readonly Bitmap canvas;

        public CommandFactory(string commandItem, PictureBox gPLPanel, CordinatesStateManager cordinatesStateManager, Bitmap bitmap)
        {
            this.CommandItem = commandItem ?? throw new ArgumentNullException($"'{nameof(CommandItem)}' cannot be null or empty.", nameof(CommandItem));
            CommandParser = new CommandParser();
            this.GPLPanel = gPLPanel;
            this.stateManager = cordinatesStateManager;
            this.canvas = bitmap;
        }

        public ICommand CreateCommand(string CommandItem)
        {
            if (string.IsNullOrEmpty(CommandItem))
            {
                throw new ArgumentNullException($"'{nameof(CommandItem)}' cannot be null or empty.", nameof(CommandItem));
            }

            try
            {
                Match drawToMatch = Regex.Match(CommandItem, @"drawto\((\d+), (\d+)\)");
                Match moveToMatch = Regex.Match(CommandItem, @"moveto\((\d+), (\d+)\)");
                Match rectMatch = Regex.Match(CommandItem, @"rect\((\d+), (\d+)\)");
                Match trigMatch = Regex.Match(CommandItem, @"trig\((\d+), (\d+)\)");
                Match circleMatch = Regex.Match(CommandItem, @"^circle\((\d+)\)$");

                if (drawToMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"drawto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"drawto\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand drawToCommand = new DrawTo(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(drawToCommand);
                    return new DrawTo(targetX, targetY, stateManager);
                }
                else if (moveToMatch.Success)
                {
                    // Match match = Regex.Match(commandText, @"MoveTo\((\d+), (\d+)\)");
                    int targetX = int.Parse(Regex.Match(CommandItem, @"moveto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"moveto\((\d+), (\d+)\)").Groups[2].Value);

                    //ICommand moveToCommand = new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);
                    //CommandParser.AddCommand(moveToCommand);
                    return new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);

                }
                else if (rectMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"rect\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"rect\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand rectCommand = new RectangleCommand(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(rectCommand);
                    return new RectangleCommand(targetX, targetY, stateManager);
                }
                else if (trigMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"trig\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"trig\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand triangleCommand = new TriangleCommand(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(triangleCommand);
                    return new TriangleCommand(targetX, targetY, stateManager);
                }
                else if (circleMatch.Success)
                {
                    int radius = int.Parse(Regex.Match(CommandItem, @"circle\((\d+)\)").Groups[1].Value);

                    //ICommand circleCommand = new CircleCommand(radius, stateManager);
                    //CommandParser.AddCommand(circleCommand);
                    return new CircleCommand(radius, stateManager);
                }
                throw new InvalidOperationException("Unknown command type");
            }
            catch (Exception)
            {

                throw;

            }
        }

        public void AddCommandFromText(string commandText, CommandParser parser)
        {
            var command = CreateCommand(commandText);
            parser.AddCommand(command);
        }

    }
}
