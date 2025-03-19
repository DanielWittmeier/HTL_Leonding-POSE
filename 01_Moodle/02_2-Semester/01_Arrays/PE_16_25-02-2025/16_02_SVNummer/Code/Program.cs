using System;

/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description:

 *--------------------------------------------------------------
*/

bool IsValid ( string svNumber )
{
    bool isTrue;
    int number;
    int[] gewichte = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
    int summe = 0, rest = 0;

    if (svNumber.Length == 10 && int.TryParse(svNumber, out number))
    {
        isTrue = true;
    }
    else
    {
        isTrue = false;
    }

    if (isTrue)
    {
        for (int i = 0; i < gewichte.Length; i++)
        {
            summe = summe + (svNumber[i] - '0') * gewichte[i];
        }
        rest = summe % 11;

        if (rest != svNumber[3] - '0')
        {
            isTrue = false;
        }
    }
    return isTrue;
}


bool isTrue;
string svNumber;

Console.WriteLine("Check a SV Number");
Console.WriteLine("**********************");

do
{
    Console.Write("Please enter a SV Number: ");
    svNumber = Console.ReadLine();

    isTrue = IsValid ( svNumber );

    if (svNumber.Length > 0)
    {
        if (isTrue)
        {
            Console.WriteLine($"The SV Number {svNumber} is valid");
        }
        else
        {
            Console.WriteLine($"The SV Number {svNumber} is invalid");
        }
    }
} while ( svNumber.Length > 0 );

