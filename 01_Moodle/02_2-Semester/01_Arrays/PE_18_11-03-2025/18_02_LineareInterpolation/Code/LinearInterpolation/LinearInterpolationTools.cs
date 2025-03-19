/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ABIFT
*--------------------------------------------------------------
*              Wittmeier Daniel
*--------------------------------------------------------------
* Description: linear Interpolation
*--------------------------------------------------------------
*/

namespace LinearInterpolation
{
    public static class LinearInterpolationTools
    {
        public static double Calculate(double x, double[] xValues, double[] yValues)
        {
            int minX, maxX, index;

            //Bei Fehlerhaften Eingabe der Messpunkte
            if (xValues.Length < yValues.Length || xValues.Length > yValues.Length || xValues.Length == 0)
            {
                return 0.0;
            }
            //------------------------------------------------------------------------------

            //Überprüfung ob der angegebene Wert einen Messpunkt entspricht
            for (int i = 0; i < xValues.Length; i++)
            {
                if (xValues[i] == x)
                {
                    return yValues[i];
                }
            }
            //------------------------------------------------------------------------------

            //Den nächst kleineren Wert ermitteln
            minX = -1;
            for (int i = 0; i < xValues.Length; i++)
            {
                if (xValues[i] < x)
                {
                    if (minX < 0 || xValues[minX] < xValues[i])
                    {
                        minX = i;
                    }
                }
            }

            //Falls es keinen kleineren gibt, den kleinsten Messwert zurückgeben
            if (minX == -1)
            {
                index = 0;
                for (int i = 1; i < xValues.Length; i++)
                {
                    if (xValues[index] > xValues[i] )
                    {
                        index = i;
                    }
                }
                return yValues[index];
            }
            //------------------------------------------------------------------------------

            //Den nächst größeren Wert ermitteln
            maxX = -1;
            for (int i = 0; i < xValues.Length; i++)
            {
                if (xValues[i] > x)
                {
                    if (maxX < 0 || xValues[maxX] > xValues[i])
                    {
                        maxX = i;
                    }
                }
            }
            //Falls es keinen kleineren gibt, den kleinsten Messwert zurückgeben
            if (maxX == -1)
            {
                index = 0;
                for (int i = 1; i < xValues.Length; i++)
                {
                    if (xValues[index] < xValues[i])
                    {
                        index = i;
                    }
                }
                return yValues[index];
            }
            //------------------------------------------------------------------------------

            return yValues[minX] + (x - xValues[minX]) * (yValues[maxX] - yValues[minX]) / (xValues[maxX] - xValues[minX]);
        }
    }
}