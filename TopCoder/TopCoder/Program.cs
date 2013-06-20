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
            var r = b.expectedFinishTimes(new int[] { 3, 2, 4, 1 }, new string[] { "mac taylor", "Mac Taylor", "Mac Taylor", "Peyton Driscoll" });
        }
    }
}