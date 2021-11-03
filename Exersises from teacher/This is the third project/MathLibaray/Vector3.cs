using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibaray
{
    class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        /// <summary>
        /// Gets the length of the vector
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Property that returns the normalized value of the vector2
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                Vector3 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Changes this vector to have a magnitude that is equal to one
        /// </summary>
        /// <returns>The result of the normalization
        /// Returns an empty vector if the magnitude is zero</returns>
        public Vector3 Normalize()
        {
            if (Magnitude == 0)
                return new Vector4();

            return this /= Magnitude;
        }

        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">THe right hand side of the operation</param>
        /// <returns>The dot product of the first vector onto the second</returns>
        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * lhs.Z);
        }

        /// <param name="lhs">Left hand side of operation</param>
        /// <param name="rhs">Right hand side of operation</param>
        /// <returns>Returns the distance between two vectors</returns>
        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (rhs - lhs).Magnitude;
        }
    }
}
