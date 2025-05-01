/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description:
 * DayOfYear
 * Ermittlung des Tages im Jahr
 *--------------------------------------------------------------
*/

namespace DayOfYear
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*              Day of Year                *");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("");

            int day, month;
            string schaltyear;
            bool is31days = false;
            bool is30days = false;
            int[] is31daysmonth = [1, 3, 5, 7, 8, 10, 12];
            int[] is30daysmonth = [4, 6, 9, 11];


            Console.Write("Bitte geben Sie den Tag ein (1..31): "); day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Bitte geben Sie den Monat ein (1..12): "); month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Berechnung für Schaltjahr [j/n]: "); schaltyear = Console.ReadLine();

            foreach (int n in is31daysmonth)
            {
                if (n == month)
                {
                    Console.WriteLine("31 Tage");
                    is31days = true;
                    break;
                }
            }

            if (is31days == false)
            {
                foreach (int n in is30daysmonth)
                {
                    if (n == month)
                    {
                        Console.WriteLine("30 Tage");
                        is30days = true;
                        break;
                    }
                }
            }
        }
    }
}