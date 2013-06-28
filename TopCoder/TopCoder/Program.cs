using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int expected = 121;
            Program printers = new Program();
            int result = printers.minTime(7,
                                          new int[]
                                          {
1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
                                          },
                                          new int[]
                                          {
1, 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000
                                          },
                                          new int[] 
                                          {
70120, 80119, 120075, 90114, 10042, 20065, 100105, 30084, 140029, 15, 130054, 110092, 50110, 150000, 60117, 40099
                                          }
                                          );
            Console.WriteLine(result);
            Console.WriteLine("result should = "+expected);
            Console.ReadLine();
        }





        public int minTime(int currentPrinter, int[] printerDistance, int[] startingValues, int[] wantedValues)
        {
            int n = startingValues.Length;
            int[] pos = new int[n];
            for (int i = 1; i < n; i++)
            {
                pos[i] = pos[i - 1] + printerDistance[i - 1];
            }
            int[, ,] dp = new int[2, n, 1 << n];
            for (int side = 0; side < 2; side++)
            {
                for (int at = 0; at < n; at++)
                {
                    for (int set = 0; set < 1 << n; set++)
                    {
                        dp[side, at, set] = -1;
                    }
                }
            }

            return go(currentPrinter, currentPrinter, (1 << n) - 1, 0, n, pos, printerDistance, startingValues,
                      wantedValues, dp, n);
        }


        private int go(int min, int max, int rem, int side, int n, int[] pos, int[] printerDistance,
                       int[] startingValues, int[] wantedValues, int[, ,] dp, int bits)
        {
            if (rem == 0)
                return 0;
            if (dp[side, min, rem] != -1)
                return dp[side, min, rem];
            int ret = int.MaxValue / 3;
            for (int i = 0; i < n; i++)
            {
                if ((rem >> i & 1) > 0)
                {
                    int at;
                    if (side == 0)
                        at = min;
                    else
                    {
                        at = max;
                    }
                    int t = Math.Abs(wantedValues[i] - startingValues[at] + 1);
                    if (bits == 1)
                    {
                        ret = t;
                        continue;
                    }
                    int cur = int.MaxValue;
                    int nrem = rem ^ (1 << i);

                    if (side == 0)
                    {
                        if (min > 0)
                            cur = Math.Min(cur,
                                           pos[min] - pos[min - 1] +
                                           go(min - 1, max, nrem, side, n, pos, printerDistance, startingValues,
                                              wantedValues, dp, bits - 1));
                        if (max + 1 < n)
                            cur = Math.Min(cur,
                                           pos[max + 1] - pos[min] +
                                           go(min, max + 1, nrem, side ^ 1, n, pos, printerDistance, startingValues,
                                              wantedValues, dp, bits - 1));
                    }
                    else
                    {
                        if (min > 0)
                            cur = Math.Min(cur,
                                           pos[max] - pos[min - 1] +
                                           go(min - 1, max, nrem, side^1, n, pos, printerDistance, startingValues,
                                              wantedValues, dp, bits - 1));
                        if (max + 1 < n)
                            cur = Math.Min(cur,
                                           pos[max + 1] - pos[max] +
                                           go(min, max + 1, nrem, side, n, pos, printerDistance, startingValues,
                                              wantedValues, dp, bits - 1));
                    }
                    cur = Math.Max(cur, t);
                    ret = Math.Min(ret, cur);
                }
            }
            return dp[side,min,rem];
        }


    }






}