using System;

/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 3ABIFT
 *--------------------------------------------------------------
 *              Wittmeier Daniel
 *--------------------------------------------------------------
 * Description:

 *--------------------------------------------------------------
*/
bool isTrue;
int arrayLength, lowerBound, upperBound;
int[] count;
int incount = 0;
Console.WriteLine("Array Statistic");
Console.WriteLine("**********************");

Console.Write("Please enter the count of numbers: ");
isTrue = int.TryParse(Console.ReadLine(), out arrayLength);
count = new int[arrayLength];

for (int i = 0; i < count.Length; i++)
{
    Console.Write($"Please enter {i + 1}. number: ");
    isTrue = int.TryParse(Console.ReadLine(), out count[i]);
}

Console.Write("Please enter lower bound: ");
isTrue = int.TryParse(Console.ReadLine(), out lowerBound);

Console.Write("Please enter upper bound: ");
isTrue = int.TryParse(Console.ReadLine(), out upperBound);

for (int i = 0; i < count.Length; i++)
{
    if (count[i] >= lowerBound && count[i] <= upperBound)
    {
        incount++;
    }
}
Console.WriteLine($"{incount} numbers are in the range of [{lowerBound}..{upperBound}]");
Console.WriteLine("**********************");

