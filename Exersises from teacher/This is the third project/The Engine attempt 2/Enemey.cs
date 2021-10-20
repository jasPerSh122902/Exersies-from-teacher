using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;

namespace MathForGames
{
    class Enemey : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Player _player;



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


        public Enemey(char icon, float x, float y, float speed, Player player, Color color, string name = "Enemy")
            : base(icon, x, y, speed, color, name)
        {
            //i need to the player = palyer I need to get the this.
            _speed = speed;
            _player = player;

        }

        public override void Update(float deltaTime)
        {

            //Create a vector tht stores the move input
            Vector2 moveDirection = new Vector2();

            moveDirection = _player.Postion - Postion;

            //caculates the veclocity 
            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if (GetTargetInSight())
                Postion += Velocity;

            base.Update(deltaTime);

           
        }

        /// <summary>
        /// Get the Sight of the enemy 
        /// </summary>
        /// <returns>return the feild of vey for the enemy and returns
        /// the possiple distace to get of of veiw</returns>
        public bool GetTargetInSight()
        {
            float distace; 
            Vector2 directionOfTarget = (_player.Postion - Postion).Normalized;

            distace = (_player.Postion - Postion).Magnitude;

            if (Vector2.DotProduct(directionOfTarget, Forward) < 2)
            {
                //The > 0.70 is the angle that is the enemys field of view or visian
                return Vector2.DotProduct(directionOfTarget, Forward) > .70 && distace < 150; ;
            }
            
            //returns the DotProduct greater than 0
            return Vector2.DotProduct(directionOfTarget, Forward) > 0;
        }

        public void Oncollision(Actor actor)
        {

        }
    }
}
