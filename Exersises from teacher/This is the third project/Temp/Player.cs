using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;
using System.Threading;
using System.Diagnostics;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private int _health = 5;
        private float _cooldownTimer;
        private bool _ifTimeTrue;
        private Vector2 _velocity;
        public Scene _scene;

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

        public Player(float x, float y, float speed, int health, Scene scene, string name = "Player", string path = "Images/player.png")
            : base(x, y, speed, name, path)
        {
            _speed = speed;
            _health = health;
            _scene = scene;
        }


        /// <summary>
        /// Updates the players infromation on the screen and console.
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //get the player input direction
            int xDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            //gets the palyers input direction for the shoot by using arrow key
            int xDirectionBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                   + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));
            int yDirectionBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

            if (_ifTimeTrue = false)//if it equals true means that it all ready shot
                _cooldownTimer += deltaTime;

            //takes in a diraction if it dos then...
            if (_cooldownTimer >= .05 &&(xDirectionBullet != 0 || yDirectionBullet != 0))
            {
                //gets the instence of bullet
                Bullet bullet = new Bullet( Postion, 100, xDirectionBullet, 10, yDirectionBullet, "Bullet");

                //spows the colliider
                CircleCollider BulletCollider = new CircleCollider(1, bullet);
                //enables the collider
                bullet.Collider = BulletCollider;
                //addes the actor to scene
                _scene.AddActor(bullet);
            }
           
            //Create a vector tht stores the move input
            Vector2 moveDirection = new Vector2(xDiretion, yDiretion);

            //caculates the veclocity 
            Velocity = moveDirection * Speed * deltaTime;

            base.Update(deltaTime);
            //moves the player
            Postion += Velocity;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemey)
            {
                
            }
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
