/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ABIFT
*--------------------------------------------------------------
*              Wittmeier Daniel
*--------------------------------------------------------------
* Description: linear Interpolation
*--------------------------------------------------------------
*/

namespace LinearInterpolation
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue;
            int anzmesswerte;
            double input, value;
            Console.WriteLine("Linear Interpolation");
            Console.WriteLine("**********************");

            //Eingabe der Anzahl der Messpunkte
            Console.Write("Please enter the count of x / y points [1..100]: ");
            do
            { 
                isTrue = int.TryParse(Console.ReadLine() , out anzmesswerte);
            } while (!isTrue || anzmesswerte > 100 || anzmesswerte < 1) ;

            //Eingabe der X-Werte
            double[] xvalues = new double[anzmesswerte];
            for (int i = 0; i < anzmesswerte; i++)
            {
                Console.Write($"X-Values {i + 1}. number: ");
                do
                {
                    isTrue = double.TryParse(Console.ReadLine(), out input);
                } while (!isTrue);
                xvalues[i] = input;
            }

            //Eingabe der Y-Werte
            double[] yvalues = new double[anzmesswerte];
            for (int i = 0; i < anzmesswerte; i++)
            {
                Console.Write($"Y-Values {i + 1}. number: ");
                do
                {
                    isTrue = double.TryParse(Console.ReadLine(), out input);
                } while (!isTrue);
                yvalues[i] = input;
            }

            //Eingabe und Ausgabe der gemessenen Werte ( Bei 0 Ende des Programms )
            do
            {
                Console.Write("Please enter x to be converted (0 to exit): ");
                do
                {
                    isTrue = double.TryParse(Console.ReadLine(), out input);
                } while (!isTrue);
                if ( input != 0)
                {
                    value = LinearInterpolationTools.Calculate(input, xvalues, yvalues);
                    Console.WriteLine($"f({input}) = {value}");
                }
            } while (input != 0);
        }
   }
}