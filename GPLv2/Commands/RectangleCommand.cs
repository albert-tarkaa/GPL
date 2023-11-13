﻿using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// This is the Rectangle drawing class
    /// </summary>
    public class RectangleCommand : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleCommand"/> class.
        /// </summary>
        /// <param name="x">The width of the rectangle.</param>
        /// <param name="y">The height of the rectangle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the rectangle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameters x,y must be non-negative or zero</exception>
        public RectangleCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            if (x <= 0 || y <= 0)
            {
                throw new ArgumentOutOfRangeException("x and y must be non-negative or zero");
            }
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }
        /// <summary>
        /// This is the Execute method that is used in drawing the rectangle.The rectangle is either filled or outlined
        /// </summary>
        /// <param name="g">The canvas for drawing the rectangle.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        public void Execute(Graphics g)
        {

            try
            {
                if (stateManager.fill)
                {
                    using (var brush = new SolidBrush(stateManager.color))
                    {
                        g.FillRectangle(brush, stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
                    }
                }
                else
                {
                    g.DrawRectangle(new Pen(stateManager.color), stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Rect' command: {ex.Message}");
            }
        }

    }
}
