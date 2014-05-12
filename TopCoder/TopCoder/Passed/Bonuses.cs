using System.Collections.Generic;
using System.Linq;

public class Bonuses
{
    public int[] getDivision(int[] points)
    {
        int sum = points.Sum();
        //index, points, bonus
        var tuples = new List<Tuple>();
        for (int i = 0; i < points.Length; i++)
        {
            tuples.Add(new Tuple(i, points[i], 0));
        }

        tuples = tuples.OrderByDescending(r => r.Item2).ThenBy(r => r.Item1).ToList();
        int extras = 0;
        foreach (Tuple tuple in tuples)
        {
            tuple.Item3 = tuple.Item2*100/sum;
            extras += tuple.Item2*100%sum;
        }
        extras = extras/sum;
        for (int i = 0; i < extras; i++)
        {
            tuples[i].Item3++;
        }
        return tuples.OrderBy(r => r.Item1).Select(r => r.Item3).ToArray();
    }

    private class Tuple
    {
        public readonly int Item1;
        public readonly int Item2;
        public int Item3;

        public Tuple(int i1, int i2, int i3)
        {
            Item1 = i1;
            Item2 = i2;
            Item3 = i3;
        }
    }
}
