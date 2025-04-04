/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ABIFT
*--------------------------------------------------------------
*              Dani Wittmeier
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

namespace GameOfLife
{
    using System;

    public class GameOfLife
    {
        public static bool[,] CalculateNextGeneration(bool[,] world)
        {
            bool[,] output = new bool[world.GetLength(0),world.GetLength(1)];
            int neighbours = 0;

            for(int i = 0; i < output.GetLength(0); i++ )
            {
                for ( int y = 0; y < output.GetLength(1); y++ )
                {
                    neighbours = CountNeighbours(world, i, y);
                    output[i, y] = (neighbours == 3) || (neighbours == 2 && world[i, y]);
                }
            }

            return output;
        }

        public static int CountNeighbours(bool[,] world, int row, int col )
        {

            int count = 0, newRow, newCol;
            int sizeY = world.GetLength(0);
            int sizeX = world.GetLength(1);

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (!(y == 0 && x == 0))
                    {
                        newRow = (row + y + sizeY) % sizeY;
                        newCol = (col + x + sizeX) % sizeX;


                        if (world[newRow, newCol])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public static bool[,] CreateWorld(int rows)
        {
            bool[,] output = new bool[rows, rows];
            bool randomNumber;
            Random random = new Random();

            for ( int y = 0; y < rows; y++)
            {
                for ( int x = 0; x < rows; x++)
                {
                    output[y,x] = randomNumber = random.Next(2) == 1;
                }
            }

            return output;
        }
        
        public static void WriteWorldConsole(bool[,] world)
        {
            for (int y = 0; y < world.GetLength(0); y++)
            {
                Console.Write("    ");
                for (int x = 0; x < world.GetLength(1); x++)
                {
                   if (world[y,x])
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}