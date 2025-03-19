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
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue;
            int input;
            int[] ar;
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");

            //TODO: Implement Main program here
            Console.Write("Please enter the count of numbers: ");
            isTrue = int.TryParse(Console.ReadLine(), out input);
            ar = new int[input];

            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write($"Please enter {i+1}. number: ");
                isTrue = int.TryParse(Console.ReadLine(), out input);
                ar[i] = input;
            }
        }
    }
}