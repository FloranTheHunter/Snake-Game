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

    public struct Point
    {
        public int X;
        public int Y;
    }

    public class CellElement
    {
        public CellType Type;
        public Point Coord;        
    }
}
