using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game.Logic
{

    enum Command
    {
        /// <summary>  Arrow keys press </summary>
        Up, Down, Left, Right,
        /// <summary>  'P' key press </summary>
        Pause,
        /// <summary>  'ESC' key press </summary>
        Exit,
        /// <summary>  'Enter' key press </summary>
        Restart,
        /// <summary>  'Space' key press </summary>
        Load,
    };

    class Game
    {
        static string defaultMap =
            "############" +
            "#..........#" +
            ".........#.." +
            "#......###.#" +
            "#..........#" +
            "#..........#" +
            "..###......." +
            "#.#........#" +
            "#..........#" +
            "############";

        Stage defaultLevel = new Stage(defaultMap, 5, 12, "BetaStage");
        public Stage Level { get; private set; }

        private Timer _secondTimer;
        public int FPS;

        public Timer FrameTimer;
        private int _updatecount = 0;


        public static Command Key;

        /// <summary> Game map data </summary>
        public LevelMap map;


        public int Score = 0;

        public string Title { get; set; } = "Snake";

        public void LoadLevel()
        {
            Level = defaultLevel;
            map.buffer = Level.ReturnBufferMap();
            Title = Level.StageTitle;
            //throw new NotImplementedException();
        }


        public void LoadLevel(Stage stage)
        {
            Level = stage;
            map.buffer = Level.ReturnBufferMap();
            Title = Level.StageTitle;
            throw new NotImplementedException();
        }

        public Game()
        {
            _secondTimer = new Timer();
            _secondTimer.Tick += _secondTimer_Tick;
            _secondTimer.Interval = 1000;
            FrameTimer = new Timer();
            FrameTimer.Interval = 5;
            FrameTimer.Tick += Update;

            _secondTimer.Start();
            FrameTimer.Start();
        }

        private void _secondTimer_Tick(object sender, EventArgs e)
        {
            FPS = _updatecount;
            _updatecount = 0;

            //throw new NotImplementedException();
        }

        private void Update(object sender, EventArgs e)
        {
            _updatecount++;
            //throw new NotImplementedException();
        }

        public void ExecuteCommand(Command e)
        {
        }

        public delegate void DrawEventHandler();
        public event DrawEventHandler Draw;
    }


}
