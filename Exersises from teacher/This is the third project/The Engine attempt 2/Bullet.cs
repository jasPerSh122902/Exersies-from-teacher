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
        private Icon _icon;
        private string _name;
        private int _xDirection;
        private int _yDirection;
        private Vector2 _velocity;
        private Vector2 _moveDirection;

        private Player _palyer;

        public string Name
        {
            get { return _name; }
        }

        public float Speed
        {
            get { return _speed; }
        }

        public Icon Icon
        {
            get { return _icon; }
        }
        public Bullet(char Icon, Color color,Vector2 posistion, float speed, int xDirection, int yDirection, string name = "Bullet") 
            :base(Icon, posistion, color, name)
        {
            _speed = speed;
            _xDirection = xDirection;
            _yDirection = yDirection;

        }

        public override void Update(float deltaTime)
        {
            _moveDirection = new Vector2(_xDirection, _yDirection);
            _velocity = _moveDirection * Speed * deltaTime;

            Postion += _velocity;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "Player")
            {
                
            }
        }
    }
}
