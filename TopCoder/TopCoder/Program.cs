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
            int result = printers.minTime(0,
                                          new int[]
                                              {
                                                  851225, 629932, 193144, 395060, 75370, 749098, 159313, 673616, 586646,
                                                  153568, 495022, 279116, 899591, 734646, 587157
                                              },
                                          new int[]
                                              {
                                                  283373, 305651, 162774, 850954, 627964, 494793, 595841, 386664, 883734,
                                                  460062, 447811, 637987, 628622, 260559, 980019, 226273
                                              }, new int[] { 780911, 957634, 866639, 567511, 928070, 94303, 42794, 312249, 49545, 532165, 501539, 774903, 787307, 869676, 154728, 460386 });
        }
    }
}