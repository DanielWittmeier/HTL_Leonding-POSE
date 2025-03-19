/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 4ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description: Array Vergleich

 *--------------------------------------------------------------
*/

namespace ArrayVergleich
{
    using System;

    public class Program
    {
        /// <summary>
        /// Eingabe einer Zahl
        /// </summary>
        /// <param name="text">Anzeige, was eingegeben werden soll</param>
        /// <returns>Die Zahl</returns>
        private static int InputInt(string text)
        {
            bool isTrue;
            int output;
            Console.Write(text);

            isTrue = int.TryParse(Console.ReadLine(), out output);

            while (!isTrue)
            {
                Console.Write("Fehlerhafte Eingabe, bitte wiederholen: ");
                Console.Write("Eingabe der Zeilen                    : ");
                isTrue = int.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }

        static void Main()
        {
            int rows, columns;
            int[,] matrix;
            bool isTrue = false; ;
            do
            {
                rows = InputInt("Eingabe der Zeilen : ");
                columns = InputInt("Eingabe der Spalten: ");
                matrix = Matrix.CreateMatrix(rows, columns);
                Matrix.CompareAndPrintMatrix(matrix);

                Console.Write("Neue Matrix(j): ");
                if (Console.ReadLine() == "j")
                {
                    isTrue = true;
                    Console.WriteLine();
                }
                else
                {
                    isTrue= false;
                }

            } while (isTrue);
        }

    }
}