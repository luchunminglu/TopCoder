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
            int result = printers.minTime(2,
                                          new int[]
                                              {
                                             12398, 16350, 41097
                                              },
                                          new int[]
                                              {
373859, 152054, 223916, 395003
                                              },
                                          new int[] 
                                          {
                                             635542, 497593, 500631, 497941
                                          });
            Console.WriteLine(result);
            Console.ReadLine();
            Console.ReadLine();
        }
    }







}