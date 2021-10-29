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

            //made the three float for delta time to function
            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;


            //loops till application is done
            while (!_applicationShouldClose || Raylib.WindowShouldClose())
            {
                //getss the time from the Stopwatch timer
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //uses the last time that is at the end of the loop to subtact from the currentTime...
                //... to get the deltaTime.
                deltaTime = currentTime - lastTime;

                Update(deltaTime);

                Draw();

                //gets the currentTime and saves it
                lastTime = currentTime;
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
            Raylib.SetTargetFPS(0);

            _stopwatch.Start();

            //prevously made a function to hold the actors and players to make...
            //the Start function smaller
            Scene scene = new Scene();

            Player player = new Player(110, 100, 150, 100, scene, "Player", "Images/bullet.png");

            //adds the collision to the player
            CircleCollider playerCollider = new CircleCollider(5, player);
            AABBCollider playerBoxCollider = new AABBCollider(34, 42, player);
            player.Collider = playerBoxCollider;
            player.SetScale(50, 50);

            Enemey actor = new Enemey(10, 0, 100, 1, player, "Images/enemy.png");

            //adds the collsion to the enemy
            CircleCollider enemyCollider = new CircleCollider(5, actor);
            AABBCollider enemyBoxCollider = new AABBCollider(50, 50, actor);
            actor.Collider = enemyBoxCollider;
            actor.SetScale(50, 50);


            Enemey actor2 = new Enemey(50, 0, 500, 1, player, "Actor2", "Images/enemy.png");
            Enemey actor3 = new Enemey(85, 0, 500, 1, player, "Actor3", "Images/enemy.png");
            UIText Ui = new UIText(0, 50, "TextBox", Color.BLUE, 0, 100, 200, 20, "This is thest Text. That dos nothing. ");

            //adds the actor to the scene and takes in that actor
            scene.AddActor(actor);
            scene.AddActor(actor2);
            scene.AddActor(actor3);
            scene.AddActor(player);
            scene.AddActor(Ui);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();

        }

        /// <summary>
        /// Updates the Engine when it is called
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);

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