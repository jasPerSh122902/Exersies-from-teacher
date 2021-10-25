using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class CircleCollider : Collider
    {
        private float _coolisionRadius;

        public float CollisionRadius
        {
            get { return _coolisionRadius; }
            set { _coolisionRadius = value; }
        }

        public CircleCollider(float collisionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {

        }
    }
}
