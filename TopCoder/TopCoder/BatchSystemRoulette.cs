using System.Collections.Generic;

public class BatchSystemRoulette
{

    public class Comp : IComparer<KeyValuePair<string, List<Tuple<int, int, string>>>>
    {
        public int Compare(KeyValuePair<string, List<Tuple<int, int, string>>> x, KeyValuePair<string, List<Tuple<int, int, string>>> y)
        {
            int sum1 = 0;
            foreach (Tuple<int, int, string> v1 in x.Value)
            {
                sum1 += v1.Item2;
            }
            int sum2 = 0;
            foreach (Tuple<int, int, string> v2 in y.Value)
            {
                sum2 += v2.Item2;
            }
            return sum1 - sum2;
        }
    }

    public class Tuple<t1,t2,t3>
    {
        public t1 Item1;
        public t2 Item2;
        public t3 Item3;

        public Tuple(t1 tt1, t2 tt2, t3 tt3)
        {
            Item1 = tt1;
            Item2 = tt2;
            Item3 = tt3;
        }
    }

    public double[] expectedFinishTimes(int[] duration, string[] user)
    {
        List<Tuple<int, int, string>> lists = new List<Tuple<int, int, string>>();
        for (int i = 0; i < duration.Length; i++)
        {
            lists.Add(new Tuple<int, int, string>(i, duration[i], user[i]));
        }

        Dictionary<string, List<Tuple<int, int, string>>> dics = new Dictionary<string, List<Tuple<int, int, string>>>();
        foreach (Tuple<int, int, string> item in lists)
        {
            if (dics.ContainsKey(item.Item3))
            {
                dics[item.Item3].Add(item);
            }
            else
            {
                List<Tuple<int, int, string>> l = new List<Tuple<int, int, string>>();
                l.Add(item);
                dics.Add(item.Item3, l);
            }
        }
        List<KeyValuePair<string, List<Tuple<int, int, string>>>> v = new List<KeyValuePair<string, List<Tuple<int, int, string>>>>();
        foreach (KeyValuePair<string, List<Tuple<int, int, string>>> dic in dics)
        {
            v.Add(dic);
        }
        v.Sort(new Comp());
        List<Tuple<int, int, string>> ll = new List<Tuple<int, int, string>>();
        foreach (KeyValuePair<string, List<Tuple<int, int, string>>> keyValuePair in v)
        {
            foreach (Tuple<int, int, string> tuple in keyValuePair.Value)
            {
                ll.Add(tuple);
            }
        }
        double[] result = new double[duration.Length];
        for (int i = 0; i < duration.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < ll.Count; j++)
            {
                sum += ll[j].Item2;
                if (i == ll[j].Item1)
                {
                    break;
                }
            }
            result[i] = sum;
        }
        return result;

    }
}

