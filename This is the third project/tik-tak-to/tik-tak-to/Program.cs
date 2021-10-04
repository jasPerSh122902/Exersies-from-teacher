using System;

namespace tik_tak_to
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2DitExample = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //you can not have the new int for the 2 example because it will go off of the amound yo make.
            int[,] array2DitExample2 = { { 1, 2, 3 },
                                         { 4, 5, 6 },
                                         { 7, 8, 9 },
                                         { 10, 11, 12 } };
            Math(array2DitExample2);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    Console.WriteLine(array2DitExample[i, j]);
                }
            }

            void Math(int[,] newArray )
            {
                for (int i = 0; i < newArray.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; i < newArray.GetLength(1); i++)
                    {
                        sum += newArray[i, j];
                      
                    }
                    Console.WriteLine(sum);

                }
                
            }

        }
    }
}
