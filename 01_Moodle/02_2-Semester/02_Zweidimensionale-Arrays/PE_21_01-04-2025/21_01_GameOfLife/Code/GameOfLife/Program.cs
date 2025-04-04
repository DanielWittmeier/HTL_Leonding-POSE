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

    public class Program
    {
        static void Main(string[] args)
        {
            int rows = 0, round = 0;
            bool[,] world;
            Console.WriteLine("Game of Life");
            Console.WriteLine("============");

            Console.WriteLine("Bei einer negativen Größe wird eine zufällige Welt mit der positiven Größe erstellt.");
            Console.Write("Größe des Spielfelds: [-100..100]: ");
            rows = IntInput(-100, 100, "Größe des Spielfelds: [-100..100]: ");
            world = GameOfLife.CreateWorld(rows);
            WriteWorldConsoleFirst(world);
            Console.WriteLine();
            Console.WriteLine("Ausgangswelt:");
            Console.WriteLine();
            GameOfLife.WriteWorldConsole(world);
            Console.WriteLine();
            Console.Write("Start mit Eingabetaste ...");
            Console.ReadLine();

            do
            {
                round++;
                Console.WriteLine();
                Console.WriteLine($"Welt nach Runde: {round}");
                Console.WriteLine();
                world = GameOfLife.CalculateNextGeneration(world);
                GameOfLife.WriteWorldConsole(world);
                Console.WriteLine();
                Console.Write("Eingabetaste für nächste Runde oder x für Ende: ");

            } while (Console.ReadLine() != "x");
        }

        private static int IntInput(int min, int max, string text)
        {
            bool isTrue;
            int output;

            isTrue = int.TryParse(Console.ReadLine(), out output);

            while ( !isTrue || output < min || output > max )
            {
                Console.WriteLine("Ungültige Eingabe!");
                Console.Write(text);
                isTrue = int.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }

        private static void WriteWorldConsoleFirst(bool[,] world)
        {
            for (int y = 0; y < world.GetLength(0); y++)
            {
                Console.Write($"{y + 1,2}. Row: ");
                for (int x = 0; x < world.GetLength(1); x++)
                {
                    if (world[y, x])
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}