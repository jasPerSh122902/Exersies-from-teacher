﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;
using System.Diagnostics;

namespace MathForGames
{
    class Bullet : Actor
    {
        private float _speed;
        private int _xDirection;
        private int _yDirection;
        private Vector2 _velocity;
        private Vector2 _moveDirection;
        private float _collisionRaidus;
        private Scene _scene;
        private float _cooldownTimer;
        private float _lastTime;
        Stopwatch _stopwatch = new Stopwatch();

        public float Speed
        {
            get { return _speed; }
        }

        public Bullet()
        {

        }

        /// <summary>
        /// is the construct of bullet
        /// </summary>
        /// <param name="Icon">The </param>
        /// <param name="color"></param>
        /// <param name="posistion"></param>
        /// <param name="speed"></param>
        /// <param name="xDirection"></param>
        /// <param name="CollisionRadius"></param>
        /// <param name="yDirection"></param>
        /// <param name="name"></param>
        public Bullet(Vector2 posistion, float speed, int xDirection,float CollisionRadius, int yDirection, string name = "Bullet", string path = "") 
            :base( posistion, name, path)
        {
            _speed = speed;
            _xDirection = xDirection;
            _yDirection = yDirection;
            _collisionRaidus = CollisionRadius;

        }

        public override void Start()
        {

        }
        public override void Update(float deltaTime)
        {
            float currentTime = _stopwatch.ElapsedMilliseconds;
            Bullet bullet = new Bullet();

            if (_lastTime > .50f)
            {
                _scene.RemoveActor(bullet);
            }
            if (_cooldownTimer >= currentTime)
            {
                _lastTime = currentTime;
            }
            _moveDirection = new Vector2(_xDirection, _yDirection);
            _velocity = _moveDirection * Speed * deltaTime;
            LocalPosistion += _velocity;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemey)
            {
                Console.WriteLine("askdjfalskdjflasdjf");
                //The romove actor dos not work right now
                //scene.RemoveActor(actor);
            }
        }
    }
}
