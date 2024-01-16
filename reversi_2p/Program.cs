using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversi_2p
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new revesi_FW());
        }

        
    }
    class Game
    {
        public enum Turn {Black,White };
        static char[,] GamesStartingFormat = {{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', 'W', 'B', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', 'B', 'W', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };

        

        char[,] GameBoard = new char[8, 8];
         Turn PlayerTurn;

        public char GetBoardState(string Name)
        {
            
            return GameBoard [Name[1] - '0', Name[3] - '0'];
        }
        public void SetMove(string Move)
        {
            if (!IsTheMoveValid(Move))
                return;
        }

        private bool IsTheMoveValid(string move)
        {
            return true;
        }

        public void ResetGame()
        {
            GameBoard = GamesStartingFormat;
            PlayerTurn = Turn.White;
        }

    }
}
