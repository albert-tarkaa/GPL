namespace GPL
{
    public class CordinatesStateManager
    {
        public int GlobalX { get;  set; }
        public int GlobalY { get;  set; }

        public void SetCordinates(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;
        }
    }
}
