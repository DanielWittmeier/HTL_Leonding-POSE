using System;

/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description:

 *--------------------------------------------------------------
*/

int[] lettercount = new int[27];
string[] letternames = {"A: ","B: ", "C: ", "D: ", "E: ", "F: ", "G: ", "H: ", "I: ", "J: ", "K: ", "L: ", "M: ", "N: ", "O: ", "P: ", "Q: ", "R: ", "S: ", "T: ", "U: ", "V: ", "W: ", "X: ", "Y: ", "Z: ","Other: " };
string input;
char inputletter;
int inputletterindex;

Console.WriteLine("Letter-Count");

Console.Write("Please enter a text: ");
input = Console.ReadLine();

for (int i = 0; i < input.Length; i++)
{
    inputletter = input[i];

    //Kleinbuchstaben von a - z
    if ((int)inputletter >= 97 && (int)inputletter <= 122)
    {
        inputletterindex = (int)inputletter - 97;
        lettercount[inputletterindex]++;
    }
    //Großbuchstaben von A - Z
    else if ((int)inputletter >= 65 && (int)inputletter <= 90)
    {
        inputletterindex = (int)inputletter - 65;
        lettercount[inputletterindex]++;
    }
    else
    {
        switch ((int)inputletter)
        {
            //Bei eingabe von ü oder Ü
            case 252:
            case 220:
                lettercount[20]++;
                lettercount[4]++;
                break;
            //Bei eingabe von ä oder Ä
            case 228:
            case 196:
                lettercount[0]++;
                lettercount[4]++;
                break;
            //Bei eingabe von ö oder Ö
            case 246:
            case 214:
                lettercount[14]++;
                lettercount[4]++;
                break;
            //Alle sonstigen eingaben
            default:
                lettercount[26]++;
                break;
        }
    }
}

Console.WriteLine("");
for (int i = 0; i < 13; i++)
{
    Console.WriteLine($"{letternames[i]} {lettercount[i],-4} {letternames[i+13]} {lettercount[i+13]}");
}
Console.WriteLine($"{letternames[26]} {lettercount[26]}");
   
