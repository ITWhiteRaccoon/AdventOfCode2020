using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines(@"C:\Dev\Pessoal\Challenges\AdventOfCode2020\input.txt");
            int[] expenseReport = Array.ConvertAll(file, s => int.TryParse(s, out var i) ? i : 0);
            //int[] expenseReport = {1721, 979, 366, 299, 675, 1456};
            Console.WriteLine(ReportRepair(expenseReport, 2020));
        }

        static int ReportRepair(int[] expenseReport, int sum)
        {
            if (expenseReport.Length < 2) { throw new ArgumentException("Array size must be at least 2."); }

            for (int i = 0; i < expenseReport.Length - 1; i++)
            {
                for (int j = i + 1; j < expenseReport.Length; j++)
                {
                    if (expenseReport[i] + expenseReport[j] == sum)
                    {
                        return expenseReport[i] * expenseReport[j];
                    }
                }
            }

            throw new NoResultFoundException();
        }

        [Serializable]
        public class NoResultFoundException : Exception { }
    }
}