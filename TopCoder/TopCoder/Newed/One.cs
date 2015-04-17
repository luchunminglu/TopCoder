using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CorruptedMessage
{
    public string reconstructMessage(string s, int k)
    {
        HashSet<Char> set = new HashSet<char>();
        foreach (var ch in s)
        {
            set.Add(ch);
        }

        bool isFound = false;
        Char c = 'i';
        foreach (var ch in set.ToList())
        {
            if (isFound)
            {
                break;
            }
            c = ch;

            int t = 0;
            foreach (var si in s)
            {
                if (si != c)
                {
                    t++;
                }
            }

            if (t == k)
            {
                isFound = true;
                break;
            }
        }

        if (!isFound)
        {
            c = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList().FirstOrDefault(r => !set.Contains(r));
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            sb.Append(c + "");
        }
        return sb.ToString();
    }
}

