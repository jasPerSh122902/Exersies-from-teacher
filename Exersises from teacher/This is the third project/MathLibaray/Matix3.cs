﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames.MathLibaray
{
    public struct Matrix3
    {
        //is all of the places in the matrix;
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        //The basic constrctor of the Matrix3
        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            //setting each of the M's to there respected M
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        //Made the Matrix3 equal the Identity value do i dont have to call constucor over again.
        public static Matrix3 Identity
        {
            get
            {
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }
    }
}