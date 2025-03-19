
namespace SiebDesEratosthenes
{
    using System;

    public class Methoden
    {

        public static bool[] Input()
        {
            bool isTrue;
            int anzahl;
            bool[] zahlen;
            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
            isTrue = int.TryParse(Console.ReadLine(), out anzahl) && anzahl > 1;
            while (!isTrue)
            {
                Console.Write("Falsche Eingabe, bitte erneut versuchen: ");
                isTrue = int.TryParse(Console.ReadLine(), out anzahl) && anzahl > 1;
            };
            zahlen = new bool[anzahl+1];
            for (int i = 2; i < zahlen.Length; i++)
            {
                zahlen[i] = true;
            }
            return zahlen;
        }

        public static bool[] isPrime(bool[] zahlen)
        {
            int startvalue = 2;
            int maxvalue = zahlen.Length - 1;

            for (int i = 2; i * i <= maxvalue; i++)
            {
                if( zahlen[i] )
                {
                    for ( int j = i * i; j <= maxvalue; j += i )
                    {
                        zahlen[j] = false;
                    }
                }
            }

            return zahlen;
        }
    }
}