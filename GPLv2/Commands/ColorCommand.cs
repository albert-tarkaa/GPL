using GPL.Utilities;
using System;
using System.Drawing;

namespace GPL.Commands
{
    /// <summary>
    /// Tests the command to set the color.
    /// </summary>
    public class ColorCommand : ICommand
    {
        private readonly DrawingSettings stateManager;
        private readonly PictureBox pictureBox;
        private readonly Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorCommand"/> class.
        /// </summary>
        /// <param name="cordinatesStateManager">The drawing settings manager.</param>
        /// <param name="picturebox">The PictureBox used for drawing.</param>
        /// <param name="c">The color to set.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cordinatesStateManager"/> or <paramref name="picturebox"/> is null.
        /// </exception>
        public ColorCommand(DrawingSettings cordinatesStateManager, PictureBox picturebox, Color c)
        {
            this.stateManager = cordinatesStateManager ?? throw new ArgumentNullException(nameof(cordinatesStateManager));
            this.pictureBox = picturebox ?? throw new ArgumentNullException(nameof(picturebox));
            this.color = c;
        }

        /// <summary>
        /// Executes the color command by setting the color in the drawing context and refreshing the PictureBox.
        /// </summary>
        /// <param name="g">The graphics context for the execution.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution.</exception>
        public void Execute(Graphics g)
        {
            try
            {
                stateManager.SetColor(color);
                //pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Color' command: {ex.Message}");
            }
        }
    }
}
