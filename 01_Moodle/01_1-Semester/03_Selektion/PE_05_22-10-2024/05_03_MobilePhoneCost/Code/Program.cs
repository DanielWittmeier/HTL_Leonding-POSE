/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description: Berechnung der Mobiltelefon Kosten

 *--------------------------------------------------------------
*/

namespace MobilePhoneCost
{
    using System;

    public class Program
    {
        static void Main()
        {
            decimal monthCost, annualServiceCost, activationCost;
            decimal firstYearCost, firstMonthCost, YearCost, monthCostGes;
            Console.WriteLine("Cost calculation for mobile phones");
            Console.WriteLine("==================================");
            monthCost = InputInt("Please enter the monthly cost [1 .. 999]: ", 1, 999);
            annualServiceCost = InputInt("Please enter annual service fee [0 .. 999]: ", 0, 999);
            activationCost = InputInt("Please enter activation cost [0 .. 999]: ", 0, 999);
            Console.WriteLine();

            YearCost = monthCost * 12 + annualServiceCost;
            monthCostGes = monthCost + annualServiceCost / 12;

            if ( activationCost > 0 )
            {
                firstYearCost = YearCost + activationCost;
                firstMonthCost = monthCostGes + activationCost / 12;
                Console.WriteLine($"First year cost: {firstYearCost:f2} Euro, monthly: {firstMonthCost:f2} Euro");
            }

            Console.WriteLine($"Annual cost: {YearCost:f2} Euro, monthly: {monthCostGes:f2} Euro");
        }

        private static decimal InputInt(string text, int min, int max)
        {
            bool isTrue;
            decimal input;

            Console.Write(text);
            isTrue = decimal.TryParse(Console.ReadLine(), out input);
            while (!isTrue || input < min || input > max)
            {
                Console.WriteLine("Ungültige Eingabe!");
                Console.Write(text);
                isTrue = decimal.TryParse(Console.ReadLine(), out input);
            }

            return input;
        }
    }
}