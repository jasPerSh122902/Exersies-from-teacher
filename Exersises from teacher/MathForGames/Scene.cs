using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        /// <summary>
        /// Array made for the actors in the scene
        /// </summary>
        private Actor[] _actors;

        /// <summary>
        /// Makes actor in a Scene
        /// </summary>
        public Scene()
        {
            _actors = new Actor[0];
        }

        public void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
                _actors[i].Start();
            

            
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
        public void End()
        {

        }

        /// <summary>
        /// makes a array and adds it to the actors array 
        /// </summary>
        /// <param name="actor">The actor to add to the scene</param>
        public void AddActor(Actor actor)
        {
            //makes a new array called temArray and mades it the lengh of actors + a nother spot
            Actor[] temArray = new Actor[_actors.Length + 1];

            //incremens through the actors array
            for (int i = 0; i < _actors.Length; i++ )
            {
                temArray[i] = _actors[i];
            }

            //sets temArray to the actors array and set it to actor
            temArray[_actors.Length] = actor;

            //then sets actors to temarray
            _actors = temArray;

        }

        /// <summary>
        /// makes a new array then subtracts a existing actor form that array
        /// </summary>
        /// <param name="actor">the actor in that scene</param>
        /// <returns>returns a bool called actorRemoved</returns>
        public bool RemoveActor(Actor actor)
        {
            //create a varialbe to store if the removal was successful
            bool actorRemoved = false;

            //created a new array that is small than the original array.
            Actor[] temArray = new Actor[_actors.Length - 1];

            //is there to the second array and not have space from removed actor.
            int j = 0;

            //incremens through the temArray
            for (int i = 0; i < temArray.Length; i++)
            {
                //sais that if actor is not equal to the actor that is choosen then dont go into but..
                if (_actors[i] != actor)
                {
                    //make temArray have j and make it equal to actors with i so there is no left over space in the array.
                    temArray[j] = _actors[i];
                    //increment j
                    j++;
                }
                //if none of that is needed return true.
                else
                    actorRemoved = true;
                
            }

            //will only happen if the actor is being removed and will the set actors with temArray.
            if(actorRemoved)
                _actors = temArray;

            //...then returns
            return actorRemoved;
        }

    }
}
