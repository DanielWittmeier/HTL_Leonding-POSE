using System;
using System.IO;
using System.Text;

namespace FileWizard
{
    /// <summary>
    /// FileWizard erledigt einige einfache Konvertieraufgaben
    /// auf beliebigen Textdateien
    /// </summary>
    class Program
    {
        static ConsoleColor defaultColor = Console.ForegroundColor;
        const string LOGO_FILE = "logo.txt";

        static void Main(string[] args)
        {
            string logo = File.ReadAllText(LOGO_FILE, Encoding.Default);
            Console.WriteLine(logo);

            string fileName = GetFileName();
            bool finished = false;
            do
            {
                finished = PerformOperation(ref fileName);
            } while (!finished);

            Console.WriteLine("Vielen Dank, dass ich Dir helfen durfte!");
            System.Threading.Thread.Sleep(3000);
        }


        /// <summary>
        /// Erfragen eines Dateinamen vom Benutzer.
        /// Gibt dieser einen ungültigen Dateinamen ein
        /// (Datei existiert nicht), wird das Einlesen
        /// solange wiederholt, bis ein gültiger Dateiname
        /// eingelesen wurde.
        /// Verwende File.Exists
        /// </summary>
        /// <returns>Gültiger Dateiname (Datei existiert)</returns>
        private static string GetFileName()
        {
            string input;
            Console.Write("Welche Datei soll ich öffnen? ");
            input = Console.ReadLine() ?? "";
            while(!File.Exists(input))
            {
                Console.WriteLine("Diese Datei exisiert nicht!");
                Console.Write("Welche Datei soll ich öffnen? ");
                input = Console.ReadLine() ?? "";
            }
            CreateBackup(input);

            return input;
        }

        /// <summary>
        /// Präsentiert eine Auswahl an Datei-Funktionen
        /// und führt die vom Benutzer gewählte Funktion
        /// aus.
        /// Der Dateiname muss als ref-Parameter übergeben
        /// werden, da er sich durch das Einlesen einer
        /// neuen Datei auch ändern kann.
        /// Wenn "Ende" ausgewählt wurde, wird true 
        /// zurückgegeben
        /// </summary>
        /// <param name="fileName">Dateiname als Referenz</param>
        /// <returns>finished</returns>
        private static bool PerformOperation(ref string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("Was kann ich für dich tun?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fileName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(1) Datei am Bildschirm ausgeben");
            Console.WriteLine("(2) Zeilennummern hinzufügen");
            Console.WriteLine("(3) Zeilen reversieren");
            Console.WriteLine("(4) Zeichenkette ersetzen");
            Console.WriteLine("(5) Neue Datei einlesen");
            Console.WriteLine("(0) Ende");

            int input;
            bool isTrue;

            isTrue = int.TryParse(Console.ReadLine(), out input);
            while (!isTrue || input > 5 || input < 0)
            {
                Console.WriteLine("Ungültige Eingabe!");
                isTrue = int.TryParse(Console.ReadLine(), out input);
            }
            
            switch (input)
            {
                case 1:
                    PrintFile(fileName);
                    return false;

                case 2:
                    return false;

                case 3:
                    return false;

                case 4:
                    return false;

                case 5:
                    return false;

                default:
                    return true;
            } 
        }

        /// <summary>
        /// Erstellen einer Sicherungskopie einer Datei.
        /// Es wird an den Dateinamen '.bak' angehängt.
        /// Gibt es schon eine Sicherung mit diesem Namen,
        /// wird '.bak1' angehängt (bzw. '.bak2', '.bak3', usw.)
        /// Verwende File.Exists und File.Copy
        /// </summary>
        /// <param name="fileName">Zu sichernde Datei</param>
        private static void CreateBackup(string fileName)
        {
            int number = 1;
            string backupfile;
            if (File.Exists(Path.GetFileNameWithoutExtension(fileName) + ".bak"))
            {
                while (File.Exists(Path.GetFileNameWithoutExtension(fileName) + ".bak" + number))
                {
                    number++;
                }
                File.Copy(fileName, Path.GetFileNameWithoutExtension(fileName) + ".bak" + number);
                backupfile = Path.GetFileNameWithoutExtension(fileName) + ".bak" + number;
            }
            else
            {
                File.Copy(fileName, Path.GetFileNameWithoutExtension(fileName) + ".bak");
                backupfile = Path.GetFileNameWithoutExtension(fileName) + ".bak";
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Datei {backupfile} wurde erstellt.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// in umgekehrter Reihenfolge wieder auf die
        /// Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReverseLines(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// mit einer Zeilennummer versehen wieder auf die
        /// gleiche Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void AddLineNumbers(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Der Inhalt der Datei wird in eine string-Variable gelesen.
        /// Der Benutzer wird gefragt, welche Zeichenkette er durch
        /// welche andere Zeichenkette ersetzen will.
        /// Die Ersetzung wird in der string-Variable durchgeführt
        /// und das Ergebnis wieder auf die Datei geschrieben.
        /// Verwende File.ReadAllText und File.WriteAllText.
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReplaceCharacters(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ausgabe der Textdatei auf die Konsole
        /// Verwende ReadAllText
        /// </summary>
        /// <param name="fileName"></param>
        private static void PrintFile(string fileName)
        {
            string[] strings = File.ReadAllLines(fileName);
            Console.WriteLine("------- Ausgabe Start -------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------- Ausgabe Ende -------");
        }
    }
}
