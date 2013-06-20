using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            BatchSystemRoulette b = new BatchSystemRoulette();
            var r = b.expectedFinishTimes(new int[] { 13, 14, 15, 56, 56 }, new string[] { "Tim Speedle", "Tim Speedle", "Tim Speedle", "Horatio Caine", "YEEEAAAAAAAAAAH" });
        }
    }
}