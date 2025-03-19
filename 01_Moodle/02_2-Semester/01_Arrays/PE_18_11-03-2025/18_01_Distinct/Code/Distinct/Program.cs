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


        static void Main(string[] args)
        {
            int anzNumber, input;
            int[] numbers, output;
            bool isTrue;
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");

            //---------------------------------------------------------------------
            //Eingabe User
            anzNumber = IntInput("Please enter the count of numbers: ");
            numbers = new int[anzNumber];
            for (int i = 0; i < anzNumber; i++)
            {
                input = IntInput($"Please enter {i + 1}. number: ");
                numbers[i] = input;
            }
            //---------------------------------------------------------------------
            //Ausgabe
            Console.Write($"{"Input: ",-12}");
            for (int i = 0; i < anzNumber; i++)
            {
                Console.Write($"{numbers[i]}");
                if (i != anzNumber - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(" => The array is ");
            if (!DistinctTools.IsDistinct(numbers))
            {
                Console.Write("NOT ");
            }
            Console.WriteLine("distinct");

            Console.Write($"{"Distinct: ",-12}");
            output = DistinctTools.Distinct(numbers);
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write($"{output[i]}");
                if (i != output.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("");
            Console.Write($"{"Duplicates: ",-12}");
            output = DistinctTools.Duplicate(numbers);
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write($"{output[i]}");
                if (i != output.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            //---------------------------------------------------------------------
        }
    }
}