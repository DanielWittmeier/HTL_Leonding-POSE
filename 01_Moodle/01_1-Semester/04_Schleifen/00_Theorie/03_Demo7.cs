/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Description: Summe
 *--------------------------------------------------------------
 */

using System;

string output = "";

Console.Write("Bitte geben sie einen Wert ein: ");

int val = int.Parse(Console.ReadLine());

while (val > 0)
{
    int digit = val % 2;
    val = val / 2;

    output = $"{digit}{output}";
}

Console.WriteLine(output);