using System;
using System.Collections.Generic;
using System.Text;

public class TopFox
{

    public int possibleHandles(String familyName, String givenName)
    {
        List<string> dics = new List<string>();
        for (int i = 1; i <= familyName.Length; i++)
        {
            for (int j = 1; j <= givenName.Length; j++)
            {
                string name = familyName.Substring(0, i) + givenName.Substring(0, j);
                if (!dics.Contains(name))
                    dics.Add(name);
            }
        }
        return dics.Count;
    }
}

