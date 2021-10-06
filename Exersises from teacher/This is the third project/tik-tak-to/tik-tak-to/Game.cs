using System;
using System.Collections.Generic;
using System.Text;

namespace tik_tak_to
{
    class Game
    {
        private static  bool _gameOver = false;
        private Board _gameBoard;

        /// <summary>
        /// Begin the game
        /// </summary>
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Draw();
                update();
            }

            End();
        }

        private void Start()
        {
            //loads the board that was made in Board.
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        public void update()
        {
            //updates the board for the game on the coding side..
            _gameBoard.Update();
        }

        private void Draw()
        {
            //updates Game on the visual player side
            Console.Clear();
            _gameBoard.Draw();

        }

        public void End()
        {
            //ends the game
            _gameOver = true;
            _gameBoard.End();

        }

        public static int GetInput()
        {
            int choice = -1;
            
            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;

            return choice;
        }

    }
}
