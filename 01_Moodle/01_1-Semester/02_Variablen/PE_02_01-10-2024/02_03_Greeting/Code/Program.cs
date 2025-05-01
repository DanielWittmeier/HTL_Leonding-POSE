/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Eingabe von Vor-/Nachnamen und Wohnort / Ausgabe dieser

 *--------------------------------------------------------------
*/

namespace Greeting
{
    using System;

    public class Program
    {
        static void Main()
        {
            string vorname, nachname, place;

            Console.Write("Bitte geben Sie Ihren Vornamen ein: ");
            vorname = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihren Nachnamen ein: ");
            nachname = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihren Wohnort ein: ");
            place = Console.ReadLine();

            Console.Write("Herzlich Willkommen "); Console.Write(vorname); Console.Write(" "); Console.Write(nachname); Console.Write(" aus "); Console.Write(place); Console.WriteLine(" zu C#");
        }
    }
}