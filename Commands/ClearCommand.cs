namespace GPL.Commands
{
    public class ClearCommand : ICommand
    {
        Bitmap Bitmap;

        public ClearCommand(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
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
