/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 4ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Eingabe von Name und Wohnort + Ausgabe

 *--------------------------------------------------------------
*/

namespace HelloWorld
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello HTL Leonding");
            Console.Write("Bitte geben Sie Ihren Namen ein: ");
            string username = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihren Wohnort ein: ");
            string place = Console.ReadLine();
            Console.WriteLine($"Nice to see you {username} from {place}");
        }
    }
}