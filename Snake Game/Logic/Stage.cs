using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public Stage(string filePath, bool readTitle = false)
        {
            //throw new NotImplementedException();
            try
            {
                //Read Data block
                using (StreamReader r = new StreamReader(filePath))
                {
                    int flag = 0;
                    while (!r.EndOfStream)
                    {

                        string line = r.ReadLine().ToUpper();
                        switch (line)
                        {
                            case "//DATA":
                                flag = 1;
                                break;

                            case "//MAP":
                                flag = 2;
                                break;

                            case "//RECORDS":
                                flag = 3;
                                break;

                            default:
                                if (!string.IsNullOrEmpty(line))
                                    if (line[0] == '~')
                                        if (line.ToUpper().Contains("~TITLE"))
                                        {
                                            line = line.ToUpper().Replace("~TITLE", "");
                                        }
                                        else
                                            if (line.ToUpper().Contains("~DUP"))
                                        {

                                        }
                                        else
                                            if (line.ToUpper().Contains("~DLEFT"))
                                        {

                                        }
                                        else
                                            if (line.ToUpper().Contains("~DDOWN"))
                                        {

                                        }
                                        else
                                            if (line.ToUpper().Contains("~DRIGHT"))
                                        {

                                        }
                                        else
                                            if (line.ToUpper().Contains("~L"))
                                        {
                                            line = line.ToUpper().Replace("~L", "");
                                        }
                                        else
                                            if (line.ToUpper().Contains("~C"))
                                        {
                                            ColumnCount = int.Parse(line.ToUpper().Replace("~C", ""));
                                        }
                                        else
                                            if (line.ToUpper().Contains("~R"))
                                        {
                                           RowCount  = int.Parse(line.ToUpper().Replace("~R", ""));
                                        }
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

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
        Snake snake;
        public int MaxAppleCount { get; private set; }


    }
}
