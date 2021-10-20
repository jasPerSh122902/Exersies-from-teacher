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
        /// the possiple distace to get of of veiw</reddddturns>
        public bool GetTargetInSight()
        {

            float distace;

            //makes dirctionofTarget the Positin of palyer and Position of enemy and normalized
            //...The result.
            Vector2 directionOfTarget = (_player.Postion - Postion).Normalized;

            distace = (_player.Postion - Postion).Magnitude;
            //75 is the degress in crease it for the feild of view
            return (Math.Acos(Vector2.DotProduct(directionOfTarget, Forward))
                * 180 / Math.PI < 55) && distace < 150; ;
        }

        public void Oncollision(Actor actor)
        {

        }
    }
}
