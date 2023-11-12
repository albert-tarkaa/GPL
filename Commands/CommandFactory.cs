using GPL.Utilities;
using System.Text.RegularExpressions;

namespace GPL.Commands
{
    public class CommandFactory
    {
        string CommandItem { get; set; }
        public PictureBox GPLPanel { get; }
        private readonly DrawingSettings stateManager;
        public CommandParser CommandParser { get; }
        private readonly Bitmap canvas;

        public CommandFactory(string commandItem, PictureBox gPLPanel, DrawingSettings cordinatesStateManager, Bitmap bitmap)
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
                Match drawToMatch = Regex.Match(CommandItem, @"drawto\s(\d+),\s?(\d+)");
                Match moveToMatch = Regex.Match(CommandItem, @"moveto\s(\d+),\s?(\d+)");
                Match rectMatch = Regex.Match(CommandItem, @"rect\s(\d+),\s?(\d+)");
                Match trigMatch = Regex.Match(CommandItem, @"trig\s(\d+),\s?(\d+)");
                Match circleMatch = Regex.Match(CommandItem, @"^circle\s(\d+)");
                Match clearMatch = Regex.Match(CommandItem, @"clear");
                Match resetMatch = Regex.Match(CommandItem, @"reset");
                Match fillMatch = Regex.Match(CommandItem, @"fill\s+(on)");
                Match PenMatch = Regex.Match(CommandItem, @"pen\s+(red|yellow|green|blue)");


                if (drawToMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"drawto\s(\d+),\s?(\d+)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"drawto\s(\d+),\s?(\d+)").Groups[2].Value);

                    return new DrawTo(targetX, targetY, stateManager);
                }
                else if (moveToMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"moveto\s(\d+),\s?(\d+)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"moveto\s(\d+),\s?(\d+)").Groups[2].Value);

                    return new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);

                }
                else if (rectMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"rect\s(\d+),\s?(\d+)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"rect\s(\d+),\s?(\d+)").Groups[2].Value);

                    return new RectangleCommand(targetX, targetY, stateManager);
                }
                else if (trigMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(CommandItem, @"trig\s(\d+),\s?(\d+)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(CommandItem, @"trig\s(\d+),\s?(\d+)").Groups[2].Value);

                    return new TriangleCommand(targetX, targetY, stateManager);
                }
                else if (circleMatch.Success)
                {
                    int radius = int.Parse(Regex.Match(CommandItem, @"circle\s(\d+)").Groups[1].Value);
                    return new CircleCommand(radius, stateManager);
                }
                else if (fillMatch.Success)
                {
                    string fillValue = fillMatch.Groups[1].Value;
                    if (!string.IsNullOrEmpty(fillValue))
                        return new FillCommand(stateManager, canvas, GPLPanel);
                }
                else if (PenMatch.Success)
                {
                    string colorString = PenMatch.Groups[1].Value;
                    Color color;

                    switch (colorString)
                    {
                        case "red":
                            color = Color.Red;
                            break;
                        case "blue":
                            color = Color.Blue;
                            break;
                        case "green":
                            color = Color.Green;
                            break;
                        case "yellow":
                            color = Color.Yellow;
                            break;
                        default:
                            color = Color.Black;
                            break;
                    }
                    return new PenCommand(stateManager, GPLPanel, color);
                }
                else if (clearMatch.Success)
                {
                    //Clear command clears the canvas without resetting the position
                    //return new ClearCommand();
                }
                else if (resetMatch.Success)
                {
                    //Reset returns the cursor back to default but keeps any drawings on the canvas
                    int targetX = 15, targetY = 15;
                    return new ResetCommand(targetX, targetY, stateManager, canvas, GPLPanel);
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
