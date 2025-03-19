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
        //TODO: Implement requested methods here
        public static bool IsDistinct(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for(int y = 0; y < ar.Length; y++)
                {
                    if (ar[i] == ar[y] && i != y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static int[] Distinct(int[] ar)
        {
            return ar;
        }

        public static int[] Duplicate(int[] ar)
        { 
            return ar; 
        }
    }
}