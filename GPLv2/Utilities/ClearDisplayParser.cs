using GPL.Commands;

namespace GPL.Utilities
{
    public class ClearDisplayParser : ICommand
    {
        Bitmap Bitmap;

        public ClearDisplayParser(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public void Execute(Graphics g)
        {
            using (g = Graphics.FromImage(Bitmap))
            {
                g.Clear(SystemColors.ControlLight);

            }
        }
    }
}
