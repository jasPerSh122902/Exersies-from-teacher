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
                Thread.Sleep(100);
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
            Actor actor2 = new Actor('E', new MathLibaray.Vector2 { X = 1, Y = 1 }, "Actor2", ConsoleColor.Green);

            scene.AddActor(actor);
            scene.AddActor(actor2);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Updates the Engine
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        /// <summary>
        ///call the current Scene.
        /// </summary>
        private void Draw()
        {
            Console.Clear();

            _scenes[_currentSceneIndex].Draw();
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

        public static void Render(Icon icon, Vector2 position)
        {
            if (position.X < 0 || position.X >= _burffer.GetLength(0) || position.Y < 0 || position.Y >= _burffer.GetLength(0))
                return;


        }
    }
}
