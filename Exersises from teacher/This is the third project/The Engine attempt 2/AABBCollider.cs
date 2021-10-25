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
        
        public float Left
        {
            get
            {
                return Owner.Postion.X + -(_width /2) ;
            }
        }

        public float Right
        {
            get
            {
                return Owner.Postion.X + _width / 2;
            }
        }

        public float Top
        {
            get
            {
                return Owner.Postion.Y + -(_height / 2);
            }
        }

        public float Bottom
        {
            get
            {
                return Owner.Postion.Y + Height / 2 ;
            }
        }

        public AABBCollider()
        {

        }
    }
}
