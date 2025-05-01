/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Eingabe Sekunden / Ausgabe dd:hh:mm:ss

 *--------------------------------------------------------------
*/

namespace Programmname
{
    using System;

    public class Program
    {
        static void Main()
        {
            int input;
            int sec, min, hour, days;
            bool isTrue;

            Console.Write("Bitte geben Sie die Anzahl der Sekunden ein: ");
            isTrue = int.TryParse(Console.ReadLine(), out input);
            while (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe.");
                Console.Write("Bitte geben Sie die Anzahl der Sekunden ein: ");
                isTrue = int.TryParse(Console.ReadLine(), out input);
            }

            sec = input % 60;
            input = input / 60;
            min = input % 60;
            input = input / 60;
            hour = input % 24;
            days = input / 24;

            Console.WriteLine();
            if (days == 1)
            {
                Console.Write($"{days} Tag {hour:d2}:{min:d2}:{sec:d2}");
            }
            else
            {
                Console.Write($"{days} Tage {hour:d2}:{min:d2}:{sec:d2}");
            }
            Console.WriteLine();
        }
    }
}