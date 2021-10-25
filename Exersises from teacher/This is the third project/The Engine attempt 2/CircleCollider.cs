using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;

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
            _coolisionRadius = collisionRadius;
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
                return false;

            //fings the distance between the two actors
            float distance = Vector2.Distance(other.Owner.Postion, Owner.Postion);
            //Find the length of the radii combined
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            
            return combinedRadii >= distance;

        }
    }
}
