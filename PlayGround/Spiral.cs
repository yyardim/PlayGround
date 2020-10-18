using System;

namespace PlayGround
{
    class Spiral
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimension: ");
            var dim = Console.ReadLine();
            int[,] spiral;
            if (int.TryParse(dim, out int dimInt))
            {
                spiral = MakeSpiral(dimInt);
            }
            else
            {
                Console.Write("Error! Your entry is invalid.");
            }
        }
        public static int[,] MakeSpiral(int n)
        {
            var spiral = new int[n, n];
            var edge = new int[n * 2 - 1];
            edge[0] = n;
            var j = 1;
            for (int i = 1; i < n * 2 - 1; i++)
            {
                edge[i] = n - j;
                edge[i + 1] = n - j;
                i++;

                j++;
            }
            /* 4,3,3,2,2,1,1
             * 1    2   3   4
             * 12   13  14  5
             * 11   16  15  6
             * 10   9   8   7
             */
            var counter = 1;
            var row = 0;
            var col = -1;
            var directionMatrix = new bool[] { true, false, false, false }; //right, down, left, up

            for (int i = 0; i < n * 2 - 1; i++)
            {
                var innerCounter = 1;
                if (directionMatrix[0] == true) //direction: right, col++
                {
                    while (innerCounter <= edge[i])
                    {
                        col++;
                        spiral[row, col] = counter;
                        counter++;
                        innerCounter++;
                    }
                    directionMatrix[0] = false;
                    directionMatrix[1] = true;
                }
                else if (directionMatrix[1] == true)    //direction: down
                {
                    //row++;
                    while (innerCounter <= edge[i])
                    {
                        row++;
                        spiral[row, col] = counter;
                        counter++;
                        innerCounter++;
                    }
                    directionMatrix[1] = false;
                    directionMatrix[2] = true;
                }
                else if (directionMatrix[2] == true)//direction: left
                {
                    while (innerCounter <= edge[i])
                    {
                        col--;
                        spiral[row, col] = counter;
                        counter++;
                        innerCounter++;
                    }
                    directionMatrix[2] = false;
                    directionMatrix[3] = true;
                }
                else if (directionMatrix[3] == true)// direction: up
                {
                    //row--;
                    while (innerCounter <= edge[i])
                    {
                        row--;
                        spiral[row, col] = counter;
                        counter++;
                        innerCounter++;
                    }
                    directionMatrix[3] = false;
                    directionMatrix[0] = true;
                }
            }

            return spiral;
        }
    }
}
