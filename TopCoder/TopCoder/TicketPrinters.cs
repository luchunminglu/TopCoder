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
        return TimeWithOutMemory(currentPrinter, dics, currentPrinter, 0, 0, currentPrinter, currentPrinter, wantedUnUsed, startingValues, wantedValues);
    }


    private int TimeWithOutMemory(int currentPrinter, int passedTime, int lastTime, int lowPrinter,
                     int highPrinter, List<int> wantedUnUsed, int[] startingValues,
                     int[] wantedValues)
    {
        if (wantedUnUsed.Count == 1)
        {
            return Math.Max(lastTime,
                            Math.Abs(startingValues[currentPrinter] - wantedValues[wantedUnUsed[0]]) + 1 + passedTime);
        }

        int low = lowPrinter - 1;
        int high = highPrinter + 1;
        int min = int.MaxValue;
        foreach (int i in wantedUnUsed)
        {
            int usedTime = Math.Max(lastTime,
                                    Math.Abs(startingValues[currentPrinter] - wantedValues[i]) + 1 + passedTime);
            List<int> lleft = new List<int>(wantedUnUsed);
            lleft.Remove(i);
            if (low < 0)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(high, pos[high] - pos[currentPrinter] + passedTime, usedTime, lowPrinter, high,
                                                 lleft, startingValues, wantedValues));
            }
            else if (high >= wantedValues.Length)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(low, pos[currentPrinter] - pos[low] + passedTime, usedTime, low,
                                                 highPrinter, lleft, startingValues, wantedValues));
            }
            else
            {
                List<int> lright = new List<int>(lleft);
                min = Math.Min(min, Math.Min(TimeWithOutMemory(high, pos[high] - pos[currentPrinter] + passedTime, usedTime, lowPrinter, high,
                                                 lleft, startingValues, wantedValues), TimeWithOutMemory(low, pos[currentPrinter] - pos[low] + passedTime, usedTime, low,
                                                 highPrinter, lright, startingValues, wantedValues)));
            }
        }

        return min;
    }


    private int TimeWithOutMemory(int currentPrinter, int lastPrinter, int passedTime, int lastTime, int lowPrinter,
                                  int highPrinter, List<int> wantedUnUsed, int[] startingValues,
                                  int[] wantedValues)
    {
        if (wantedUnUsed.Count == 1)
        {
            return Math.Max(lastTime,
                            passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]) +
                            Math.Abs(startingValues[currentPrinter] - wantedValues[wantedUnUsed[0]]) + 1);
        }

        int low = lowPrinter - 1;
        int high = highPrinter + 1;
        int min = int.MaxValue;

        foreach (int i in wantedUnUsed)
        {
            int usedTime = Math.Max(lastTime, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]) +
                                              Math.Abs(startingValues[currentPrinter] - wantedValues[i]) + 1);
            List<int> lleft = new List<int>(wantedUnUsed);
            lleft.Remove(i);
            if (low < 0)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(high, currentPrinter,
                                                 passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime,
                                                 lowPrinter, high, lleft, startingValues, wantedValues));
            }
            else if (high >= wantedValues.Length)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(low, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, low,
                                                 highPrinter, lleft, startingValues, wantedValues));
            }
            else
            {
                List<int> lright = new List<int>(lleft);
                min = Math.Min(min, Math.Min(TimeWithOutMemory(high, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, lowPrinter, high,
                                                 lleft, startingValues, wantedValues), TimeWithOutMemory(low, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, low,
                                                 highPrinter, lright, startingValues, wantedValues)));
            }
        }
        return min;
    }




    private int TimeWithOutMemory(int currentPrinter, Dictionary<string, int> dics, int lastPrinter, int passedTime, int lastTime, int lowPrinter,
                                  int highPrinter, List<int> wantedUnUsed, int[] startingValues,
                                  int[] wantedValues)
    {
        item.CurrentPrinter = currentPrinter;
        item.LastPrinter = lastPrinter;
        item.wantedUnUsed = wantedUnUsed;
        item.passTime = passedTime;
        item.lastTime = lastTime;
        string key = item.ToString();
        if (dics.ContainsKey(key))
        {
            return dics[key];
        }

        if (wantedUnUsed.Count == 1)
        {
            int result = Math.Max(lastTime,
                            passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]) +
                            Math.Abs(startingValues[currentPrinter] - wantedValues[wantedUnUsed[0]]) + 1);
            dics[key] = result;
            return result;
        }

        int low = lowPrinter - 1;
        int high = highPrinter + 1;
        int min = int.MaxValue;

        foreach (int i in wantedUnUsed)
        {
            int usedTime = Math.Max(lastTime, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]) +
                                              Math.Abs(startingValues[currentPrinter] - wantedValues[i]) + 1);
            List<int> lleft = new List<int>(wantedUnUsed);
            lleft.Remove(i);
            if (low < 0)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(high, dics, currentPrinter,
                                                 passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime,
                                                 lowPrinter, high, lleft, startingValues, wantedValues));
            }
            else if (high >= wantedValues.Length)
            {
                min = Math.Min(min,
                               TimeWithOutMemory(low, dics, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, low,
                                                 highPrinter, lleft, startingValues, wantedValues));
            }
            else
            {
                List<int> lright = new List<int>(lleft);
                min = Math.Min(min, Math.Min(TimeWithOutMemory(high, dics, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, lowPrinter, high,
                                                 lleft, startingValues, wantedValues), TimeWithOutMemory(low, dics, currentPrinter, passedTime + Math.Abs(pos[lastPrinter] - pos[currentPrinter]), usedTime, low,
                                                 highPrinter, lright, startingValues, wantedValues)));
            }
        }
        dics[key] = min;
        return min;
    }




    private int[] pos;
    public class Item
    {
        public int CurrentPrinter;
        public int LastPrinter;
        public List<int> wantedUnUsed;
        public int passTime;
        public int lastTime;
        public override string ToString()
        {
            StringBuilder list = new StringBuilder("(");
            foreach (int j in wantedUnUsed)
            {
                list.Append(j + ",");
            }
            list.Append(")");
            return string.Format("({0},{1},{2})", CurrentPrinter, LastPrinter, list, passTime, lastTime);
        }
    }
    static Item item = new Item();

}