/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 4ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description: Sieb des Eratosthenes

 *--------------------------------------------------------------
*/

namespace SiebDesEratosthenes
{
    using System;

    public class Program
    {
        static void Main()
        {
            int anzdurchlauf = 0, zahlenPerPage = 22;
            bool[] zahlen;
            zahlen = Methoden.Input();
            zahlen = Methoden.isPrime(zahlen);

            for (int i = 2; i < zahlen.Length; i++)
            {
                if (zahlen[i] )
                { 
                    Console.WriteLine(i); 
                    anzdurchlauf++;
                }
                if (anzdurchlauf == zahlenPerPage )
                {
                    anzdurchlauf = 0;
                    Console.Write("<Bitte drücken Sie die Eingabetaste> ");
                    Console.ReadLine();
                }
            }

            Console.Write("<Bitte drücken Sie die Eingabetaste für Ende> ");
            Console.ReadLine();

        }
    }
}
