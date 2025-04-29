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
    using System.Globalization;

    public class Product
    {
        // TODO Implement methods for converting from and to Csv line
        public static void ConvertOneLine(string line, decimal percent, out string productCode, out string description, out string taxClass, out decimal retail)
        {
            string[] coloumns = line.Split(';');
            productCode = coloumns[0];
            description = coloumns[1];
            taxClass = coloumns[2];
            retail = decimal.Parse(coloumns[3]) * percent;
        }

        public static string ConvertToCSVLine(string productCode, string description, string taxClass, decimal retail)
        {
            return productCode + ";" + description + ";" + taxClass + ";" + retail;
        }
    }
}