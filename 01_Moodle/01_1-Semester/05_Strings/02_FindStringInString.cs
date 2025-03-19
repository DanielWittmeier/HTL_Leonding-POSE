/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: xAHIF
 *--------------------------------------------------------------
 * Description: FindInString
 *--------------------------------------------------------------
 */

using System;

string text = "Hallo Welt!ll";
string search = "";

//int idx = text.IndexOf(search);

int idx = -1;

for (int i = 0; i < text.Length && idx == -1; i++)
{
    int n;
    for (n = 0; 
         n < search.Length && 
           (n+i) < text.Length &&
           text[i + n] == search[n];
         n++)
    {
    }

    if (n == search.Length)
    {
        idx = i;
    }
}

Console.WriteLine($"\"{text}\" in \"{search}\" at index {idx}");