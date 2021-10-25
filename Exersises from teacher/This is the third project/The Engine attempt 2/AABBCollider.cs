using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        public float _height;

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
            
        public AABBCollider()
        {

        }
    }
}
