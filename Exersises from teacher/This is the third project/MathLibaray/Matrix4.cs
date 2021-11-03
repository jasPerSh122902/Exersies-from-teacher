using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibaray
{
    class Matrix4
    {
        public float M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32 , M33;

        //The basic constrctor of the Matrix3
        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            //setting each of the M's to there respected M
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        //Made the Matrix3 equal the Identity value do i dont have to call constucor over again.
        public static Matrix4 Identity
        {
            get
            {
                //is all of the places in the matrix;
                return new Matrix4(1, 0, 0, 0,
                                   0, 1, 0, 0,
                                   0, 0, 1, 0,
                                   0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix4 CreateRotation(float radians)
        {
            return new Matrix4((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                               -(float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                                0, 0, 1, 0
                                0, 0, 0, 1);
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="x">The x position of the new matrix</param>
        /// <param name="y">The y position of the new matrix</param>
        public static Matrix4 CreateTranslation(float x, float y)
        {
            return new Matrix4(1, 0, x, 0,
                               0, 1, y, 0,
                               0, 0, 1, 0,
                               0, 0, 0, 1);
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis</param>
        /// <param name="y">The value to use to scale the matrix in the y axis</param>
        /// <returns>The result of the scale</returns>
        public static Matrix4 CreateScale(float x, float y)
        {
            return new Matrix4(x, 0, 0, 0.
                               0, y, 0, 0,
                               0, 0, 1, 0
                               0, 0, 0, 1);
        }
    }
}
