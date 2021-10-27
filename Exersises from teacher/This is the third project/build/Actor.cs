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
        private Matrix3 _transform = Matrix3.Identity;
        private Sprite _sprite;

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
        /// Is meant to be a defaul constructor for actor.
        /// </summary>
        public Actor() { }

        /// <summary>
        /// takes the Actor constructor and add the float x and y but takes out y
        /// </summary>
        /// <param name="x">is the replace the Vector2</param>
        /// <param name="y">is the replacement for the veoctor2</param>
        public Actor( float x, float y, string name = "Actor", string path = "") :
            this( new Vector2 { X = x,Y = y}, name, path) {}


        /// <summary>
        /// Is a constructor for the actor that hold is definition.
        /// </summary>
        /// <param name="icon">The icon that all this information applies to</param>
        /// <param name="position">is the loctation that the icon is in</param>
        /// <param name="name">current Actor name</param>
        /// <param name="color">The color that the neame or icon will be</param>
        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            //updatede the Icon with the struct and made it take a symbol and a color
            
            _position = position;
            _name = name;

            if (path != "")
                _sprite = new Sprite(path);
        }

        public virtual void Start()
        {
            _started = true;
        }

        public  virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            Engine.Render(_icon, _position);
        }

        public void End()
        {
            
        }

       
        /// <summary>
        /// Startes when the player hits a target.
        /// </summary>
        public virtual void OnCollision(Actor player)
        {

        }

        public void SetScale(float x, float y)
        {
            _transform.M00 = x;
            _transform.M11 = y;
        }
    }
}