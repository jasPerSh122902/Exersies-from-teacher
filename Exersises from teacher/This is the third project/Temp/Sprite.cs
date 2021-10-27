using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;

namespace MathForGames
{
    class Sprite
    {
        private Texture2D _texture;

        public int Width
        {
            get { return _texture.width; }
            private set { _texture.width = value; }
        }

        public int Height
        {
            get { return _texture.height; }
            private set { _texture.height = value; }
        }


        /// <param name="path">The file path of the image to use as the texture</param>
        public Sprite(string path)
        {
            _texture = Raylib.LoadTexture(path);
        }

        /// <summary>
        /// Draws the sprite using the rotation, tarnlation and scale of the given transform
        /// </summary>
        /// <param name="transform"></param>
        public void Draw(Matrix3 transform)
        {
            //finds the scale of the sprite
            Width = (float)Math.Round(new Vector2(transform.M00, transform.M10).Magnitude);
            Height = (float)Math.Round(new Vector2(transform.M01, transform.M11).Magnitude);
            System.Numerics.Vector2 position = new System.Numerics.Vector2(transform.M02, transform.M12);
            System.Numerics.Vector2 forward = new System.Numerics.Vector2(transform.M00, transform.M10);
            System.Numerics.Vector2 up = new System.Numerics.Vector2(transform.M01, transform.M11);

            position -= System.Numerics.Vector2.Normalize(forward) * Width / 2;
            position -= System.Numerics.Vector2.Normalize(up) * Height / 2;

            //find the transform rotation in radians
            float rotation = (float)Math.Atan(transform.M10, transform.M00);

            Raylib.DrawTextureEx(_texture, position, (float)(rotation * 180 / Math.PI), 1, Color.WHITE);
        }
    }
}
