using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DevuAndGame
{
    private bool[] marked;
    public String canWin(int[] nextLevel)
    {
        marked = new bool[nextLevel.Length];
        int index = 0;
        while (!marked[index])
        {
            int next = nextLevel[index];
            if (next == -1)
            {
                return "Win";
            }

            if (next < 0 || next >= nextLevel.Length)
            {
                return "Lose";
            }

            marked[index] = true;
            index = next;
        }

        return "Lose";
    }

}

