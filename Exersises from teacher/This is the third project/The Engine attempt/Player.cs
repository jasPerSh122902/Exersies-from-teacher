using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public  static int _health;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
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

        public Player(char icon, float x, float y, float speed, string name = "Actor", ConsoleColor color = ConsoleColor.Cyan) 
            : base( icon , x , y , name , color)
        {
            _speed = speed;
            _health = 1;

        }

        public override void Update()
        {
            Vector2 moveDirection = new Vector2();

            ConsoleKey keyPessed = Engine.GetNewtKey();

            if (keyPessed == ConsoleKey.A)
                moveDirection = new Vector2 { X = -1 };
            if (keyPessed == ConsoleKey.D)
                moveDirection = new Vector2 { X = 1 };
            if (keyPessed == ConsoleKey.W)
                moveDirection = new Vector2 { Y = -1 };
            if (keyPessed == ConsoleKey.S)
                moveDirection = new Vector2 { Y = 1 };

            Velocity = moveDirection * Speed;

            Postion += Velocity;

        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "Wall")
            {
               Postion -= Velocity;
            }
            if (actor.Name == "Bullet")
            {
                Health--;
                Postion = Velocity; 
            }
            if (actor.Name == "Boss")
            {
                Engine.CloseApplication();
            }
            if (actor.Name == "Player")
            {
                Postion += Velocity;
            }
        }

        public  void OnCollision(Player player)
        {
            if (player.Name == "Player")
            {
                Postion += Velocity;
            }
        }
    }
}
