﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibaray;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();

        

        /// <summary>
        /// is the call to start the application
        /// </summary>
        public void Run()
        {
            //calles the entrire application
            Start();



            //loops till application is done
            while (!_applicationShouldClose || Raylib.WindowShouldClose())
            {
                Update();
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
            //created a window using raylib
            Raylib.InitWindow(800, 450, "The math for game. ");
            Raylib.SetTargetFPS(400);

            _stopwatch.Start();

            Scene scene = new Scene();
            Actor actor = new Actor('P', 10, 0, Color.GOLD, "Actor1");
            Actor actor2 = new Actor('E', 50, 0, Color.LIGHTGRAY, "Actor2");
            Actor actor3 = new Actor('I', 85, 0, Color.LIME, "Actor3");
            Player player = new Player('Q', 110, 1, 1, Color.RAYWHITE, "Player");

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
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            //add all of the icons back to the buffer
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();

        }
        /// <summary>
        /// end the appliction 
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
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
        /// Closes the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
