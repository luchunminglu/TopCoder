using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketPrinters printers = new TicketPrinters();
            int result = printers.minTime(2, new int[] { 13, 26, 39, 13 }, new int[] { 123, 12, 32, 67, 1015 }, new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(result);
        }
    }
}