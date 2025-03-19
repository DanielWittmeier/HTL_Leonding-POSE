using System;
using System.Security.AccessControl;

namespace GradeStatistic
{
    class Program
    {
        private const int MaxGrad = 6;
        private const int MinGrad = 2;

        public static void Main()
        {
            int[] gradeCounts = new int[MaxGrad-MinGrad+1];

            int grade = ReadGrade();

            while (grade > 0)
            {
                gradeCounts[GradToIndex(grade)]++;

                grade = ReadGrade();
            }

            PrintResult(gradeCounts);
        }

        static void PrintResult(int[] gradeCounts)
        {
            for (int i = 0; i < gradeCounts.Length; i++)
            {
                int gradeCount = gradeCounts[i];

                Console.WriteLine($"{IndexToGrade(i)}: {gradeCount}");
            }
        }

        static int GradToIndex(int grade)
        {
            return grade - MinGrad;
        }

        static int IndexToGrade(int idx)
        {
            return idx + MinGrad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>1-5 if valid, 0 invalid</returns>
        static int ReadGrade()
        {
            Console.Write("Grade: ");
            int grade = int.Parse(Console.ReadLine());

            return grade >= MinGrad && grade <= MaxGrad ? grade : 0;
        }
    }
}
 