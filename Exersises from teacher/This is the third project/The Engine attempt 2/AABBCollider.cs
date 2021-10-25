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

        /// <summary>
        /// The size of ths collider on the x axis
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// The size of this collider on the y axis
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        
        /// <summary>
        /// The farthest left x position of the collider
        /// </summary>
        public float Left
        {
            get
            {
                return Owner.Postion.X + -(_width /2) ;
            }
        }

        /// <summary>
        /// The farthest right x posistion of the collider
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.Postion.X + _width / 2;
            }
        }

        /// <summary>
        /// The fartheset top y position of the collider
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.Postion.Y + -(_height / 2);
            }
        }

        /// <summary>
        /// The farthesest bottom y posistion of the collider
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.Postion.Y + Height / 2 ;
            }
        }

        public AABBCollider(Actor actor, ColliderType )
        {

        }
    }
}
