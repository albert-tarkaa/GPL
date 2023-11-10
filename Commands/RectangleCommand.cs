using GPL.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace GPL.Commands
{
    public class RectangleCommand : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        public RectangleCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }
        public void Execute(Graphics g, bool fill, Color color)
        {
            if (fill)
            {
                using (var brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
                }
            }
            else
            {
                g.DrawRectangle(new Pen(color), stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
            }
        }

    }
}
