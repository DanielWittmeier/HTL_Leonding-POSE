/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Eingabe von 3 Begriffen, Ausgabe aller 6 möglichen Kombinationen.

 *--------------------------------------------------------------
*/

namespace Programmname
{
    using System;

    public class Program
    {
        static void Main()
        {
            string word1, word2, word3;

            Console.WriteLine("Word Shuffle");
            Console.WriteLine("============");
            Console.WriteLine();

            Console.Write("Please enter 1st word: ");
            word1 = Console.ReadLine();
            Console.Write("Please enter 2nd word: ");
            word2 = Console.ReadLine();
            Console.Write("Please enter 3rd word: ");
            word3 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Shuffling words ... six possible combinations:");
            Console.WriteLine();

            Console.WriteLine($"{word1} {word2} {word3}");
            Console.WriteLine($"{word1} {word3} {word2}");
            Console.WriteLine($"{word2} {word3} {word1}");
            Console.WriteLine($"{word2} {word1} {word3}");
            Console.WriteLine($"{word3} {word1} {word2}");
            Console.WriteLine($"{word3} {word2} {word1}");

            Console.WriteLine();
            Console.WriteLine("Press any key to finish . . .");
            Console.ReadLine();
        }
    }
}