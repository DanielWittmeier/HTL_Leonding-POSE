
namespace ArrayVergleich
{
    using System;

    public class Matrix
    {
        /// <summary>
        /// Erstellung eines zweidimensionalen Arrays
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns>Ein Array mit Zufallszahlen</returns>
        public static int[,] CreateMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = Random.Shared.Next(1, 10);
                }
            }


            return matrix;
        }
        /// <summary>
        /// Ausgabe des Arrays
        /// </summary>
        /// <param name="matrix"></param>
        public static void CompareAndPrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(matrix[i, j]);

                    if (j != matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" > ");
                        }
                        else if (matrix[i, j] < matrix[i, j + 1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" < ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" = ");
                        }
                    }
                }
                Console.WriteLine();

                if (i != matrix.GetLength(0) - 1)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
 
                            if (matrix[i, j] > matrix[i + 1, j])
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("V   ");
                            }
                            else if (matrix[i, j] < matrix[i + 1, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("A   ");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("=   ");
                            }
                    }
                    Console.WriteLine();
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}