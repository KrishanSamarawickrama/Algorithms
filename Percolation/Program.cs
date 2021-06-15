using System;
using System.Collections.Generic;

namespace Percolation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("Calculate percolation threshold via Monte Carlo simulation");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Enter the Grid size : ");
            var strLen = Console.ReadLine();

            Console.WriteLine("Enter the no of trials : ");
            var strT = Console.ReadLine();

            if (int.TryParse(strLen, out int n) && int.TryParse(strT, out int t))
            {
                Random random = new();
                List<double> tList = new();

                for (int i = 0; i < t; i++)
                {
                    Percolation percolation = new Percolation(n);
                    while (!percolation.Percolates())
                    {
                        var row = random.Next(0, n);
                        var col = random.Next(0, n);

                        percolation.Open(row, col);
                    }

                    var T = (double)percolation.NumberOfOpenSites() / (n * n);
                    tList.Add(T);

                    Console.WriteLine($"Number Of Open Sites : {percolation.NumberOfOpenSites()}");
                    Console.WriteLine($"Percolation threshold : {T}");
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.WriteLine($"Mean percolation threshold : {tList.Mean()}");
                Console.WriteLine($"Standard Deviation : {tList.StandardDeviation()}");
            }

            Console.WriteLine("=============================================================");
        }
    }
}