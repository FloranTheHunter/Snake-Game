using System;
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
        int size = 15;

        public GameView()
        {
            game = new Game();
            game.LoadLevel();            
            InitializeComponent();
            this.ClientSize = new Size(size * game.Level.ColumnCount, size * game.Level.RowCount);
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


            graphics.FillRectangle(Brushes.Black, 0, 0, size, size);
            //var x = 11 * size;            
            //graphics.FillRectangle(Brushes.Black, x, 0 * size, size, size);
            //var a = this.Width;
            //var b = a;
            foreach (CellElement Cell in map)
            {
                switch (Cell.Type)
                {
                    case CellType.Wall:
                        graphics.FillRectangle(Brushes.Blue, Cell.Coord.X * size, Cell.Coord.Y * size, size, size);
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
            RenderMap(game.buffer, graphics);
            //this.Width = size * (game.Level.ColumnCount);
            //this.Height = size * (game.Level.RowCount);
        }

        private void Space_Paint(object sender, PaintEventArgs e)
        {            
        }
    }
}
