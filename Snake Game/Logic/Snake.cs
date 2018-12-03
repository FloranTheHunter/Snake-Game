using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Snake_Game.Logic
{


    class Snake
    {

        List<CellElement> cells = new List<CellElement>();

        Snake()
        {
            cells.Add(new CellElement() { Type = CellType.Snakehead });
            cells.Add(new CellElement() { Type = CellType.Snaketail });
        }

        public bool Move(Point matrix, LevelMap map)
        {

            var cell = map.GetCell(cells[0].Coord + matrix);
            if ( cell.Type == CellType.Apple)
            {
                cells[0].Type = CellType.Snakebody;
                cells.Insert(0, new CellElement() { Type = CellType.Snakehead, Coord = cell.Coord });                
            }
            else
                if (cell.Type == CellType.Path)
            {
                throw new NotImplementedException();
            }
            //throw new NotImplementedException();
            return false;
        }

    }
}
