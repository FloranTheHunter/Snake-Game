namespace Snake_Game.Logic
{

    public enum CellType
    {
        Snakehead,
        Snakebody,
        Snaketail,
        Wall,
        Apple,
        Path,
    }

    public class Point
    {
        public int X;
        public int Y;

        public static Point operator + (Point a, Point b)
        {
            Point summ = new Point();

            summ.X = a.X + b.X;
            summ.Y = a.Y + b.Y;

            return summ;
        }
    }

    public class CellElement
    {
        public CellType Type;
        public Point Coord;      
        
    }

    
    public class LevelMap
    {
        public CellElement[,] buffer;

        public CellElement GetCell(Point location)
        {
            return buffer[location.X, location.Y];
        }
    }
}
