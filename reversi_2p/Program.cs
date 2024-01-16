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

        enum MDirection { U,D,R,L,UR,UL,DR,DL};
        
        struct DOutCome
        {
            public Stack<char> DStack ;
            public bool ISRWay;
        }

        public struct Score
        {
            public int White;
            public int Black;
        }
        public Score GameScore =new Score();
        public static char[,] GamesStartingFormat = {{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', 'W', 'B', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', 'B', 'W', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                              { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };

        public bool GameOver = false;

        char[,] GameBoard = new char[8, 8];
        public Turn PlayerTurn;

        
        public void SetMove(string Move)
        {
            if (!IsTheMoveValid(Move))
                return;
            GameBoard[Move[1] - '0', Move[3] - '0'] = PlayerTurn.ToString()[0];
            if (CheckDirection(Move, MDirection.U).ISRWay)
                FixBetweenCubes(Move, MDirection.U, CheckDirection(Move, MDirection.U).DStack);
            if (CheckDirection(Move, MDirection.R).ISRWay)
                FixBetweenCubes(Move, MDirection.R, CheckDirection(Move, MDirection.R).DStack);
            if (CheckDirection(Move, MDirection.L).ISRWay)
                FixBetweenCubes(Move, MDirection.L, CheckDirection(Move, MDirection.L).DStack);
            if (CheckDirection(Move, MDirection.D).ISRWay)
                FixBetweenCubes(Move, MDirection.D, CheckDirection(Move, MDirection.D).DStack);
            if (CheckDirection(Move, MDirection.UR).ISRWay)
                FixBetweenCubes(Move, MDirection.UR, CheckDirection(Move, MDirection.UR).DStack);
            if (CheckDirection(Move, MDirection.UL).ISRWay)
                FixBetweenCubes(Move, MDirection.UL, CheckDirection(Move, MDirection.UL).DStack);
            if (CheckDirection(Move, MDirection.DR).ISRWay)
                FixBetweenCubes(Move, MDirection.DR, CheckDirection(Move, MDirection.DR).DStack);
            if (CheckDirection(Move, MDirection.DL).ISRWay)
                FixBetweenCubes(Move, MDirection.DL, CheckDirection(Move, MDirection.DL).DStack);
            NextTurn();
            if (IsGameover())
                GameOver = true;
            CallculateScore();
        }

        private void CallculateScore()
        {
            int WScore = 0;
            int BScore = 0;
            for (int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    if (GameBoard[i, j] == 'W')
                        WScore++;
                    if (GameBoard[i, j] == 'B')
                        BScore++;
                }
            GameScore.White = WScore;
            GameScore.Black = BScore;
        }

        private bool IsGameover()
        {
            return false;
        }

        private void FixBetweenCubes(string move, MDirection mDirection, Stack<char> dStack)
        {
            int pointx = move[1] - '0', pointy = move[3] - '0';
            int x = 0, y = 0;
            switch (mDirection)
            {
                case MDirection.U:
                    y = -1;
                    x = 0;
                    break;
                case MDirection.R:
                    y = 0;
                    x = +1;
                    break;
                case MDirection.L:
                    y = 0;
                    x = -1;
                    break;
                case MDirection.D:
                    y = +1;
                    x = 0;
                    break;
                case MDirection.UR:
                    y = -1;
                    x = +1;
                    break;
                case MDirection.UL:
                    y = -1;
                    x = -1;
                    break;
                case MDirection.DR:
                    y = +1;
                    x = +1;
                    break;
                case MDirection.DL:
                    y = +1;
                    x = -1;
                    break;
            }
            for (int i = 1; i <= dStack.Count; i++)
            {

                GameBoard[pointx, pointy] = PlayerTurn.ToString()[0];
                pointx += x;
                pointy += y;
            }
        }

        private bool IsTheMoveValid(string move)
        {
            if (GameBoard[move[1] - '0', move[3] - '0'] == 'W'|| GameBoard[move[1] - '0', move[3] - '0'] == 'B')
                return false;
            if (!(CheckDirection(move, MDirection.U).ISRWay  ||
                  CheckDirection(move, MDirection.D).ISRWay  ||
                  CheckDirection(move, MDirection.L).ISRWay  ||
                  CheckDirection(move, MDirection.R).ISRWay  ||
                  CheckDirection(move, MDirection.UL).ISRWay ||
                  CheckDirection(move, MDirection.UR).ISRWay ||
                  CheckDirection(move, MDirection.DL).ISRWay ||
                  CheckDirection(move, MDirection.DR).ISRWay ))
                return false;
            return true;
        }

        private DOutCome CheckDirection(string move, MDirection mDirection)
        {
            DOutCome outcom=new DOutCome();
            outcom.DStack = new Stack<char>();
            int pointx = move[1] - '0', pointy = move[3] - '0';
            int x=0, y=0;
            switch (mDirection)
            {
                case MDirection.U:
                    y = -1;
                    x = 0;
                    break;
                case MDirection.R:
                    y = 0;
                    x = +1;
                    break;
                case MDirection.L:
                    y = 0;
                    x = -1;
                    break;
                case MDirection.D:
                    y = +1;
                    x = 0;
                    break;
                case MDirection.UR:
                    y = -1;
                    x = +1;
                    break;
                case MDirection.UL:
                    y = -1;
                    x = -1;
                    break;
                case MDirection.DR:
                    y = +1;
                    x = +1;
                    break;
                case MDirection.DL:
                    y = +1;
                    x = -1;
                    break;
            }
            pointx += x;
            pointy += y;
            if(pointx<8&&pointx>-1&& pointy < 8 && pointy > -1)
            if ((GameBoard[pointx,pointy] == ReversTurn().ToString()[0]))
            {
                outcom.DStack.Push(GameBoard[pointx, pointy]);
                do
                {
                    pointx += x;
                    pointy += y;
                    if (!(pointx < 8 && pointx > -1 && pointy < 8 && pointy > -1))
                       break;
                    outcom.DStack.Push(GameBoard[pointx, pointy]);
                   
                } while (GameBoard[pointx, pointy] == ReversTurn().ToString()[0]);
            }
            if (outcom.DStack.Any())
            {
                if (outcom.DStack.Peek() == PlayerTurn.ToString()[0])
                    outcom.ISRWay = true;
                else
                    outcom.ISRWay = false;
            }
            else
                outcom.ISRWay = false;
            return outcom;
        }

        private void NextTurn()
        {
            if (PlayerTurn == Turn.Black)
                PlayerTurn = Turn.White;
            else
                PlayerTurn = Turn.Black;
        }
        private Turn ReversTurn()
        {
            if (PlayerTurn == Turn.Black)
                return Turn.White;
            return Turn.Black;
        }
    
        public void ResetGame()
        {
            
            GameBoard = GamesStartingFormat;
            CallculateScore();
            PlayerTurn = Turn.White;
        }

        public char GetBoardState(string Name)
        {

            return GameBoard[Name[1] - '0', Name[3] - '0'];
        }
    }
}
