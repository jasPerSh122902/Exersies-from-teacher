using System;
using System.Collections.Generic;
using System.Text;
using MathLibaray;


namespace MathForGames
{
    class Actor
    {
        private char _icon;
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

        public Actor(char icon, Vector2 position, string name = "Actor")
        {
            _icon = icon;
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
            _position.Y = Postion.Y + 1;
            
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition((int)Postion.X, (int)Postion.Y);
            Console.Write(_icon);
        }

        public void End()
        {

        }
    }
}