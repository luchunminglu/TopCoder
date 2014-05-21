using System;
using System.Collections.Generic;
using System.Linq;

public class Masterbrain
{
    public int possibleSecrets(String[] guesses, String[] results)
    {
        var list = new List<string>();
        for (int i = 1; i <= 7; i++)
        {
            for (int j = 1; j <= 7; j++)
            {
                for (int k = 1; k <= 7; k++)
                {
                    for (int l = 1; l <= 7; l++)
                    {
                        list.Add("" + i + j + k + l);
                    }
                }
            }
        }
        List<string> totalList = new List<string>();

        for (int i = 0; i < results.Length; i++)
        {
            List<string> all = list.ToList();
            all.RemoveAll(s => Result(s, guesses[i]) == results[i]);
            for (int j = 0; j < results.Length; j++)
            {
                if (j == i)
                {
                    //assume i is the wrong one
                    continue;
                }
                all.RemoveAll(s => Result(s, guesses[j]) != results[j]);
            }
            totalList.AddRange(all);
            totalList.Distinct();
        }

        return totalList.Count;
    }

    public string Result(string secret, string guess)
    {
        int black = 0;
        int white = 0;
        bool[] array = new bool[secret.Length];

        for (int i = 0; i < guess.Length; i++)
        {
            for (int j = 0; j < secret.Length; j++)
            {
                if (!array[j] && secret[j] == guess[i])
                {
                    if (i == j)
                    {
                        black++;
                        array[j] = true;
                        break;
                    }
                    else
                    {
                        white++;
                        array[j] = true;
                        break;
                    }
                }
            }
        }
        return black + "b " + white + "w";
    }
}
