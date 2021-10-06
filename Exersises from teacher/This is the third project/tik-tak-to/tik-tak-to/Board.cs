using System;
using System.Collections.Generic;
using System.Text;

namespace tik_tak_to
{
    class Board
    {
        private Game _game;
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        public char[,] _board;

        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        /// <summary>
        /// gets the input from the player 
        /// sets the player token at the desired spot in the sd array
        /// checkif there is a winner
        /// changes the current token in play
        /// </summary>
        public void Update()
        {

            CheckWinner(_currentToken);
            //keeps the board on the screen
            //if (Game.GetInput() == 1)
            //{
            //    _board[0,0] = _currentToken;
            //}

            //if (_currentToken == _player1Token)
            //    _currentToken = _player2Token;

            //else
            //    _currentToken =  _player1Token;
            //Console.ReadKey(true);
        }
        /// <summary>
        /// this is waht the player is seeing on there end of the game.
        /// </summary>
        public void Draw()
        {
            //this again is the board that the player sees
            Console.WriteLine(_board[0, 0] + "|" + _board[0,1] + "|" + _board[0,2] + "|" +  "\n" +
                                                  "________\n" +
                              _board[1,0] + "|"  + _board[1,1] + "|" + _board[1,2] + "|" + "\n" +
                                                  "________\n" +
                              _board[2,0] + "|"  + _board[2,1] + "|" + _board[2,2] + "|");
        }
        public void End()
        {
            Console.WriteLine("You are winner" + _currentToken);
        }
        /// <summary>
        /// Assigns the spot were the current player is placeing there peice on the grid.
        /// </summary>
        /// <param name="token">Token is the player 1 or 2</param>
        /// <param name="posX">grid on the board</param>
        /// <param name="posY">grid on the board</param>
        /// <returns>Return faalse if the indices are out of range</returns>
        public bool SetToken(char token, int posX, int posY)
        {
            return false;
        }
        /// <summary>
        /// check if there is a 3 line win for the player...
        /// ...horizontal, vertical, and diagnal.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {

            Console.WriteLine("do you want to continue " + "1.Yes " + "2.NO");
            Console.WriteLine("Please enter a number ");
            if (Game.GetInput() == 1)
            {
                ClearBoard();
            }
            if (Game.GetInput() == 2)
            {
                _game.End();
            }
            else
            {
                Console.WriteLine("Error. ");
            }
            return true;
        }
        /// <summary>
        /// Resets the board to it;s default state.
        /// </summary>
        public void ClearBoard()
        {
            Console.Clear();
            Draw();
        }
    }
}
