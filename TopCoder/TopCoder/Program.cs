using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            ChickenOracle o = new ChickenOracle();
            Console.WriteLine(o.theTruth(1000,500,250,250));
        }
    }
}