/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description:
 * EnterWeekDay
 *--------------------------------------------------------------
*/

namespace EnterWeekDay
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*             Enter week day              *");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("");

            string Modus, wiederholung = "N", B1, B2, B3;

            do
            {
                do
                {
                    Console.WriteLine("");
                    Console.Write("Wochentag / Monatsname? (W/M): "); Modus = Console.ReadLine();
                    if (Modus == "W")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Wochentag Ermittlung");
                        do
                        {
                            Console.Write("Bitte geben Sie den ersten Buchstaben ein: "); B1 = Console.ReadLine();
                            if (B1 == "M")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "O")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Montag ausgewählt.");
                                    }
                                    else if (B2 == "I")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Mittwoch ausgewählt.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "O" && B2 != "I");
                            }
                            else if (B1 == "D")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "I")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Dienstag ausgewählt.");
                                    }
                                    else if (B2 == "O")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Donnerstag ausgewählt.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "I" && B2 != "O");
                            }
                            else if (B1 == "F")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben Freitag ausgewählt.");
                            }
                            else if (B1 == "S")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "A")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Samstag ausgewählt.");
                                    }
                                    else if (B2 == "O")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Sonntag ausgewählt.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "A" && B2 != "O");
                            }
                            else
                            {
                                Console.WriteLine("Falsche Eingabe");
                            }
                        } while (B1 != "M" && B1 != "D" && B1 != "F" && B1 != "S");

                    }
                    else if (Modus == "M")
                    {
                        Console.WriteLine("Monatsname Ermittlung");
                        Console.WriteLine("");
                        do
                        {
                            Console.Write("Bitte geben Sie den ersten Buchstaben ein: "); B1 = Console.ReadLine();
                            if (B1 == "J")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "A")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Januar ausgewählt.");
                                    }
                                    else if (B2 == "U")
                                    {
                                        do
                                        {
                                            Console.Write("Bitte geben Sie den dritten Buchstaben ein: "); B3 = Console.ReadLine();
                                            if (B3 == "N")
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("Sie haben Juni ausgewählt.");
                                            }
                                            else if (B3 == "L")
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("Sie haben Juli ausgewählt.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Falsche Eingabe");
                                            }
                                        } while (B3 != "N" && B3 != "L");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "A" && B2 != "U");
                            }
                            else if (B1 == "F")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben Februar ausgewählt.");
                            }
                            else if (B1 == "M")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "Ä")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben März ausgewählt.");
                                    }
                                    else if (B2 == "A")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben Mai ausgewählt.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "Ä" && B2 != "A");
                            }
                            else if (B1 == "A")
                            {
                                do
                                {
                                    Console.Write("Bitte geben Sie den zweiten Buchstaben ein: "); B2 = Console.ReadLine();
                                    if (B2 == "P")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben April ausgewählt.");
                                    }
                                    else if (B2 == "U")
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Sie haben August ausgewählt.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falsche Eingabe");
                                    }
                                } while (B2 != "P" && B2 != "U");
                            }
                            else if (B1 == "S")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben September ausgewählt.");
                            }
                            else if (B1 == "O")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben Oktober ausgewählt.");
                            }
                            else if (B1 == "N")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben November ausgewählt.");
                            }
                            else if (B1 == "D")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sie haben Dezember ausgewählt.");
                            }
                            else
                            {
                                Console.WriteLine("Falsche Eingabe");
                            }
                        } while (B1 != "J" && B1 != "F" && B1 != "M" && B1 != "A" && B1 != "S" && B1 != "O" && B1 != "N" && B1 != "D");
                    }
                    else
                    {
                        Console.WriteLine("Falsche Eingabe");
                    }
                } while (Modus != "W" && Modus != "M");

                do
                {
                    Console.WriteLine("");
                    Console.Write("Wollen Sie noch etwas anderes ermitteln? ( Y/N ): "); wiederholung = Console.ReadLine();
                    if (wiederholung != "Y" && wiederholung != "N")
                    {
                        Console.WriteLine("Falsche Eingabe");
                    }
                } while (wiederholung != "Y" && wiederholung != "N");
            } while (wiederholung == "Y");
        }
    }
}