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
        private Vector2 _localPosistion;
        //made started a bool so we can see if actors is there or not.
        private bool _started;
        private float _speed;
        private Vector2 _forward = new Vector2(1,0);

        private Matrix3 _globalTransform = Matrix3.Identity;
        private Matrix3 _LocalTransform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;

        private Collider _coollider;
        private Actor[] _children = new Actor[0];
        private Actor _parent;
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

        public Vector2 LocalPosistion
        {
            //takes in a posisition on the matrix...
            get { return new Vector2(_translation.M02, _translation.M12); }
            set
            {
                //set that posistion on the matrix
                SetTranslation(value.X, value.Y);
            }
        }

        public Vector2 WorldPosistion
        {
            get { return new Vector2(_translation.M00, _translation.M11); }
            set { LocalPosistion = value;   }
        }

        public Matrix3 GolbalTransform
        {
            get {return _globalTransform; }
            set { _globalTransform = value;  }
        }

        public Matrix3 LocalTransform
        {
            get { return _LocalTransform ; }
            set { _LocalTransform = value; }
        }

        public Actor Parent
        {
            get {return _parent; }
            set {_parent = value; }
        }

        public Actor[] Children
        {
            get {return  _children; }
        }


        public Vector2 Size
        {
            get { return new Vector2(_scale.M00, _scale.M11); }
            set { SetScale(value.X, value.Y); }
        }

        /// <summary>
        /// Is meant to indicate where the front of the actor is.
        /// </summary>
        public Vector2 Forward
        {
            get { return new Vector2(_rotation.M00, _rotation.M10); }
            set 
            { 
                
                Vector2 point = value.Normalized + LocalPosistion;
                LookAt(point);
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
            LocalPosistion = position;
            _name = name;

            //checkes to see if the actor is named a sprite if it is go down the path if not skip
            if (path != "")
                _sprite = new Sprite(path);
        }

        /// <summary>
        /// Updates the current transform (the scene).
        /// </summary>
        public void UpdateTransform()
        {
            for (int i = 0; i < _children.Length; i++)
            {
                
            }
        }

        /// <summary>
        /// Adds the child to the scene
        /// </summary>
        /// <param name="child">is a array</param>
        public void AddChild(Actor child)
        {
            //makes a new array called temArray and mades it the lengh of actors + a nother spot
            Actor[] temArray = new Actor[_children.Length + 1];

            //incremens through the actors array
            for (int i = 0; i < _children.Length; i++)
            {
                temArray[i] = _children[i];
            }

            //sets temArray to the actors array and set it to actor
            temArray[_children.Length] = child;

            //then sets actors to temarray
            _children = temArray;
        }

        /// <summary>
        /// Removes child from the scene
        /// </summary>
        /// <param name="child">Is a array</param>
        /// <returns>true or false</returns>
        public bool RemoveChild(Actor child)
        {

            //create a varialbe to store if the removal was successful
            bool childRemoved = false;

            //created a new array that is small than the original array.
            Actor[] temArray = new Actor[_children.Length - 1];

            //is there to the second array and not have space from removed child.
            int j = 0;

            //incremens through the temArray
            for (int i = 0; i < temArray.Length; i++)
            {
                if (i > temArray.Length)
                    i--;

                //sais that if actor is not equal to the child that is choosen then dont go into but..
                if (_children[i] != child)
                {
                    //make temArray have j and make it equal to child with i so there is no left over space in the array.
                    temArray[j] = _children[i];
                    //increment j
                    j++;
                }
                //if none of that is needed return true.
                else
                    childRemoved = true;
            }

            //will only happen if the child is being removed and will the set actors with temArray.
            if (childRemoved)
                _children = temArray;

            //...then returns
            return childRemoved;
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
            _LocalTransform = _translation * _rotation * _scale;
            
        }

        /// <summary>
        /// Draw the actor and draws the collision for actors.
        /// </summary>
        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_LocalTransform);
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

        /// <summary>
        /// Roatates the actor to face the given position
        /// </summary>
        /// <param name="position">The posistion the actor should be looking toward</param>
        public void LookAt(Vector2 position)
        {
            //got the direction the actor should look in
            Vector2 direction = (position - LocalPosistion).Normalized;

            //use the dot product to find the angel the actor needs to rotate
            float dotProd = Vector2.DotProduct(direction, Forward);

            if (dotProd > 1)
                dotProd = 1;

            float angle = (float)Math.Acos(dotProd);

            //find a perpindicula vector to the direction
            Vector2 perpDirection = new Vector2(direction.Y, -direction.X);

            //find the dot product of the perpindicular vector and the current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //if the result isn't 0, use it to change the sign of the angle to be iether positive or negative
            if (perpDot != 0)
                angle *= -perpDot / Math.Abs(perpDot);

            //rotates the actor with the angle of the other actor
            Rotate(angle);
        }
    }
}