using System;
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
        private Collider _coollider;
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
            get { return new Vector2(_transform.M02, _transform.M12); }
            set
            {
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }

        /// <summary>
        /// IS the collider for the actor 
        /// </summary>
        public Collider Collider
        {
            get { return _coollider; }
            set { _coollider = value; }
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
        public Actor(float x, float y, string name = "Actor", string path = "") :
            this(new Vector2 { X = x, Y = y }, name, path)
        { }


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
            if (_sprite != null)
                _sprite.Draw(_transform);
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

        public virtual bool CheckForCollision(Actor other)
        {
            //Returns false if eithe actor dosen't have a collider.
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);


        }

        /// <summary>
        /// Changes the scale of the actor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y)
        {
            _transform.M00 = x;
            _transform.M11 = y;
        }
    }
}