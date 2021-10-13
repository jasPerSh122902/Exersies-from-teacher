using System;

namespace MathLibaray
{
    
    public struct Vector2
    {
        public float X;
        public float Y;


        //overrides the plus function 
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            //this conbines both the lest and the right int to one variable like x or y.
            return new Vector2 { X = lhs.X + rhs.X,  Y = lhs.Y + rhs.Y };
        }

        /// <summary>
        /// Subtracts the X and Y values form each.
        /// </summary>
        /// <param name="lhs">The vector that is increaing</param>
        /// <param name="rhs">The vector used to increase the 1st vector</param>
        /// <returns>Returns the result of the vectors</returns>
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y };
        }

        /// <summary>
        /// divides the X and Y values form each.
        /// </summary>
        /// <param name="lhs">The vector that is divding</param>
        /// <param name="rhs">The vector used to divide the 1st vector</param>
        /// <returns>Returns the result of the vectors</returns>
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2 { X = lhs.X / scalar, Y = lhs.Y / scalar};
        }

        /// <summary>
        /// multipling the X and Y values form each.
        /// </summary>
        /// <param name="lhs">The vector that is multiplying</param>
        /// <param name="rhs">The vector used to multinplying the 1st vector</param>
        /// <returns>Returns the result of the vectors</returns>
        public static Vector2 operator *(Vector2 lhs,  float scalar)
        {
            return new Vector2 { X = lhs.X * scalar, Y = lhs.Y * scalar};
        }

        /// <summary>
        /// Uses a bool to know if the left and right are equal to each other will using the vectors
        /// </summary>
        /// <param name="lhs">Is the being compared to the right</param>
        /// <param name="rhs">Is being compared to the left</param>
        /// <returns>true if they are equal, false if not</returns>
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Uses a bool to check if the Lest and right are not equal.  
        /// </summary>
        /// <param name="lhs">Is the main number being compared is not equal</param>
        /// <param name="rhs">is the value that is used to compare lhs</param>
        /// <returns>If they are not equal then true is equal false.</returns>
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }
    }


}
