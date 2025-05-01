/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description:

 *--------------------------------------------------------------
*/

namespace Visitenkarte
{
    using System;

    public class Program
    {
        static void Main()
        {
            string name, place;
            Console.Write("Bitte geben Sie Ihren Namen ein: ");
            name = Console.ReadLine();
            Console.Write("Bitte geben Sie Ihren Wohnort ein: ");
            place = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine($"*  {name,-20}*");
            Console.WriteLine("************************");
            Console.WriteLine($"*  {place,-20}*");
            Console.WriteLine("************************");
        }
    }
}