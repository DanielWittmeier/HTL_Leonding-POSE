/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 4ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description: Lotto Qick Tipp

 *--------------------------------------------------------------
*/

namespace LottoQuickTipp
{
    using System;

    public class Program
    {
        static void Main()
        {
            int[] quicktip;
            int anzahlpertip = 6, anzahltips = 10, min = 1, max = 45;

            Console.WriteLine("Lotto-Quicktip:");
            Console.WriteLine("****************");

            for (int i = 1; i <= anzahltips; i++)
            {
                quicktip = new int[anzahlpertip];
                quicktip = Methoden.Quicktip(quicktip, min, max);
                Console.Write($"{i,2}. Qick-Tip: ");
                for (int j = 0; j < quicktip.Length; j++)
                {
                    Console.Write($"{quicktip[j],2}");
                    if ( j != quicktip.Length - 1 )
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}