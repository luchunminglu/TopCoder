using System;
using System.Collections.Generic;
using System.Text;

public class TicketPrinters
{
    public int minTime(int currentPrinter, int[] printerDistance, int[] startingValues, int[] wantedValues)
    {
        List<int> wantedUnUsed = new List<int>();
        for (int i = 0; i < wantedValues.Length; i++)
        {
            wantedUnUsed.Add(i);
        }
        pos = new int[startingValues.Length];
        for (int i = 1; i < pos.Length; i++)
        {
            pos[i] = pos[i - 1] + printerDistance[i - 1];
        }
        Dictionary<string, int> dics = new Dictionary<string, int>();
        return Time(currentPrinter, dics, 0, 0, currentPrinter, currentPrinter, wantedUnUsed, printerDistance, startingValues, wantedValues);
    }

    private int[] pos;
    public class Item
    {
        public int CurrentPrinter;
        public int LowPrinter;
        public List<int> wantedUnUsed;
        public override string ToString()
        {
            StringBuilder list = new StringBuilder("(");
            foreach (int j in wantedUnUsed)
            {
                list.Append(j + ",");
            }
            list.Append(")");
            return string.Format("({0},{1},{2})", CurrentPrinter, LowPrinter, list);
        }
    }
    static Item item = new Item();
    private int Time(int currentPrinter, Dictionary<string, int> dics, int passedTime, int lastTime, int lowPrinter, int highPrinter, List<int> wantedUnUsed, int[] printerDistance, int[] startingValues, int[] wantedValues)
    {
        if (wantedUnUsed.Count == 1)
            return Math.Max(lastTime, Math.Abs(startingValues[currentPrinter] - wantedValues[wantedUnUsed[0]]) + 1 + passedTime);

    
        int low = lowPrinter - 1;
        int high = highPrinter + 1;
        int min = int.MaxValue;
        int choice = 0;
        foreach (int i in wantedUnUsed)
        {
            int usedTime = Math.Max(lastTime, Math.Abs(startingValues[currentPrinter] - wantedValues[i]) + 1 + passedTime);
            List<int> lleft = new List<int>(wantedUnUsed);
            lleft.Remove(i);
            item.wantedUnUsed = lleft;
            if (low < 0)
            {
                item.LowPrinter = lowPrinter;
                item.CurrentPrinter = high;
                int cur = -1;
                if (dics.ContainsKey(item.ToString()))
                {
                    cur = dics[item.ToString()];
                }
                else
                {
                    cur = Time(high, dics, passedTime + Move(currentPrinter, high, printerDistance), usedTime,
               lowPrinter, high, lleft, printerDistance, startingValues, wantedValues);
                }

                if (cur < min)
                {
                    choice = i;
                    min = cur;
                }
            }
            else if (high >= wantedValues.Length)
            {
                int cur = -1;
                item.LowPrinter = low;
                item.CurrentPrinter = low;
                if (dics.ContainsKey(item.ToString()))
                {
                    cur = dics[item.ToString()];
                }
                else
                {
                    cur = Time(low, dics, passedTime + Move(low, currentPrinter, printerDistance), usedTime, low,
                               highPrinter, lleft, printerDistance, startingValues, wantedValues);
                }
                if (cur < min)
                {
                    choice = i;
                    min = cur;
                }
            }
            else
            {
                List<int> lright = new List<int>(lleft);
                item.CurrentPrinter = low;
                int curl = -1;
                int curr = -1;
                item.LowPrinter = low;
                if (dics.ContainsKey(item.ToString()))
                {
                    curl = dics[item.ToString()];
                }
                else
                {
                    curl =
                        Time(low, dics, passedTime + Move(low, currentPrinter, printerDistance), usedTime,
                             low, highPrinter, lleft, printerDistance, startingValues, wantedValues);
                }

                item.LowPrinter = lowPrinter;
                item.CurrentPrinter = high;
                if (dics.ContainsKey(item.ToString()))
                {
                    curr = dics[item.ToString()];
                }
                else
                {
                    curr = Time(high, dics, passedTime + Move(currentPrinter, high, printerDistance), usedTime,
                                lowPrinter, high, lright, printerDistance, startingValues, wantedValues);
                }
                int curmin = Math.Min(curl, curr);

                if (min > curmin)
                {
                    min = curmin;
                    choice = i;
                }
            }
        }
        List<int> llef = new List<int>(wantedUnUsed);
        llef.Remove(choice);
        item.LowPrinter = lowPrinter;
        item.wantedUnUsed = llef;
        item.CurrentPrinter = currentPrinter;

        if (dics.ContainsKey(item.ToString()))
        {
            dics[item.ToString()] = Math.Min(min, dics[item.ToString()]);
        }
        else
        {
            dics[item.ToString()] = min;
        }
        return min;
    }
    private int Move(int low, int high, int[] printerDistance)
    {
        int sum = 0;
        for (int i = low; i < high; i++)
        {
            sum += printerDistance[low];
        }
        return sum;
    }
}