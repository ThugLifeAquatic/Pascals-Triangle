using System;

namespace PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] start = new int[1];
            start[0] = 1;
            PascalRecursive(start, 10);
            Console.WriteLine();
            PascalIterative(10);
            Console.Read();
        }

        public static void PascalRecursive(int[] input, int n)
        {
            //print current level
            foreach (int i in input)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //Exit condition
            if (input.Length == n)
            {
                return;
            }

            //instantiate array for next level
            int[] next = new int[input.Length + 1];

            //Set first value to 1
            next[0] = 1;

            //Populate "next" with values derived from input, stopping before the last index of "next"
            for (int i = 1; i < input.Length; i++)
            {
                next[i] = input[i - 1] + input[i];
            }

            //Set last value to 1
            next[next.Length - 1] = 1;

            //Recursive call with "next" as new input
            PascalRecursive(next, n);
        }

        public static void PascalIterative(int n)
        {
            //Instantiate triangle with "n" levels
            int[][] triangle = new int[n][];

            //Loop over levels building out each row
            for (int i = 0; i < triangle.Length; i++)
            {
                //Set length of row using "i" (Since "i" starts at 0, we will use "i+1" as the length)
                int[] level = new int[i + 1];

                //Add level to triangle
                triangle[i] = level;

                //Set the first and last index of the level to 1
                triangle[i][0] = 1;
                triangle[i][triangle[i].Length - 1] = 1;

                //If the level is the first or second level, print the values and skip to the next level
                if(i < 2)
                {
                    foreach(int m in triangle[i])
                    {
                        Console.Write(m + " ");
                    }
                    Console.WriteLine();
                    continue;
                }

                //Calculate and add the remaining values to the current level using the previous level's values
                for (int j = 1; j < triangle[i -1].Length; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }

                //Print each value of the current level
                foreach (int m in triangle[i])
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine();
            }
        }
    }


}
