/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Dani
 *--------------------------------------------------------------
 * Description:
 * Schreiben Sie ein Programm zum Addieren von zwei Uhrzeiten.
 * Der Benutzer gibt zwei Uhrzeiten mit jeweils Stunden und Minuten ein. Das Programm addiert die
 * beiden Uhrzeiten und gibt das Ergebnis formatiert aus.

 *--------------------------------------------------------------
*/

namespace BesuchDerTante
{
    using System;

    public class Program
    {
        static void Main()
        {
            string Entfernung = "0", Geschwindigkeit = "0", Fahrtdauer = "0";
            double Entfernung1 = 0, Geschwindigkeit1 = 0, Fahrtdauer1 = 0, Sekunden1 = 0;
            int Sekunden, Minuten, Stunden;
            string Bedingung;

            Console.WriteLine("Berechnung der Ankunftszeit bei der Tante");
            Console.WriteLine("-------");
            Console.WriteLine("");

            Console.Write("Wollen Sie die Geschwindigkeit oder Dauer angeben? ( G / D ): "); Bedingung = Console.ReadLine();
            Console.Write("Entfernung in km: "); Entfernung = Console.ReadLine();
            Entfernung1 = Convert.ToDouble(Entfernung);

            if (Bedingung == "G")
            {
                Console.Write("Geschwindigkeit in km/h: "); Geschwindigkeit = Console.ReadLine();
                Geschwindigkeit1 = Convert.ToDouble(Geschwindigkeit);
                Fahrtdauer1 = Entfernung1 / Geschwindigkeit1;
                Console.WriteLine($"Für die Strecke von {Entfernung1:f2} km benötigen Sie {Fahrtdauer1:f4} Stunden.");
            }
            else
            {
                Console.Write("Dauer in h: "); Fahrtdauer = Console.ReadLine();
                Fahrtdauer1 = Convert.ToDouble(Fahrtdauer);
                Geschwindigkeit1 = Entfernung1 / Fahrtdauer1;
                Console.WriteLine($"Für die Strecke von {Entfernung1:f2} km müssen Sie mit {Geschwindigkeit1:f4} km/h fahren.");

            }

            Sekunden1 = Fahrtdauer1 * 3600;
            Sekunden = Convert.ToInt32(Sekunden1);
            Minuten = Sekunden / 60;
            Sekunden = Sekunden % 60;
            Stunden = Minuten / 60 + 10;
            Minuten = Minuten % 60;

            Console.WriteLine($"Sie kommen um {Stunden}:{Minuten:00}:{Sekunden:00} an.");

            if (Stunden < 12)
            {
                Console.WriteLine("");
                Console.WriteLine("Da Sie vor 12:00:00 Uhr ankommen, gibt es noch ein Mittagessen.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Da Sie nach 12:00:00 Uhr ankommen, gibt es nur noch Kaffee und Kuchen.");
            }

            if (Stunden > 19 || Stunden == 19 && Minuten > 0 || Sekunden > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Achtung, da Sie nach 19:00:00 Uhr ankommen, wird es Dunkel werden.");
            }
        }
    }
}