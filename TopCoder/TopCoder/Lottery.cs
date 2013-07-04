using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Lottery
{
    public class ITEM
    {
        public double D;
    }

    public String[] sortByOdds(String[] rules)
    {
        Tuple<string,int,int,bool,bool,ITEM>[] tuples = new Tuple<string, int, int, bool, bool,ITEM>[rules.Length];
        for (int i = 0; i < rules.Length; i++)
        {
            string name = rules[i].Substring(0, rules[i].IndexOf(":"));
            string[] sp = rules[i].Substring(rules[i].IndexOf(":") + 1).Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            tuples[i] = new Tuple<string, int, int, bool, bool,ITEM>(name,int.Parse(sp[0]),int.Parse(sp[1]),sp[2]=="T",sp[3]=="T",new ITEM());
        }

        foreach (var tuple in tuples)
        {
            double count = 0;
            if (tuple.Item5)//unique
            {
                if (tuple.Item4) //sorted
                {
                    count = C(tuple.Item2, tuple.Item3);
                }
                else
                {
                    count = C(tuple.Item2, tuple.Item3)*A(tuple.Item3);
                }
            }
            else
            {
                if (tuple.Item4) //sorted
                {
                    count = C(tuple.Item2 + tuple.Item3 - 1, tuple.Item3) ;
                }
                else
                {
                    count = Math.Pow(tuple.Item2,tuple.Item3);
                }
            }
            tuple.Item6.D = (count);
        }

        var v = from r in tuples orderby r.Item6.D , r.Item1 select r.Item1;
        return v.ToArray();
    }
    public static long A(int n)
    {
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    public static long C(int n, int r)
    {
        long res = 1;
        for (int i = 1; i <= r; i++)
        {
            res *= n - i + 1;
        }
        for (int i = 1; i <= r; i++)
        {
            res /= i;
        }
        return res;
    }
}