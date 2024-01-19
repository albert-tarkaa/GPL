using System.Text.RegularExpressions;

namespace GPL.Utilities
{
    public class ErrorHandlers
    {
        private readonly Dictionary<int, string> syntaxErrors = new Dictionary<int, string>();

        public Dictionary<int, string> SyntaxErrors => syntaxErrors;

        public void AddSyntaxError(int lineNumber, string errorMessage)
        {
            syntaxErrors[lineNumber] = errorMessage;
        }
        public static void ErrorHandler(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                throw new ("Coordinates must be greater than 0.");
            }
        }

        public static void ErrorHandler(int x)
        {
            if (x <= 0)
            {
                throw new ("Coordinates must be greater than 0.");
            }
        }

        public void DisplaySyntaxError(string errorMessage, Bitmap canvas)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
               
                PointF errorPosition = new PointF(10, 15);
                Font errorFont = new Font("Times New Roman", 11, FontStyle.Regular);
                Brush errorBrush = new SolidBrush(Color.Red);

                // Wrap the error message to fit within the available space
                string[] lines = errorMessage.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    g.DrawString(line, errorFont, errorBrush, errorPosition);
                    errorPosition.Y += g.MeasureString(line, errorFont).Height;
                }
            }
        }
    }
}
