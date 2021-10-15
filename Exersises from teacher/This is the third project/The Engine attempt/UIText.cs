using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class UIText : Actor
    {
        private string _text;
        private int _width;
        private int _height;

        /// <summary>
        /// Is the text that is located in the actor
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Is the width for the text
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// Is the hight for the text
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


        /// <summary>
        /// Sets the starting values for the text box
        /// </summary>
        /// <param name="x">The x posistion of the text box</param>
        /// <param name="y">The y posistion of the text box</param>
        /// <param name="name">The name of the text box</param>
        /// <param name="color">The color that is uses for the words</param>
        /// <param name="width">long the text box is </param>
        /// <param name="height">how high you text box is</param>
        /// <param name="text">The words that is with in the UI</param>
        public UIText(float x, float y, String name, ConsoleColor color, int width, int height, string text = "") 
            : base('\0', x, y, name, color)
        {
            Text = text;
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            int cursorPosX = (int)Postion.X;
            int cursorPosY = (int)Postion.Y;

            Icon currentLetter = new Icon { color = Icon.color };

            char[] textChars = Text.ToCharArray();

            for (int i = 0; i < textChars.Length; i++)
            {
                currentLetter.Symbol = textChars[i];

                Engine.Render(currentLetter, new MathLibaray.Vector2 { X = cursorPosX, Y = cursorPosY });

                if (currentLetter.Symbol == '\n')
                {
                    cursorPosX = (int)Postion.X;
                    cursorPosY++;
                    //the continue key word allow me to go into a loop and hit the continue...
                    //...it will leave the rest of the loop and go back to the top.
                    continue;
                }
                cursorPosX++;

                if (cursorPosX > (int)Postion.X + Width)
                {
                    cursorPosX = (int)Postion.X;
                    cursorPosY++;
                }

                //if the cursor has reached the maximum hieght...
                if (cursorPosY > (int)Postion.Y + Height)
                    //...leave the loop
                    break;
            }

        }
    }
}
