/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

using System;

namespace Gomoku;

public static class Tools
{
    public static int ReadNumber(string message, int min, int max)
    {
        //TODO If you need the method, implement it here
        throw new NotImplementedException();
    }

    public static int ReadNumber(string message)
    {
        //TODO If you need the method, implement it here
        throw new NotImplementedException();
    }

    public static bool TryParse(string input, out int value, int min, int max)
    {
        //TODO If you need the method, implement it here
        throw new NotImplementedException();
    }

    public static bool InRange(int value, int min, int max)
    {
        //TODO If you need the method, implement it here
        throw new NotImplementedException();
    }

    public static int DefineBoardSize(string text, int[] values)
    {
        bool isTrue;
        int input;

        do
        {
            Console.Write(text);
            isTrue = int.TryParse(Console.ReadLine(), out input);
            if (isTrue)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (input == values[i])
                    {
                        return input;
                    }
                }
                Console.WriteLine("Diese Boardgröße existiert nicht!");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        } while (true);
    }
}