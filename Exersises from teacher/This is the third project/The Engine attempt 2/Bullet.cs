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
        public Player _player;


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
        public Bullet(char Icon, Player player, Color color, float speed, string name = "Bullet")
        {
            _player = player;
            _speed = speed;


        }
    }
}
