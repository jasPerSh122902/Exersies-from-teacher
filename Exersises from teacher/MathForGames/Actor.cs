using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;


namespace MathForGames
{
    /// <summary>
    /// is there so i can hold the type for icon for actors or player
    /// </summary>
    struct Icon
    {
        public char Symbol;
        public ConsoleColor color;
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


        public Vector2 Postion
        {
            get { return _position; }
            set { _position = value; }
        }

        public Actor(char icon, Vector2 position, string name = "Actor", ConsoleColor color = ConsoleColor.Cyan)
        {
            //updatede the Icon with the struct and made it take a symbol and a color
            _icon = new Icon { Symbol = icon, color = color};
            _position = position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public  virtual void Update()
        {
            _position.X = Postion.X + 1;
            
        }

        public virtual void Draw()
        {
            Engine.Render(_icon, _position);
        }

        public void End()
        {

        }
    }
}