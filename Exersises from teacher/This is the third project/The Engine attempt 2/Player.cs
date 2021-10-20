using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;
using System.Threading;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Bullet bullet;
        private Player player;
        private int _health = 5;

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

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public Player(char icon, float x, float y, float speed, int health, Color color, string name = "Player")
            : base(icon, x, y, speed, color, name)
        {
            _speed = speed;
            _health = health;

        }



        public override void Update(float deltaTime)
        {
            Scene scene = new Scene();

            //get the player input direction
            int xDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            Bullet bullet = new Bullet('*', player, Color.GOLD, 50, "Bullet");

            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
                scene.AddActor(bullet);

            //Create a vector tht stores the move input
            Vector2 moveDirection = new Vector2(xDiretion, yDiretion);

            //caculates the veclocity 
            Velocity = moveDirection.Normalized * Speed * deltaTime;

            base.Update(deltaTime);
            //moves the player
            Postion += Velocity;


        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemey)
            {
                Health--;

                if (Health == 0)
                {
                    Engine.CloseApplication();
                }
            }

            if (actor is Bullet)
            {
                
            }
        }
    }
}
