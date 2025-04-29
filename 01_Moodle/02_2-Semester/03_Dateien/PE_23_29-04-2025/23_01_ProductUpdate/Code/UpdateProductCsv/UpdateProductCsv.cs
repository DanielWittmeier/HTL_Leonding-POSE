/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: UpdateProductCsv
*--------------------------------------------------------------
*/

namespace UpdateProductCsv
{
    using System;
    using System.Formats.Asn1;
    using System.Globalization;
    using System.IO;
    using System.IO.Enumeration;

    public class UpdateProductCsv
    {
        public static int Main(string[] args)
        {
            //TODO: Implement Main method Check / Lesen / Aktualisieren / Speichern
            string filename;
            decimal percent;
            int fehlercode;

            if (!CheckArguments(args, out filename, out percent, out fehlercode))
            {
                return 1;
            }

            string[] csvfile = ReadCSVFiles(filename);

            //File.Create(Path.GetFileNameWithoutExtension(args[0]) + ".$$$");
            File.Delete(Path.GetFileNameWithoutExtension(args[0]) + ".bak");
            File.Move(filename, Path.GetFileNameWithoutExtension(args[0]) + ".bak");

            File.WriteAllLines(Path.GetFileNameWithoutExtension(args[0]) + ".$$$", UpdateCSVFile(csvfile, percent));
            File.Move(Path.GetFileNameWithoutExtension(args[0]) + ".$$$", Path.GetFileNameWithoutExtension(args[0]) + ".csv");

            return 0; //0 heißt kein Fehler, 1 für Fehler
        }

        // TODO: Implement methods for Read, Update and Write Csv 
        private static bool CheckArguments(string[] args, out string filename, out decimal percent, out int fehlercode)
        {
            filename = "";
            percent = 0;
            fehlercode = 0;

            if (args.Length != 2)
            {
                fehlercode = 1;
                return false;
            }
            filename = args[0];
            if (!File.Exists(filename))
            {
                fehlercode = 2;
                return false;
            }

            if (Path.GetExtension(filename).ToUpper() != ".CSV")
            {
                fehlercode = 3;
                return false;
            }

            if (!decimal.TryParse(args[1], CultureInfo.InvariantCulture , out percent))
            {
                fehlercode = 4;
                return false;
            }

            percent = 1 + percent / 100;
            return true;
        }

        private static string[] ReadCSVFiles(string filename)
        {
            return File.ReadAllLines(filename);
        }

        private static string[] UpdateCSVFile(string[] csvfile, decimal percent)
        {
            string[] newcsvfile = new string[csvfile.Length];

            for (int i = 1; i < csvfile.Length; i++) 
            {
                Product.ConvertOneLine(csvfile[i], percent, out string productCode, out string description, out string taxClass, out decimal retail);
                newcsvfile[i] = productCode + ";" + description + ";" + taxClass + ";" + retail;

            }


            return newcsvfile;
        }
    }
}