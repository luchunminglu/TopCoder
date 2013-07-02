using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LargestCircle2
{
    public int radius(String[] grid)
    {
        if (grid == null || grid.Length <= 1)
        {
            return 0;
        }
        string s = grid[0];
        if (s == null || s.Length <= 1)
        {
            return 0;
        }

        int w = s.Length + 1;
        int h = grid.Length + 1;
        int max = 0;
        for (int i = 1; i < w - 1; i++)
        {
            for (int j = 1; j < h - 1; j++)
            {
                int radius = Math.Min(i, Math.Min(j, Math.Min(w - i - 1, h - j - 1)));

                for (int r = radius; r > 0; r--)
                {
                    bool choice = true;
                    for (int k = 0; k < w - 1; k++)
                    {
                        for (int l = 0; l < h - 1; l++)
                        {
                            if (!choice)
                            {
                                break;
                            }

                            if (((i - k - 1) * (i - k - 1) + (j - l - 1) * (j - l - 1)) < r * r &&
                                ((i - k) * (i - k) + (j - l) * (j - l)) > r * r)
                            {
                                if (grid[l][k] !=
                                    '.')
                                {
                                    choice = false;
                                }
                            }
                        }
                    }
                    if (choice)
                        max = Math.Max(max, r);
                }
            }
        }

        return max;
    }
}

