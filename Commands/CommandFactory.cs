using System.Text.RegularExpressions;

namespace GPL.Commands
{
    public class CommandFactory
    {
        string commandItem { get; set; }
        public PictureBox GPLPanel { get; }
        readonly CordinatesStateManager stateManager;
        public CommandParser CommandParser;
        public Bitmap canvas;

        public CommandFactory(string CommandItem, PictureBox gPLPanel, CordinatesStateManager cordinatesStateManager, Bitmap bitmap)
        {
            this.commandItem = CommandItem;
            CommandParser = new CommandParser();
            this.GPLPanel = gPLPanel;
            this.stateManager = cordinatesStateManager;
            this.canvas = bitmap;
        }

        public ICommand CreateCommand()
        {
            if (string.IsNullOrEmpty(commandItem))
            {
                throw new ArgumentException($"'{nameof(commandItem)}' cannot be null or empty.", nameof(commandItem));
            }

            try
            {
                Match drawToMatch = Regex.Match(commandItem, @"drawto\((\d+), (\d+)\)");
                Match moveToMatch = Regex.Match(commandItem, @"moveto\((\d+), (\d+)\)");
                Match rectMatch = Regex.Match(commandItem, @"rect\((\d+), (\d+)\)");
                Match trigMatch = Regex.Match(commandItem, @"trig\((\d+), (\d+)\)");
                Match circleMatch = Regex.Match(commandItem, @"^circle\((\d+)\)$");

                if (drawToMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandItem, @"drawto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandItem, @"drawto\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand drawToCommand = new DrawTo(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(drawToCommand);
                    return new DrawTo(targetX, targetY, stateManager);
                }
                else if (moveToMatch.Success)
                {
                    // Match match = Regex.Match(commandText, @"MoveTo\((\d+), (\d+)\)");
                    int targetX = int.Parse(Regex.Match(commandItem, @"moveto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandItem, @"moveto\((\d+), (\d+)\)").Groups[2].Value);

                    //ICommand moveToCommand = new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);
                    //CommandParser.AddCommand(moveToCommand);
                    return new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);

                }
                else if (rectMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandItem, @"rect\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandItem, @"rect\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand rectCommand = new RectangleCommand(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(rectCommand);
                    return new RectangleCommand(targetX, targetY, stateManager);
                }
                else if (trigMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandItem, @"trig\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandItem, @"trig\((\d+), (\d+)\)").Groups[2].Value);

                    // ICommand triangleCommand = new TriangleCommand(targetX, targetY, stateManager);
                    // CommandParser.AddCommand(triangleCommand);
                    return new TriangleCommand(targetX, targetY, stateManager);
                }
                else if (circleMatch.Success)
                {
                    int radius = int.Parse(Regex.Match(commandItem, @"circle\((\d+)\)").Groups[1].Value);

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


    }
}
