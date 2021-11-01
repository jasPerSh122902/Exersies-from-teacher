using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibaray;

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
        private string _name;
        //can make the vector2 because i used the using mathLIbaray;
        private Vector2 _position;
        //made started a bool so we can see if actors is there or not.
        private bool _started;
        private float _speed;
        private Vector2 _forward = new Vector2(1,0);
        private Matrix3 _transform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Collider _coollider;
        private Sprite _sprite;


        public bool Started
        {
            get { return _started; }
        }

        public string Name
        {
            get { return _name; }
        }

        public float Speed
        {
            get { return _speed; }
        }

        public Vector2 Postion
        {
            //takes in a posisition on the matrix...
            get { return new Vector2(_transform.M02, _transform.M12); }
            set
            {
                //set that posistion on the matrix
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }

        /// <summary>
        /// Is meant to indicate where the front of the actor is.
        /// </summary>
        public Vector2 Forward
        {
            get { return _forward; }
            set { _forward = value; }
        }

        /// <summary>
        /// IS the collider for the actor 
        /// </summary>
        public Collider Collider
        {
            get { return _coollider; }
            set { _coollider = value; }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        //emptyiy actor class
        public Actor() { }

        /// <summary>
        /// takes the Actor constructor and add the float x and y but takes out y
        /// </summary>
        /// <param name="x">is the replace the Vector2</param>
        /// <param name="y">is the replacement for the veoctor2</param>
        public Actor(float x, float y, float speed, string name = "Actor", string path = "") :
            this( new Vector2 { X = x, Y = y }, name, path)
        { }


        /// <summary>
        /// Is a constructor for the actor that hold is definition.
        /// </summary>
        /// <param name="icon">The icon that all this information applies to</param>
        /// <param name="position">is the loctation that the icon is in</param>
        /// <param name="name">current Actor name</param>
        /// <param name="color">The color that the neame or icon will be</param>
        public Actor( Vector2 position, string name = "Actor", string path = "")
        {
            //updatede the Icon with the struct and made it take a symbol and a color
            _position = position;
            _name = name;

            //checkes to see if the actor is named a sprite if it is go down the path if not skip
            if (path != "")
                _sprite = new Sprite(path);
        }

        /// <summary>
        /// Is the start of the actor
        /// </summary>
        public virtual void Start()
        {
            _started = true;
        }

        /// <summary>
        /// Updtated the position for the actor
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Update(float deltaTime)
        {
            _transform = _translation * _rotation * _scale;
        }

        /// <summary>
        /// Draw the actor and draws the collision for actors.
        /// </summary>
        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_transform);
        }


        /// <summary>
        /// The end for actor
        /// </summary>
        public void End()
        {

        }

        /// <summary>
        /// Startes when the player hits a target.
        /// </summary>
        public virtual void OnCollision(Actor actor)
        {

        }

        /// <summary>
        /// Checks if theis actor collided with anoth actor
        /// </summary>
        /// <param name="other">The actor to check collision with</param>
        /// <returns>True if the distance between the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //Returns false if eithe actor dosen't have a collider.
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);

            
        }
        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="translationX">The new x position</param>
        /// <param name="translationY">The new y position</param>
        public void SetTranslation(float translationX, float translationY)
        {
            
            _translation = Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="translationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the yparam>
        public void Translate(float translationX, float translationY)
        {
            
            _translation *= Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Set the rotation of the actor.
        /// </summary>
        /// <param name="radians">The angle of the new rotation in radians.</param>
        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Adds a roation to the current transform's rotation.
        /// </summary>
        /// <param name="radians">The angle in radians to turn.</param>
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Sets the scale of the actor.
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Scales the actor by the given amount.
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void Scale(float x, float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }
    }
}