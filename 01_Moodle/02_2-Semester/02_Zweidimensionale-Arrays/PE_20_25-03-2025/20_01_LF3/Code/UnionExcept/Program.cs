/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 4ABIFT
 *--------------------------------------------------------------
 *              Dani Wittmeier
 *--------------------------------------------------------------
 * Description: Method for Union and Except between two arrays
 *--------------------------------------------------------------
 */

using System;

namespace UnionExcept
{
    class Program
    {
        static void Main()
        {
            int[] a, b;
            Console.WriteLine("Union");
            Console.WriteLine("===========");

            a = new int[] { 1, 1, 3, 5, 7, 9, 1, 3 };
            b = new int[] { 0, 1, 2, 3 };
            WriteOutput("Normalfall",a,b, SetTools.Union(a,b));

            a = new int[] { 1, 1, 3, 5 };
            b = new int[] { 1, 1, 3, 5 };
            WriteOutput("Alle gleich", a, b, SetTools.Union(a, b));

            a = new int[] { 1, 3, 5, 7, 9 };
            b = new int[] { 0, 2, 4, 6, 8 };
            WriteOutput("Keine Überschneidung", a, b, SetTools.Union(a, b));

            Console.WriteLine("Except");
            Console.WriteLine("===========");

            a = new int[] { 1, 1, 3, 5, 7, 9, 1, 3 };
            b = new int[] { 0, 1, 2, 3 };
            WriteOutput("Normalfall", a, b, SetTools.Except(a, b));

            a = new int[] { 1, 1, 3, 5 };
            b = new int[] { 1, 1, 3, 5 };
            WriteOutput("Alle gleich", a, b, SetTools.Except(a, b));

            a = new int[] { 1, 3, 5, 7, 9 };
            b = new int[] { 0, 2, 4, 6, 8 };
            WriteOutput("Keine Überschneidung", a, b, SetTools.Except(a, b));
        }

        private static void WriteOutput(string text, int[] a, int[] b, int[] result)
        {
            Console.WriteLine($"{text}");
            Console.Write("Feld A: "); WriteArray(a);
            Console.Write("Feld B: "); WriteArray(b);
            Console.Write("Ziffern in Feld A und Feld B: "); WriteArray(result);
            Console.WriteLine("===========");
        }

        private static void WriteArray(int[] ar)
        {
            for ( int i = 0; i < ar.Length; i++)
            {
                Console.Write($"{ar[i]} ");
            }
            Console.WriteLine();
        }
    }
}