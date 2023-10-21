namespace GPL
{
    public class CordinatesStateManager
    {
        public int GlobalX { get;  set; }
        public int GlobalY { get;  set; }

        public void MoveTo(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;
        }
    }
}
