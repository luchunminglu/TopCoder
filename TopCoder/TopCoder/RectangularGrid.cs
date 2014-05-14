using System;

public class RectangularGrid
{
    public long countRectangles(int width, int height)
    {
        long result = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                for (int k = i+1; k <= width; k++)
                {
                    for (int l = j+1; l <= height; l++)
                    {
                        if (l - j != k - i)
                        {
                            result++;
                        }
                    }
                }
            }
        }
        return result;
    }

}