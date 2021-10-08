using System;
using System.Collections.Generic;
using System.Text;

namespace tik_tak_to
{
    class Board
    {
        private Game _game;
        private static bool _gameOver;
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        public char[,] _board;
        private int winCounter;
        private int j = 0;
        private int x = 0;
        private int y = 0;

        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            _gameOver = false;

        }
        /// <summary>
        /// gets the input from the player 
        /// sets the player token at the desired spot in the sd array
        /// checkif there is a winner
        /// changes the current token in play
        /// </summary>
        public void Update()
        {


            Console.WriteLine("Player " + _currentToken);

            SetToken(_currentToken, Game.GetInput(), Game.GetInput());
            CheckWinner(_currentToken);
            //keeps the board on the screen

            if (_currentToken == _player1Token)
                _currentToken = _player2Token;

            else
                _currentToken = _player1Token;
            Console.ReadKey(true);
        }
        /// <summary>
        /// this is waht the player is seeing on there end of the game.
        /// </summary>
        public void Draw()
        {
            //this again is the board that the player sees
            Console.WriteLine(_board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2] + "|" + "\n" +
                                                  "________\n" +
                              _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2] + "|" + "\n" +
                                                  "________\n" +
                              _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2] + "|");
            Console.WriteLine("Type your corrdinate and the first corrnidate is number 1 " + " \nYou got to write one number then press enter then enter another and enter");
            Console.WriteLine("[0, 0],[0,1] ,[0, 2] ,[1, 0] ,[1, 1] , [1, 2], [2, 0], [2, 1],[2, 2]");
        }
        public void End()
        {
            Console.WriteLine("You are winner" + _currentToken);
            Update();
        }

        /// <summary>
        /// Gets the current player and makes them choose there x and y.
        /// </summary>
        /// <param name="token">Token is the player 1 or 2</param>
        /// <param name="posX">grid on the board</param>
        /// <param name="posY">grid on the board</param>
        /// <returns>Return faalse if the indices are out of range</returns>
        public bool SetToken(char token, int x, int y)
        {
            //increments and returns its value.
            _board[x, y] = _currentToken;

            CheckWinner(_currentToken);
            return true;
        }
        /// <summary>
        /// check if there is a 3 line win for the player...
        /// ...horizontal, vertical, and diagnal.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private void CheckWinner(char token)
        {


            if ((token ==_board[0, 0] && token ==_board[0, 1] && token == _board[0, 2]) || (token == _board[1, 0] && token == _board[1, 1] && token == _board[1, 2]) || (token == _board[2, 0] && token == _board[2, 1] && token == _board[2, 2]))
            {
                Console.WriteLine(_currentToken + " Have won ");
                End();
            }
            if (token == _board[0, 0] && y == _board[1, 0] && token == _board[2, 0] || token == _board[0, 1] && token == _board[1, 1] && token == _board[2, 1] || token == _board[0, 2] && token == _board[1, 2] && token == _board[2, 2])
            {
                Console.WriteLine(_currentToken + " Have won ");
                End();
            }
            if (token == _board[0, 0] && token == _board[1, 1] && token == _board[2, 2] || token == _board[0, 2] && token == _board[1, 1] && token == _board[2, 0])
            {
                Console.WriteLine(_currentToken + " Have won ");
                End();
            }

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
