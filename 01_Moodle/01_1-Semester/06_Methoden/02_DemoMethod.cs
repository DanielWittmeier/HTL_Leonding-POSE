/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Description: DemoMethod
 *--------------------------------------------------------------
 */

using System;

int ReadNumber()
{
    Console.Write("Bitte Zahl eingeben: ");

    string input = Console.ReadLine();

    int number;

    while (!int.TryParse(input, out number))
    {
        Console.WriteLine("Fehler, bitte wiederholen");
        Console.Write("Bitte Zahl eingeben: ");
        input = Console.ReadLine();
    }

    return number;
}

int ReadNumberWithMessage(string message, int min,int max)
{
    string msg = $"{message} [{min}..{max}] ";
    Console.Write(msg);

    string input = Console.ReadLine();

    int number;

    while (!int.TryParse(input, out number) || 
           number < min || 
           number > max)
    {
        Console.WriteLine("Fehler, bitte wiederholen");
        Console.Write(msg);
        input = Console.ReadLine();
    }

    return number;
}


int number1 = ReadNumberWithMessage("Bitte geben sie Minimum-Wert ein",1,50);
int number2 = ReadNumberWithMessage("Bitte geben sie Maximum-Wert ein",50,100);
int number3 = ReadNumber();

Console.WriteLine($"{number1}-{number2}-{number3}");