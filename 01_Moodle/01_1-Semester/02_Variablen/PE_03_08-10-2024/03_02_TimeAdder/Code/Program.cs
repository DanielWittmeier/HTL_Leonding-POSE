/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Addieren von 2 Uhrzeiten

 *--------------------------------------------------------------
*/

namespace TimeAdder
{
    using System;

    public class Program
    {
        static void Main()
        {
            int hour1, hour2, min1, min2, hourges, minges;

            Console.WriteLine("Einfacher Addierer für zwei Uhrzeiten");
            Console.WriteLine("=====================================");
            Console.WriteLine();

            hour1 = IntInput("Stunden 1 [int]: ", 0);
            min1 = IntInput("Minuten 1 [int]: ", 59);
            hour2 = IntInput("Stunden 2 [int]: ", 0);
            min2 = IntInput("Minuten 2 [int]: ", 59);

            minges = (min1 + min2) % 60;
            hourges = hour1 + hour2 + ((min1 + min2) / 60);


            Console.WriteLine();
            Console.WriteLine($"{hour1,6}:{min1:d2}");
            Console.WriteLine($"+{hour2,5}:{min2:d2}");
            Console.WriteLine($"={hourges,5}:{minges:d2}");
        }
        private static int IntInput(string text, int max)
        {
            int input;
            bool isTrue;

            Console.Write(text);
            isTrue = int.TryParse(Console.ReadLine(), out input);

            while(!isTrue || input > max && max != 0 )
            {
                Console.WriteLine("Ungültige Eingabe!");
                Console.Write(text);
                isTrue = int.TryParse(Console.ReadLine(), out input);
            }

            return input;
        }
    }
}