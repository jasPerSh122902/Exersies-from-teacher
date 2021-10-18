﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;
using Raylib_cs;

namespace MathForGames
{
    /// <summary>
    /// is there so i can hold the type for icon for actors or player
    /// </summary>
    struct Icon
    {
        public char Symbol;
        public Color color;
    }
    class Actor
    {
        private Icon _icon;
        private string _name;
        //can make the vector2 because i used the using mathLIbaray;
        private Vector2 _position;
        //made started a bool so we can see if actors is there or not.
        private bool _started;

        public bool Started
        {
            get { return _started; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Vector2 Postion
        {
            get { return _position; }
            set { _position = value; }
        }
        public Icon Icon
        {
            get { return _icon; }
        }

        /// <summary>
        /// takes the Actor constructor and add the float x and y but takes out y
        /// </summary>
        /// <param name="x">is the replace the Vector2</param>
        /// <param name="y">is the replacement for the veoctor2</param>
        public Actor(char icon, float x, float y, Color color, string name = "Actor") :
            this(icon, new Vector2 { X = x, Y = y }, color, name)
        { }


        /// <summary>
        /// Is a constructor for the actor that hold is definition.
        /// </summary>
        /// <param name="icon">The icon that all this information applies to</param>
        /// <param name="position">is the loctation that the icon is in</param>
        /// <param name="name">current Actor name</param>
        /// <param name="color">The color that the neame or icon will be</param>
        public Actor(char icon, Vector2 position, Color color, string name = "Actor")
        {
            //updatede the Icon with the struct and made it take a symbol and a color
            _icon = new Icon { Symbol = icon, color = color };
            _position = position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            //Console.WriteLine(_name + ":" + Postion.X + ":" + Postion.Y);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Postion.X, (int)Postion.Y, 50, Icon.color);
        }

        public void End()
        {

        }

        /// <summary>
        /// Startes when the player hits a target.
        /// </summary>
        public virtual void OnCollision(Actor actor)
        {

        }
    }
}