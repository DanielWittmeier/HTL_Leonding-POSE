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
    using System.Globalization;

    public class Product
    {
        public static void ConvertOneLine(string line, decimal percent, out string productCode, out string description, out string taxClass, out decimal retail)
        {
            string[] coloumns = line.Split(';');
            productCode = coloumns[0];
            description = coloumns[1];
            taxClass = coloumns[2];
            retail = decimal.Parse(coloumns[3], CultureInfo.InvariantCulture ) * percent;
        }
    }
}