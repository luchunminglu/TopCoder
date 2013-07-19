using System;
using System.Collections.Generic;
using System.Text;

public class Excavations2
{
    public long count(int[] kind, int[] found, int K)
    {
        Dictionary<int,int> kinds = new Dictionary<int, int>();
        Dictionary<int,int> founds = new Dictionary<int, int>();
        for (int i = 0; i < kind.Length; i++)
        {
            if (kinds.ContainsKey(kind[i]))
            {
                kinds[kind[i]]++;
            }
            else
            {
                kinds[kind[i]] = 1;
            }
        }
        for (int i = 0; i < found.Length; i++)
        {
            if (founds.ContainsKey(found[i]))
            {
                founds[found[i]]++;
            }
            else
            {
                founds[found[i]] = 1;
            }
        }

        int count = 0;

    }
}

