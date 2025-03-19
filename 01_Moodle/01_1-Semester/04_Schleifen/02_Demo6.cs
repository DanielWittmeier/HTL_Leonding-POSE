/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Description: Summe 
 *--------------------------------------------------------------
*/

using System;

int summe = 0;
int count = 0;

string input;

do
{
    Console.Write("Bitte geben sie einen Wert ein (x für ende): ");
    input = Console.ReadLine();

    if (input != "x")
    {
        int value1 = int.Parse(input);
        summe += value1;
        count++;
    }
}
while (input != "x");

Console.WriteLine();
Console.WriteLine($"Summe = {summe}");
Console.WriteLine($"Count = {count}");
