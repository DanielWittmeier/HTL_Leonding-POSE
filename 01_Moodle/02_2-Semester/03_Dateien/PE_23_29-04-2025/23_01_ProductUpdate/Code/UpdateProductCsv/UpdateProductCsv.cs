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
    using System.Globalization;
    using System.IO;
    using System.IO.Enumeration;

    public class UpdateProductCsv
    {
        public static int Main(string[] args)
        {
            //TODO: Implement Main method Check / Lesen / Aktualisieren / Speichern
            string filename;
            double percent;
            int fehlercode;

            if (!CheckArguments(args, out filename, out percent, out fehlercode))
            {
                return fehlercode;
            }

            return fehlercode; //0 heißt kein Fehler, 1 für Fehler
        }

        // TODO: Implement methods for Read, Update and Write Csv 
        private static bool CheckArguments(string[] args, out string filename, out double percent, out int fehlercode)
        {
            filename = args[0];
            percent = 0;
            fehlercode = 0;

            if (args.Length != 2)
            {
                fehlercode = 1;
                return false;
            }

            if (!File.Exists(filename))
            {
                fehlercode = 2;
                return false;
            }

            if (!double.TryParse(args[1], CultureInfo.InvariantCulture , out percent))
            {
                fehlercode = 3;
                return false;
            }
            return true;
        }
    }
}