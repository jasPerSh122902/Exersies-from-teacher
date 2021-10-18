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
                Thread.Sleep(70);
                Draw();
            }

            //is the call to end the entire appliction
            End();
        }

        /// <summary>
        /// Called when the applicaiton starts
        /// </summary>
        private void Start()
        {
            Console.Write("You must make it to Wompus but beware of his traps.\n" +
                "You must not loose you lives good luck.");
            Console.Read();

            PrintActor();
        }

        /// <summary>
        /// Updates the Engine 
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
            _scenes[_currentSceneIndex].UpdateUI();

            while (Console.KeyAvailable)
                Console.ReadKey(true);

            if (Player._health == 0)
            {
                
                _applicationShouldClose = true;
            }

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
            _scenes[_currentSceneIndex].DrawUIElemts();

            //incraments through the buffer
            for (int y = 0; y < _burffer.GetLength(1); y++)
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
        public  int AddScene(Scene scene)
        {

            //craets a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //copy all values of old array then...
            for (int i = 0; i < _scenes.Length; i++)
            {
                //puts it in side the array.
                tempArray[i] = _scenes[i];

                if (i > _scenes.Length)
                    End();
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

        /// <summary>
        /// Calls the actors and players and is meant to hold all of them for use.
        /// </summary>
        public virtual void PrintActor()
        {
            Scene scene = new Scene();
            //the Actor has to take a caractor and a x, y then the name you will call it then a color.

            Actor actor = new Actor('P', 0, 0, "Wall", ConsoleColor.Magenta);
            Actor actor2 = new Actor('E', 1, 0, "Wall", ConsoleColor.Green);
            Actor actor3 = new Actor('I', 2, 0, "Wall", ConsoleColor.Blue);

            //left wall
            Actor actor4 = new Actor('l', 2, 4, "Wall", ConsoleColor.Magenta);
            Actor actor5 = new Actor('l', 2, 3, "Wall", ConsoleColor.Green);
            Actor actor6 = new Actor('l', 2, 2, "Wall", ConsoleColor.Blue);
            Actor actor22 = new Actor('l', 7, 8, "Wall", ConsoleColor.Magenta);
            Actor actor23 = new Actor('l', 7, 7, "Wall", ConsoleColor.Green);

            //right wall
            Actor actor7 = new Actor('l', 4, 4, "Wall", ConsoleColor.Magenta);
            Actor actor8 = new Actor('l', 4, 3, "Wall", ConsoleColor.Green);
            Actor actor9 = new Actor('l', 4, 2, "Wall", ConsoleColor.Blue);
            Actor actor18 = new Actor('l', 9, 7, "Wall", ConsoleColor.Magenta);
            Actor actor19 = new Actor('l', 9, 6, "Wall", ConsoleColor.Green);
            Actor actor20 = new Actor('l', 9, 5, "Wall", ConsoleColor.Blue);
            Actor actor24 = new Actor('l', 9, 8, "Wall", ConsoleColor.Blue);

            //The path
            Actor actor11 = new Actor('-', 5, 6, "Wall", ConsoleColor.Magenta);
            Actor actor12 = new Actor('-', 6, 6, "Wall", ConsoleColor.Green);
            Actor actor13 = new Actor('-', 7, 6, "Wall", ConsoleColor.Blue);
            Actor actor15 = new Actor('_', 5, 4, "Wall", ConsoleColor.Magenta);
            Actor actor16 = new Actor('_', 6, 4, "Wall", ConsoleColor.Green);
            Actor actor17 = new Actor('_', 7, 4, "Wall", ConsoleColor.Blue);
            Actor actor21 = new Actor('_', 8, 4, "Wall", ConsoleColor.Blue);

            //perjectiles
            Actor actor10 = new Actor('X', 2, 5, "Bullet", ConsoleColor.Blue);
            Actor actor14 = new Actor('X', 3, 6, "Bullet", ConsoleColor.Blue);
            Actor actor25 = new Actor('X', 8, 10, "Bullet", ConsoleColor.Blue);
            Actor actor26 = new Actor('X', 10, 9, "Bullet", ConsoleColor.Blue);

            //The Boss
            Actor actor27 = new Actor('W', 6, 9, "Boss", ConsoleColor.Blue);

            //Players
            Player player = new Player('Q', 2, 1, 1, "Player", ConsoleColor.DarkBlue);
            Actor actor28 = new Actor('Z', 5, 2, "Player", ConsoleColor.Green);

            //Ui for the player
            UIText Ui = new UIText(4, 0, "Health", ConsoleColor.DarkYellow, 10, 1, "Lives " + Player._health );

            //end of the game Ui
            UIText Ui2 = new UIText(8, 0, "Health", ConsoleColor.DarkYellow, 20, 1, "You have won and got to wompus congrast");

            //the way the Ui updates visualy
            PlayerHud playerHud = new PlayerHud(player, Ui);

            //adds the actor to the scene and takes in that actor
            scene.AddActor(actor);
            scene.AddActor(actor2);
            scene.AddActor(actor3);

            //left wall
            scene.AddActor(actor4);
            scene.AddActor(actor5);
            scene.AddActor(actor6);
            scene.AddActor(actor22);
            scene.AddActor(actor23);

            //right wall
            scene.AddActor(actor7);
            scene.AddActor(actor8);
            scene.AddActor(actor9);
            scene.AddActor(actor18);
            scene.AddActor(actor19);
            scene.AddActor(actor20);
            scene.AddActor(actor24);

            //the path
            scene.AddActor(actor11);
            scene.AddActor(actor12);
            scene.AddActor(actor13);
            scene.AddActor(actor15);
            scene.AddActor(actor16);
            scene.AddActor(actor17);
            scene.AddActor(actor21);

            //The projectiles
            scene.AddActor(actor10);
            scene.AddActor(actor14);
            scene.AddActor(actor25);
            scene.AddActor(actor26);

            //player
            scene.AddActor(player);
            scene.AddActor(actor28);

            //UI for Player
            scene.AddUIElement(Ui);
            //is meant to call Ui2 when player dies
            //dos not work
            if (player.Health == 0)
                scene.AddUIElement(Ui2);
            
            //Prints the playerHud
            scene.AddActor(playerHud);

            //Boss
            scene.AddActor(actor27);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();
        }
    }
}
