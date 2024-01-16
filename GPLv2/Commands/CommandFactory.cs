using GPL.Utilities;
using System.Text.RegularExpressions;

namespace GPL.Commands
{
    /// <summary>
    /// Factory class for creating commands based on input strings provided by user.
    /// </summary>
    public class CommandFactory
    {
        public string CommandItem { get; set; }
        public PictureBox GPLPanel { get; }
        private readonly DrawingSettings stateManager;
        public CommandParser CommandParser { get; }
        private readonly Bitmap canvas;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        /// <param name="commandItem">The command item string.</param>
        /// <param name="gPLPanel">The PictureBox used for drawing.</param>
        /// <param name="cordinatesStateManager">The drawing settings manager.</param>
        /// <param name="bitmap">The canvas bitmap.</param>
        /// <exception cref="ArgumentNullException">Thrown if the commandItem is null or empty.</exception>
        public CommandFactory(string commandItem, PictureBox gPLPanel, DrawingSettings cordinatesStateManager, Bitmap bitmap)
        {
            this.CommandItem = commandItem ?? throw new ArgumentNullException($"'{nameof(CommandItem)}' cannot be null or empty.");
            CommandParser = new CommandParser();
            this.GPLPanel = gPLPanel;
            this.stateManager = cordinatesStateManager;
            this.canvas = bitmap;
        }

        /// <summary>
        /// Creates a command based on the provided command item string.
        /// </summary>
        /// <param name="commandItem">The command item string.</param>
        /// <returns>An instance of ICommand representing the specified command.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the commandItem is null or empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the command type is unknown or an error occurs during command creation.</exception>
        public ICommand CreateCommand(string CommandItem)
        {
            if (string.IsNullOrEmpty(CommandItem))
            {
                throw new ArgumentNullException(nameof(CommandItem), $"'{nameof(CommandItem)}' cannot be null or empty.");
            }

            try
            {
                // Match with coordinates or variable
                Match drawToMatch = Regex.Match(CommandItem, @"^drawto\s([a-zA-Z][a-zA-Z0-9]*|\d+),\s?([a-zA-Z][a-zA-Z0-9]*|\d+)(?:\s|$)");
                Match moveToMatch = Regex.Match(CommandItem, @"moveto\s(.+?),\s?(.+)");
                Match rectMatch = Regex.Match(CommandItem, @"^rect\s([a-zA-Z][a-zA-Z0-9]*|\d+),\s?([a-zA-Z][a-zA-Z0-9]*|\d+)(?:\s|$)");
                Match trigMatch = Regex.Match(CommandItem, @"^trig\s([a-zA-Z][a-zA-Z0-9]*|\d+),\s?([a-zA-Z][a-zA-Z0-9]*|\d+)(?:\s|$)");
                Match circleMatch = Regex.Match(CommandItem, @"^circle\s([a-zA-Z][a-zA-Z0-9]*|\d+)(?:\s|$)");
                Match clearMatch = Regex.Match(CommandItem, @"^clear$");
                Match resetMatch = Regex.Match(CommandItem, @"^reset$");
                Match fillMatch = Regex.Match(CommandItem, @"^fill\s+(on)(?:\s|$)");
                Match ColorMatch = Regex.Match(CommandItem, @"^color\s+([\w\s]+)(?:\s|$)");
                //Match variableAssignmentMatch = Regex.Match(CommandItem, @"^([a-zA-Z][a-zA-Z0-9]*)\s*=\s*(\d+)$");
                Match variableAssignmentMatch = Regex.Match(CommandItem, @"^\s*[a-zA-Z][a-zA-Z0-9]*\s*=\s*(\d+|[a-zA-Z][a-zA-Z0-9]*\s*[\+\-\*/%]\s*\d+)\s*$");

                if (drawToMatch.Success)
                {
                    try
                    {
                        string xParameter = drawToMatch.Groups[1].Value;
                        string yParameter = drawToMatch.Groups[2].Value;

                        int targetX = ConvertToInteger.Convert(xParameter, "X");
                        int targetY = ConvertToInteger.Convert(yParameter, "Y");
                        // ErrorHandlers.ErrorHandler(targetX, targetY, new ArgumentOutOfRangeException("paramters cannot be negative or zero."));
                        return new DrawTo(targetX, targetY, stateManager);

                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }

                }
                else if (moveToMatch.Success)
                {
                    try
                    {
                        var targetX = Regex.Match(CommandItem, @"moveto\s(\w+),\s?(\w+)").Groups[1].Value;
                        var targetY = Regex.Match(CommandItem, @"moveto\s(\w+),\s?(\w+)").Groups[2].Value;
                        // ErrorHandlers.ErrorHandler(targetX, targetY, new ArgumentOutOfRangeException("paramters cannot be negative or zero."));
                        return new MoveTo(targetX, targetY, stateManager, canvas, GPLPanel);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }

                }
                else if (rectMatch.Success)
                {
                    try
                    {
                        var targetX = Regex.Match(CommandItem, @"rect\s(\w+),\s?(\w+)").Groups[1].Value;
                        var targetY = Regex.Match(CommandItem, @"rect\s(\w+),\s?(\w+)").Groups[2].Value;
                        //ErrorHandlers.ErrorHandler(targetX, targetY, new ArgumentOutOfRangeException("paramters cannot be negative or zero."));
                        return new RectangleCommand(targetX, targetY, stateManager);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }
                }
                else if (trigMatch.Success)
                {
                    try
                    {
                        var targetX = Regex.Match(CommandItem, @"trig\s(\w+),\s?(\w+)").Groups[1].Value;
                        var targetY = Regex.Match(CommandItem, @"trig\s(\w+),\s?(\w+)").Groups[2].Value;
                        //ErrorHandlers.ErrorHandler(targetX, targetY, new ArgumentOutOfRangeException("paramters cannot be negative or zero."));
                        return new TriangleCommand(targetX, targetY, stateManager);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }
                }
                else if (circleMatch.Success)
                {
                    try
                    {
                        var radius =Regex.Match(CommandItem, @"circle\s(\w+)").Groups[1].Value;
                        return new CircleCommand(radius, stateManager);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }

                }
                else if (fillMatch.Success)
                {
                    try
                    {
                        string fillValue = fillMatch.Groups[1].Value;
                        if (!string.IsNullOrEmpty(fillValue))
                            return new FillCommand(stateManager, GPLPanel);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }

                }
                else if (ColorMatch.Success)
                {
                    string colorString = ColorMatch.Groups[1].Value;
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
                            throw new ArgumentException($"Unrecognized color: {colorString} in the pen command");

                    }
                    return new ColorCommand(stateManager, GPLPanel, color);
                }
                else if (clearMatch.Success)
                {
                    //Clear command clears the canvas without resetting the position
                    //return new ClearCommand();
                }
                else if (resetMatch.Success)
                {
                    //Reset returns the cursor back to default but keeps any drawings on the canvas
                    int targetX = 15;
                    int targetY = 15;
                    return new ResetCommand(targetX, targetY, stateManager);
                }
                else if (variableAssignmentMatch.Success)
                {
                    try
                    {
                        return new VariableAssignmentCommand(CommandItem,stateManager);
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"An error occurred while executing commands: {ex.Message}");
                    }

                }
                throw new InvalidOperationException($"Unknown command type: {CommandItem}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a command created from the specified text to the command parser.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parser">The command parser.</param>
        public void AddCommandFromText(string commandText, CommandParser parser)
        {
            var command = CreateCommand(commandText);
            parser.AddCommand(command);
        }
    }
}
