﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Snake_Game.Logic;

namespace Snake_Game
{
    public partial class GameView : Form
    {
        Game game;
        int size = 30;
        double margin = 0.125;


        public GameView()
        {
            game = new Game();
            game.LoadLevel();
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserMouse | ControlStyles.OptimizedDoubleBuffer, true);
            this.ClientSize = new Size(size * game.Level.ColumnCount, size * game.Level.RowCount + LoadMap.Height);
            game.FrameTimer.Tick += UpdateView;
        }

        private void UpdateView(object sender, EventArgs e)
        {
            this.Text = game.Title + " FPS: " + game.FPS;
            this.Invalidate();
            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.LoadLevel();
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    game.ExecuteCommand(Command.Up);
                    break;
                case Keys.Down:
                    game.ExecuteCommand(Command.Down);
                    break;
                case Keys.Left:
                    game.ExecuteCommand(Command.Left);
                    break;
                case Keys.Right:
                    game.ExecuteCommand(Command.Right);
                    break;
                case Keys.Escape:
                    game.ExecuteCommand(Command.Exit);
                    break;
                case Keys.P:
                    game.ExecuteCommand(Command.Pause);
                    break;
                case Keys.Space:
                    game.ExecuteCommand(Command.Load);
                    break;
                case Keys.Enter:
                    game.ExecuteCommand(Command.Restart);
                    break;
                default:
                    break;
            }
        }

        private void RenderMap(CellElement[,] map, Graphics graphics)
        {

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //graphics.FillRectangle(Brushes.Black, 0, 0, size, size);
            //var x = 11 * size;            
            //graphics.FillRectangle(Brushes.Black, x, 0 * size, size, size);
            //var a = this.Width;
            //var b = a;
            int sizeWMargin = size - (int)(size * margin * 2);


            foreach (CellElement Cell in map)
            {
                int posXWMagrin = Cell.Coord.X * size + (int)(size * margin);
                int posYWMagrin = Cell.Coord.Y * size + (int)(size * margin);

                switch (Cell.Type)
                {
                    case CellType.Wall:
                        graphics.FillRectangle(Brushes.LawnGreen, Cell.Coord.X * size, Cell.Coord.Y * size, size, size);
                        graphics.FillEllipse(Brushes.Green, posXWMagrin, posYWMagrin, sizeWMargin, sizeWMargin);
                        break;

                    case CellType.Path:
                    default:
                        break;
                }
            }
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            RenderMap(game.map, graphics);
            //this.Width = size * (game.Level.ColumnCount);
            //this.Height = size * (game.Level.RowCount);
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = ".stg |*.stg",
                Multiselect = false,
                CheckFileExists = true,
                AddExtension = true,
                DefaultExt = ".stg",
                Title = "Open .stg map files"
            };
            file.ShowDialog();
            //file.OpenFile();
            game.LoadLevel(new Stage(file.FileName, false));
      //      game.Title = file.SafeFileName;
            game.Title = file.SafeFileName.Replace(".stg", "");
        }
    }
}
