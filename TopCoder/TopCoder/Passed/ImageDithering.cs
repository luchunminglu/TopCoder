using System;

public class ImageDithering
{
    public int count(String dithered, String[] screen)
    {
        int sum = 0;
        foreach (string s in screen)
        {
            foreach (char c in s)
            {
                if (dithered.Contains(c + ""))
                {
                    sum++;
                }
            }
        }
        return sum;
    }
}
