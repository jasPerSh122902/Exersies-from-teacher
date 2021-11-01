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

        public Player( float x, float y, float speed, int health, Scene scene, string name = "Player", string path = "")
            : base( x, y, speed, name, path)
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

            _cooldownTimer += deltaTime;

            //get the player input direction
            int xDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDiretion = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            //Create a vector tht stores the move input
            Vector2 moveDirection = new Vector2(xDiretion, yDiretion);

            //makes the Velocity if its greater than 0 to forward.
            if (Velocity.Magnitude > 0)
                Forward = Velocity.Normalized;

            //gets the palyers input direction for the shoot by using arrow key
            int xDirectionBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                   + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));
            int yDirectionBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

               

            //takes ina direction and set sets a timer
            //if cooldowntimer is less than .05 then spawn if not then no spawn
            if ((xDirectionBullet != 0  && _cooldownTimer <= .05 || yDirectionBullet != 0 && _cooldownTimer <= .05))
            {
                //the bullet instence
                Bullet bullet = new Bullet( Postion, 100, xDirectionBullet, 10, yDirectionBullet, "Bullet", "images/bullet.png");
                //if timers is greater than the .50 then...
                if (_cooldownTimer > .50f)
                {
                    //...remove the actor from scene
                  _scene.RemoveActor(bullet);
                }
                if (_cooldownTimer >= deltaTime)
                {
                    //spawns the collider
                    CircleCollider BulletCollider = new CircleCollider(1, bullet);
                    //sets the collider
                    bullet.Collider = BulletCollider;
                    //addes the actor bullet to the scene
                    _scene.AddActor(bullet);
                    
                }
            }

            //caculates the veclocity 
            Velocity = moveDirection * Speed * deltaTime;

            base.Translate(Velocity.X, Velocity.Y);

            base.Update(deltaTime);

            
        }

        /// <summary>
        /// uses the collider on the current actor
        /// </summary>
        /// <param name="actor"></param>
        public override void OnCollision(Actor actor)
        {
            //if actor is touched by teh enenmy end the game
            if (actor is Enemey)
            {
                
            }
        }

        /// <summary>
        /// draws the the scene.
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
