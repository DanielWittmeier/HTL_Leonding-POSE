/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct with UnitTests
*--------------------------------------------------------------
*/

namespace Distinct
{
    public static class DistinctTools
    {
        public static bool IsDistinct(int[] ar)
        {
            for(int i = 0; i < ar.Length;i++)
            {
                for(int y = 0; y < ar.Length;y++)
                {
                    if (ar[i] == ar[y] && i != y )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static int[] Distinct(int[] ar)
        {
            int[] zwischenspeicher = new int[ar.Length];
            int[] result;
            bool isDuplicate = false;
            int anzUnique = 0;

            for(int i = 0; i < ar.Length; i++)
            {
                for(int y = 0; y < anzUnique; y++)
                {
                    if (ar[i] == zwischenspeicher[y])
                    {
                        isDuplicate = true;
                    }
                }
                if (!isDuplicate)
                {
                    zwischenspeicher[anzUnique] = ar[i];
                    anzUnique++;
                }
                isDuplicate = false;
            }
            result = new int[anzUnique];
            for(int i = 0;i < anzUnique;i++)
            {
                result[i] = zwischenspeicher[i];
            }
            return result;
        }
        public static int[] Duplicate(int[] ar)
        {
            int[] zwischenspeicher = new int[ar.Length];
            int[] result;
            bool isDuplicate = false;
            int anzUnique = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                for (int y = 0; y < ar.Length && !isDuplicate; y++)
                {
                    if (ar[i] == ar[y] && i != y)
                    {
                        for (int x = 0; x < anzUnique; x++)
                        {
                            if (ar[i] == zwischenspeicher[x])
                            {
                                isDuplicate = true;
                            }
                        }
                        if (!isDuplicate)
                        {
                            zwischenspeicher[anzUnique] = ar[i];
                            anzUnique++;
                            isDuplicate = true;
                        }
                    }
                }
                isDuplicate = false;
            }

            result = new int[anzUnique];
            for (int i = 0; i < anzUnique; i++)
            {
                result[i] = zwischenspeicher[i];
            }
            return result;
        }
    }
}