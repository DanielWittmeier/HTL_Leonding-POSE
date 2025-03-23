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
        private static int IntInput(string text)
        {
            int input;
            bool isTrue;

            Console.Write($"{text}");
            isTrue = int.TryParse(Console.ReadLine(), out input);
            while (!isTrue)
            {
                Console.Write("Ungültige Eingabe, bitte wiederholen: ");
                isTrue = int.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        private static void Output(int[]output, string text)
        {
            Console.Write($"{text,-12}");
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write($"{output[i]}");
                if (i != output.Length - 1)
                {
                    Console.Write(", ");
                }
            }
        }
        
        static void Main()
        {
            int anzNumber;
            int[] numbers;
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");
            //---------------------------------------------------------------------
            //Eingabe User
            anzNumber = IntInput("Please enter the count of numbers: ");
            numbers = new int[anzNumber];
            for (int i = 0; i < anzNumber; i++)
            {
                numbers[i] = IntInput($"Please enter {i + 1}. number: ");
            }
            //---------------------------------------------------------------------
            //Ausgabe
            Output(numbers,"Input: ");

            Console.Write(" => The array is ");
            if (!DistinctTools.IsDistinct(numbers))
            {
                Console.Write("NOT ");
            }
            Console.WriteLine("distinct");

            Output(DistinctTools.Distinct(numbers), "Distinct: ");
            Console.WriteLine("");
            Output(DistinctTools.Duplicate(numbers), "Duplicates: ");
            //---------------------------------------------------------------------
        }
    }
}