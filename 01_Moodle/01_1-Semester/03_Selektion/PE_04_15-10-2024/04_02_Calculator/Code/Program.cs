/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description:
 * Taschenrechner
 * Schreibe Sie ein Programm ‚Calculator‘, welcher die Grundrechenarten (+, -, *, /) beherrscht. Zuerst
 * werden zwei Zahlen vom Benutzer abgefragt und anschließend wird die Operation eingelesen.
 * Danach errechnet Ihr Programm das Ergebnis und gibt dieses auf die Konsole aus.
 *--------------------------------------------------------------
*/

namespace Calculator
{
    using System;

    public class Program
    {
        static void Main()
        {
            double zahl1, zahl2, ergebnis;
            string oper;

            Console.WriteLine("*******************************************");
            Console.WriteLine("*  Calculator - Ihr Zahlenbegleiter       *");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("1. Zahl eingeben: "); zahl1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. Zahl eingeben: "); zahl2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Operation eingeben [ + - * / ]: "); oper = Console.ReadLine();

            if (oper == "+")
            {
                ergebnis = zahl1 + zahl2;
                Console.WriteLine($"Ergebnis von {zahl1:f2} {oper} {zahl2:f2} = {ergebnis:f4}");
            }
            else if (oper == "-")
            {
                ergebnis = zahl1 - zahl2;
                Console.WriteLine($"Ergebnis von {zahl1:f2} {oper} {zahl2:f2} = {ergebnis:f4}");
            }
            else if (oper == "*")
            {
                ergebnis = zahl1 * zahl2;
                Console.WriteLine($"Ergebnis von {zahl1:f2} {oper} {zahl2:f2} = {ergebnis:f4}");
            }
            else if (oper == "/")
            {
                if (zahl2 == 0)
                {
                    Console.WriteLine("Division durch 0 ist nicht erlaubt!");
                }
                else
                {
                    ergebnis = zahl1 / zahl2;
                    Console.WriteLine($"Ergebnis von {zahl1:f2} {oper} {zahl2:f2} = {ergebnis:f4}");
                }
            }
            else
            {
                Console.WriteLine("Falsche Rechenart");
            }
        }
    }
}