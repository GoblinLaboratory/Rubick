using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RubickReptile;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GoooodAnalysis _ArchdailyAnalysis = new GoooodAnalysis();

            _ArchdailyAnalysis.Load(2);
            int n = 0;
            foreach (var item in _ArchdailyAnalysis.Source)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.ImageUrl);
                Console.WriteLine(item.Link);
                //Console.WriteLine(n);
                //n++;
            }

            Console.Read();
        }
    }
}
