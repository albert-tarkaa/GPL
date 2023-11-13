using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// Represents a command to set the fill state and refresh the PictureBox.
    /// </summary>
    public class FillCommand : ICommand
    {
        private readonly DrawingSettings stateManager;
        private readonly PictureBox pictureBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="FillCommand"/> class.
        /// </summary>
        /// <param name="coordinatesManager">The drawing settings manager.</param>
        /// <param name="pictureBox">The PictureBox used for drawing.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="coordinatesManager"/> or <paramref name="pictureBox"/> is null.</exception>
        public FillCommand(DrawingSettings coordinatesManager, PictureBox pictureBox)
        {
            this.stateManager = coordinatesManager ?? throw new ArgumentNullException(nameof(coordinatesManager), "Drawing settings manager cannot be null.");
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox), "PictureBox cannot be null.");
        }

        /// <summary>
        /// Executes the fill command by setting the fill state and refreshing the PictureBox.
        /// </summary>
        /// <param name="g">The graphics context for command execution.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during command execution.</exception>
        public void Execute(Graphics g)
        {
            if (g == null)
            {
                throw new InvalidOperationException( "Graphics context cannot be null.");
            }
            try
            {
                stateManager.SetFill();
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Fill' command: {ex.Message}", ex);
            }
        }
    }
}
