/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Sortiere 3 Values nach Größe

 *--------------------------------------------------------------
*/

namespace Sort3Values
{
    using System;

    public class Program
    {
        static void Main()
        {
            int input1, input2, input3;
            int change;
            bool noChange;

            input1 = InputInt("Bitte geben Sie den ersten Wert ein: ");
            input2 = InputInt("Bitte geben Sie den zweiten Wert ein: ");
            input3 = InputInt("Bitte geben Sie den dritten Wert ein: ");

            do
            {
                noChange = true;
                if ( input1 < input2 )
                {
                    change = input1;
                    input1 = input2;
                    input2 = change;
                    noChange = false;
                }
                if (input2 < input3)
                {
                    change = input2;
                    input2 = input3;
                    input3 = change;
                    noChange = false;
                }
            } while (!noChange);

            Console.WriteLine($"{input1} >= {input2} >= {input3}");
        }

        private static int InputInt(string text)
        {
            bool isTrue;
            int input;

            Console.Write(text);
            isTrue = int.TryParse(Console.ReadLine(), out input);
            while(!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe!");
                Console.Write(text);
                isTrue = int.TryParse(Console.ReadLine(), out input);
            }

            return input;
        }
    }
}