
namespace LottoQuickTipp
{
    using System;

    public class Methoden
    {
        public static int[] Quicktip(int[] quicktip, int min, int max)
        {
            Random random = new Random();
            int zahl = 0;
            bool isunique;

            for (int i = 0; i < quicktip.Length; i++)
            {
                do
                {
                    isunique = true;
                    zahl = random.Next(min, max + 1);
                   

                    for (int j = 0; j <= i; j++)
                    {
                        if (quicktip[j] == zahl)
                        {
                            isunique = false;
                        }
                    }
                } while (!isunique);
                quicktip[i] = zahl;
            }

            bool isSor;

            do
            {
                int tmpvalue;
                isSor = true;

                for (int i = 0; i < quicktip.Length - 1; i++)
                {
                    if ( quicktip[i] > quicktip[i + 1])
                    {
                        tmpvalue = quicktip[i];
                        quicktip[i] = quicktip[i + 1];
                        quicktip[i+1] = tmpvalue;
                        isSor = false;
                    }
                }

            } while (!isSor);

            return quicktip;
        }
    }
}