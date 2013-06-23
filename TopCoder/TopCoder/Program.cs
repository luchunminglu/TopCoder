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
848091, 272744, 37065, 438282
                                              },
                                          new int[]
                                              {
826358, 36950, 198537, 767967, 435356
                                              },
                                          new int[] 
                                          {
184405, 282255, 92828, 600999, 826697
                                          });
            Console.WriteLine(result);
        }
    }







}