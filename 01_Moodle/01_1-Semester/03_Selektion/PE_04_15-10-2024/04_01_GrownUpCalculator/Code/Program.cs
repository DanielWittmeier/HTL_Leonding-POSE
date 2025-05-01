/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description:
 * GrownUpCalculator
 * Verschiedene Ausgaben, je nach Alter
 * Ablaufdiagramm im selben Verzeichnis
 *--------------------------------------------------------------
*/

namespace GrownUpCalculator
{
    using System;

    public class Program
    {
        static void Main()
        {
            bool isTrue;
            int alter;

            Console.Write("Bitt geben Sie Ihr Alter ein: ");
            isTrue = int.TryParse(Console.ReadLine(), out alter);
            while (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe!");
                Console.Write("Bitt geben Sie Ihr Alter ein: ");
                isTrue = int.TryParse(Console.ReadLine(), out alter);
            }

            if (alter == 25 || alter == 50 || alter == 75)
            {
                Console.WriteLine("Alles Gute zum runden Geburtstag");
            }
            else
            {
                if (alter >= 18 && alter <= 20)
                {
                    Console.WriteLine("Grown Up");
                }
                else
                {
                    if (alter <= 18)
                    {
                        if (alter < 15)
                        {
                            alter = 18 - alter;
                            Console.WriteLine("Es dauert noch lange, bis Sie Erwachsen werden.");
                            Console.WriteLine($"{alter} Jahre bis zum Erwachsensein");
                        }
                        else
                        {
                            alter = 18 - alter;
                            Console.WriteLine($"{alter} Jahre bis zum Erwachsensein");
                        }
                    }
                    else
                    {
                        if (alter >= 65 && alter <= 120)
                        {
                            Console.WriteLine("Hallo Senior");
                        }
                        else
                        {
                            if (alter > 120)
                            {
                                Console.WriteLine("Zombi");
                            }
                            else
                            {
                                Console.WriteLine("Guten Tag");
                            }
                        }
                    }
                }
            }
        }
    }
}