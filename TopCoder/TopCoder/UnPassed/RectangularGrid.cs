using System;

public class RectangularGrid
{
    public long countRectangles(int width, int height)
    {
        long result = 0;
        long [,] memory = new long[1001,1001];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int maxH = height - j;
                int maxW = width - i;
                if (memory[maxW, maxH] != 0)
                {
                    result += memory[maxW, maxH];
                    continue;
                }
                int cur = 0;
                for (int k = i+1; k <= width; k++)
                {
                    int w = k - i;
                    if (maxH >= w)
                    {
                        cur += maxH - 1;
                    }
                    else
                    {
                        cur += maxH;
                    }
                }
                result += cur;
                memory[maxW, maxH] = memory[maxH, maxW] = cur;
            }
        }



        return result;
    }
}