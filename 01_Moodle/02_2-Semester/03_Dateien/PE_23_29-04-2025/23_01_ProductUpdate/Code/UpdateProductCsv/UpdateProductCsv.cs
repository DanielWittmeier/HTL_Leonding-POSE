/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ABIFT
*--------------------------------------------------------------
*              Dani Wittmeier
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
            string filename;
            decimal percent;

            if (!CheckArguments(args, out filename, out percent))
            {
                return 1;
            }

            string[] csvfile = ReadCSVFiles(filename);

            //Backup erstellen
            File.Delete(Path.GetFileNameWithoutExtension(args[0]) + ".bak");
            File.Move(filename, Path.GetFileNameWithoutExtension(args[0]) + ".bak");

            //Neue Datei erstellen
            File.WriteAllLines(Path.GetFileNameWithoutExtension(args[0]) + ".$$$", UpdateCSVFile(csvfile, percent));
            File.Move(Path.GetFileNameWithoutExtension(args[0]) + ".$$$", Path.GetFileNameWithoutExtension(args[0]) + ".csv");

            return 0;
        }

        private static bool CheckArguments(string[] args, out string filename, out decimal percent)
        {
            filename = "";
            percent = 0;

            if (args.Length != 2)
            {
                return false;
            }

            filename = args[0];
            if (!File.Exists(filename) || Path.GetExtension(filename).ToUpper() != ".CSV" || !decimal.TryParse(args[1], CultureInfo.InvariantCulture, out percent))
            {
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

            newcsvfile[0] = csvfile[0];

            for (int i = 1; i < csvfile.Length; i++) 
            {
                Product.ConvertOneLine(csvfile[i], percent, out string productCode, out string description, out string taxClass, out decimal retail);
                newcsvfile[i] = productCode + ";" + description + ";" + taxClass + ";" + Math.Round(retail, 2).ToString(CultureInfo.InvariantCulture);

            }

            return newcsvfile;
        }
    }
}