using System.Text.RegularExpressions;

namespace GPL.Utilities
{
    public class ErrorHandlers
    {
        private readonly Bitmap canvas;
        public static void ErrorHandler(int x, int y, Exception argumentOutOfRangeException)
        {
            if (x <= 0 || y <= 0)
            {
                throw argumentOutOfRangeException;
            }
        }

        public static void ErrorHandler(int x, Exception argumentOutOfRangeException)
        {
            if (x <= 0)
            {
                throw argumentOutOfRangeException;
            }
        }

        public static void GPLErrorMessage(string errorMessage,Bitmap canvas)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                
                PointF errorPosition = new PointF(15, 15);
                Font errorFont = new Font("Arial", 10, FontStyle.Regular);
                Brush errorBrush = new SolidBrush(Color.Red);

                g.DrawString(errorMessage, errorFont, errorBrush, errorPosition);
            }
        }

    }
}
