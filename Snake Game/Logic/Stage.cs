using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game.Logic
{
    /// <summary>
    /// Describes level 
    /// </summary>
    class Stage
    {
        #region Constructors
        /// <summary>
        /// Set readTitle 'true' to get title text from inside of aa file
        /// </summary>
        /// <param name="readtitle"></param>
        public Stage(bool readTitle = false)
        {
            throw new NotImplementedException();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt";
            fileDialog.Filter = ".txt";

        }

        /// <summary>
        ///  Create Stage from local array
        /// </summary>
        /// <param name="stageMap"></param>
        /// <param name="maxAppleCount"></param>
        /// <param name="title"></param>
        public Stage(char[,] stageMap, int maxAppleCount, string title = "default")
        {
            TextMap = stageMap;
            MaxAppleCount = maxAppleCount;
            StageTitle = title;
        }
        /// <summary>
        /// Create stage from local string
        /// </summary>
        /// <param name="stageMap"></param>
        /// <param name="maxAppleCount"></param>
        /// <param name="ColumnCount"></param>
        /// <param name="title"></param>
        /// 

        public Stage(string stageMap, int maxAppleCount, int ColumnCount, string title = "default")
        {
            int rowCount = stageMap.Length / ColumnCount;

            char[,] map = new char[rowCount, ColumnCount];

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                {
                    map[i, j] = stageMap[ColumnCount * (i) + j];
                }

            TextMap = map;
            StageTitle = title;
            MaxAppleCount = maxAppleCount;
        }
        #endregion

        public CellElement[,] ReturnBufferMap()
        {
            CellElement[,] buffer = new CellElement[RowCount, ColumnCount];

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                {
                    switch (TextMap[i, j])
                    {
                        case '#':
                            buffer[i, j] = new CellElement();
                            buffer[i, j].Coord = new Point() { X = j, Y = i };
                            buffer[i, j].Type = CellType.Wall;
                            break;

                        case '.':
                            buffer[i, j] = new CellElement();
                            buffer[i, j].Coord = new Point() { X = j, Y = i };
                            buffer[i, j].Type = CellType.Path;
                            break;

                        case '@':
                            buffer[i, j] = new CellElement();
                            buffer[i, j].Coord = new Point() { X = j, Y = i };
                            buffer[i, j].Type = CellType.Snakebody;
                            break;

                        default:
                            throw new Exception($"Element '{TextMap[i, j]}' is wrong");
                            break;
                    }
                }
            return buffer;
        }

        #region Text map buffer data
        private char[,] _map;
        public char[,] TextMap
        {
            get { return _map; }
            set
            {
                _map = value;
                RowCount = _map.GetLength(0);
                ColumnCount = _map.GetLength(1);
            }
        }
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }
        #endregion

        public string StageTitle = "default";
        public int MaxAppleCount { get; private set; }


    }
}
