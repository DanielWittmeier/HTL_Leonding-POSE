/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ABIFT
*--------------------------------------------------------------
*              Dani Wittmeier
*--------------------------------------------------------------
* Description: Solve DameProblem
* see: https://de.wikipedia.org/wiki/Damenproblem
*--------------------------------------------------------------
*/

namespace DameProblem
{
    public class Dame
    {
        public static bool IsValid(bool[,] field)
        {
            
            if (field[0,0] && field[1,1] || field[field.GetLength(0)-1,0] && field[field.GetLength(1)-2, 1])
            {
                return false;
            }
            
            int numberges = 0;

            for ( int x = 0; x < field.GetLength(0); x++ )
            {
                int number = 0;
                for ( int y = 0; y < field.GetLength(1); y++ )
                {
                    if (field[x,y])
                    {
                        numberges++;
                        number++;
                        if (number > 1 )
                        {
                            return false;
                        }
                    }
                }
            }

            for (int y = 0; y < field.GetLength(1); y++)
            {
                int number = 0;
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    if (field[x, y])
                    {
                        number++;
                        if (number > 1)
                        {
                            return false;
                        }
                    }
                }
            }

            if (numberges == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
