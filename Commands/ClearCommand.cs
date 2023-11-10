using GPL.Commands;

namespace GPL.Utilities
{
    public class ClearCommand : ICommand
    {
        Bitmap Bitmap;

        public ClearCommand(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public void Execute(Graphics g, bool fill, Color color)
        {
            using (g = Graphics.FromImage(Bitmap))
            {
                g.Clear(SystemColors.ControlLight);
                
            }
        }
    }
}
