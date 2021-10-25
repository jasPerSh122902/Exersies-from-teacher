using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;

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
        private Scene scene;
        private float _currentTime;
        private float _lastTime;

        public float Speed
        {
            get { return _speed; }
        }

        public Bullet(char Icon, Color color,Vector2 posistion, float speed, int xDirection,float CollisionRadius, int yDirection, string name = "Bullet") 
            :base(Icon, posistion, color, name)
        {
            _speed = speed;
            _xDirection = xDirection;
            _yDirection = yDirection;
            _collisionRaidus = CollisionRadius;

        }

        public override void Update(float deltaTime)
        {
            _moveDirection = new Vector2(_xDirection, _yDirection);
            _velocity = _moveDirection * Speed * deltaTime;
            Postion += _velocity;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemey)
            {
                Console.WriteLine("askdjfalskdjflasdjf");
                //The romove actor dos not work right now
                scene.RemoveActor(actor);
            }
        }
    }
}
