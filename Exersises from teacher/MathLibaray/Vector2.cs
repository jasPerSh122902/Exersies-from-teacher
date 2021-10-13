using System;

namespace MathLibaray
{
    
    public struct Vector2
    {
        public float X;
        public float Y;
        private float _speed;
        private float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X + rhs.X,  Y = lhs.Y + rhs.Y };
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y };
        }

        public static Vector2 operator /(Vector2 lhs, _speed rhs)
        {
            return new Vector2 { };
        }

        ///Create overloaded functions for subtraction, multiplication with a scaplar, division with a scalar
        ///Create overload to check if two vectors are equal to each other and to check if vectors are not equal to each other.

        public static Vector2 operator *(Vector2 lhs, _speed rhs)
        {
            return new Vector2 { };
        }
    }


}
