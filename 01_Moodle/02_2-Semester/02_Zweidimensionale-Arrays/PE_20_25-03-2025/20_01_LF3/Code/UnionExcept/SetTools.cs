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
    public class SetTools
    {
        public static bool Condition(int[] a, int i, int[] b, int length)
        {
            for (int y = 0; y < length; y++)
            {
                if (a[i] == b[y])
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] Union(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];
            int length = 0;

            for ( int i = 0; i < a.Length; i++)
            {
                if ( Condition(a,i,result,length) )
                {
                    result[length] = a[i];
                    length++;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (Condition(b, i, result, length))
                {
                    result[length] = b[i];
                    length++;
                }
            }

            int[] output = new int[length];

            for ( int i = 0; i < output.Length; i++)
            {
                output[i] = result[i];
            }

            return output;
        }

        public static int[] Except(int[] a, int[] b)
        {
            int[] result = new int[a.Length];
            int length = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Condition(a, i, result, length) && Condition(a,i,b,b.Length))
                {
                    result[length] = a[i];
                    length++;
                }
            }

            int[] output = new int[length];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = result[i];
            }

            return output;
        }
    }
}