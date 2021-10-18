using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player(char icon, float x, float y, float speed, Color color, string name = "Actor"  ) 
            : base( icon , x , y ,color, name  )
        {
            _speed = speed;

        }

        public override void Update()
        {
            //bro this is boolean majic
            int xDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            Vector2 moveDirection = new Vector2(xDiretion, yDiretion);

            Velocity = moveDirection * Speed;

            Postion += Velocity;

        }

        public override void OnCollision(Actor actor)
        {
            Engine.CloseApplication();
        }
    }
}
