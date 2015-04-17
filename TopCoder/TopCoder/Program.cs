using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = new CorruptedMessage().reconstructMessage("abc", 3);
            Console.WriteLine(s);
        }
    }
}