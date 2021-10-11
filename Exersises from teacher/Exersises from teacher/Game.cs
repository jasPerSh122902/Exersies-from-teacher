using System;
using System.Collections.Generic;
using System.Text;

namespace Exersises_from_teacher
{
    class Game
    {
        public void Run()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            numbers = AppendToArray(numbers, 5);
            

        }

        int[] AppendToArray(int[] arr, int value)
        {
            //create a new array with one more slot than the old array
            int[] newArray = new int[arr.Length + 1];

            //Copy the values from the old array into the new array
            for (int i = 0; i < arr.Length; i++)
            {
                //
                newArray[i] = arr[i];
            }


            newArray[newArray.Length - 1] = value;

            return newArray;
        }


    } 
}

   