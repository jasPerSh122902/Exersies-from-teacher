using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibaray;

namespace MathForGames
{
    class Engine
    {

        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _burffer;
        /// <summary>
        /// is the call to start the application
        /// </summary>
        public void Run()
        {
            //calles the entrire application
            Start();

            //loops till application is done
            while (!_applicationShouldClose)
            {
                Update();
                Draw();

                Thread.Sleep(70);
            }

            //is the call to end the entire appliction
            End();
        }

        /// <summary>
        /// Called when the applicaiton starts
        /// </summary>
        private void Start()
        {
            Scene scene = new Scene();
            Actor actor = new Actor('P', new MathLibaray.Vector2 { X = 0, Y = 0 }, "Actor1", ConsoleColor.Magenta);
            Actor actor2 = new Actor('E', new MathLibaray.Vector2 { X = 1, Y = 0 }, "Actor2", ConsoleColor.Green);
            Actor actor3 = new Actor('I', new MathLibaray.Vector2 { X = 2, Y = 0 }, "Actor3", ConsoleColor.Blue);
            Player player = new Player('Q', 2, 1,1, "Player", ConsoleColor.DarkBlue);

            //adds the actor to the scene and takes in that actor
            scene.AddActor(actor);
            scene.AddActor(actor2);
            scene.AddActor(actor3);
            scene.AddActor(player);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();


        }

        /// <summary>
        /// Updates the Engine 
        /// </summary>
        private void Update()
        {

            _scenes[_currentSceneIndex].Update();

            while (Console.KeyAvailable)
                Console.ReadKey(true);


        }

        /// <summary>
        ///call the current Scene.
        /// </summary>
        private void Draw()
        {
            
            //clear the the current screen in the last frame
            _burffer = new Icon[Console.WindowWidth -1, Console.WindowHeight - 1];
            //resests the cursors positon back to 0,0 to draw over.
            Console.SetCursorPosition(0, 0);

            //add all of the icons back to the buffer
            _scenes[_currentSceneIndex].Draw();

            //incraments through the buffer
            for (int y = 0; y <_burffer.GetLength(1); y++)
            {
                for (int x = 0; x < _burffer.GetLength(0); x++)
                {
                    if (_burffer[x, y].Symbol == '\0')
                        _burffer[x, y].Symbol = ' ';

                    //sets the color of the buffers items
                    Console.ForegroundColor = _burffer[x, y].color;
                    //sets the symbol of the buffers items
                    Console.Write(_burffer[x, y].Symbol);

                    //makes the cursorVisible false now there is no cursor
                    Console.CursorVisible = false;
                }

                //skip a line once the end of the row has been reached.
                Console.WriteLine();
            }
        }
        /// <summary>
        /// end the appliction 
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
        }

        /// <summary>
        /// Creats a array that is teparay then adds all the old arrays vaules to it..
        /// then sets the last index of that array to be the scene.
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index where the new scene is located</returns>
        public int AddScene(Scene scene)
        {

            //craets a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //copy all values of old array then...
            for (int i = 0; i < _scenes.Length; i++)
            {
                //puts it in side the array.
                tempArray[i] = _scenes[i];
            }

            //set the last index to be the scene.
            tempArray[_scenes.Length] = scene;

            //set the old array to e the new array
            _scenes = tempArray;

            //returns the last array.
            return _scenes.Length - 1;
        }

        /// <summary>
        /// get the next key that was typed in the input stream.
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNewtKey()
        {
            //if there are no keys being pressed...
            if (!Console.KeyAvailable)
                //...return
                return 0;
            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }
        /// <summary>
        /// adds the icon to the buffer to print to the screeen in the next draw call;
        /// prints the icon t the given position in the buffer
        /// </summary>
        /// <param name="icon">the icon to draw</param>
        /// <param name="position">and the position the icon is in</param>
        /// <returns></returns>
        public static bool Render(Icon icon, Vector2 position)
        {
            //if the position in the y and x are in the out of bounds...
            if (position.X < 0 || position.X >= _burffer.GetLength(0) || position.Y < 0 || position.Y >= _burffer.GetLength(0))
                //return false.
                return false;
            //Else set the buffer at the index of the given position to be the icon
            _burffer[(int)position.X, (int)position.Y] = icon;
            return true;
        }
        /// <summary>
        /// Closes the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
