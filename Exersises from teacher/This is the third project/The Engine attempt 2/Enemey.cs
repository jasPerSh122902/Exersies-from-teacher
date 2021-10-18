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


        public Enemey(char icon, float x, float y, float speed, Color color,Player player, string name = "Enemy")
            : base(icon, x, y, speed, color, name)
        {
            //i need to the player = palyer I need to get the this.
            _speed = speed;
            player =

        }

        public override void Update(float deltaTime)
        {

            //Create a vector tht stores the move input
            Vector2 moveDirection = new Vector2( _player.Postion.X * Postion.X,_player.Postion.Y * Postion.Y );

            //caculates the veclocity 
            Velocity = moveDirection.Normalized * Speed * deltaTime;

            base.Update(deltaTime);
            //moves the player
            Postion += Velocity;

        }


    }
}
