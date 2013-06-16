using System;
using System.Collections.Generic;
public class TicketPrinters
{
    public int minTime(int currentPrinter, int[] printerDistance, int[] startingValues, int[] wantedValues)
    {
        List<int> wantedUnUsed = new List<int>();
        for (int i = 0; i < wantedValues.Length; i++)
        {
            wantedUnUsed.Add(i);
        }
        return Time(currentPrinter, 0, 0, currentPrinter, currentPrinter, wantedUnUsed, printerDistance, startingValues, wantedValues);
    }
    private int Time(int currentPrinter, int passedTime, int lastTime, int lowPrinter, int highPrinter, List<int> wantedUnUsed, int[] printerDistance, int[] startingValues, int[] wantedValues)
    {
        if (wantedUnUsed.Count == 1)
            return Math.Max(lastTime, Math.Abs(startingValues[currentPrinter] - wantedValues[wantedUnUsed[0]]) + 1 + passedTime);
        int low = lowPrinter - 1;
        int high = highPrinter + 1;
        int min = int.MaxValue;
        foreach (int i in wantedUnUsed)
        {
            int usedTime = Math.Max(lastTime, Math.Abs(startingValues[currentPrinter] - wantedValues[i]) + 1 + passedTime);
            List<int> lleft = new List<int>(wantedUnUsed);
            lleft.Remove(i);
            if (low < 0)
                min = Math.Min(min,Time(high, passedTime + Move(currentPrinter, high, printerDistance), usedTime, lowPrinter, high, lleft, printerDistance, startingValues, wantedValues));
            else if (high >= wantedValues.Length)
                min = Math.Min(min, Time(low, passedTime + Move(low, currentPrinter, printerDistance), usedTime, low, highPrinter, lleft, printerDistance, startingValues, wantedValues));
            else
            {
                List<int> lright = new List<int>(lleft);
                min = Math.Min(min, Math.Min(Time(low, passedTime + Move(low, currentPrinter, printerDistance), usedTime, low, highPrinter, lleft, printerDistance, startingValues, wantedValues), Time(high, passedTime + Move(currentPrinter, high, printerDistance), usedTime, lowPrinter, high, lright, printerDistance, startingValues, wantedValues)));
            }
        }
        return min;
    }
    private int Move(int low, int high, int[] printerDistance)
    {
        int sum = 0;
        for (int i = low; i < high; i++)
        {
            sum += printerDistance[i];
        }
        return sum;
    }
}