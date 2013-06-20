using System.Collections.Generic;

public class BatchSystemRoulette
{
    public class Item
    {
        public int duration;
        public int ITh;
    }

    public class Items : IComparer<Items>
    {
        public int DurationSum;
        public List<Item> list = new List<Item>();
        public int Compare(Items x, Items y)
        {
            return x.DurationSum - y.DurationSum;
        }
    }

    public double[] expectedFinishTimes(int[] duration, string[] user)
    {
        Dictionary<string, Items> dics = new Dictionary<string, Items>();
        for (int i = 0; i < duration.Length; i++)
        {
            Item item = new Item();
            item.ITh = i;
            item.duration = duration[i];
            if (dics.ContainsKey(user[i]))
            {
                dics[user[i]].list.Add(item);
            }
            else
            {
                dics.Add(user[i], new Items());
                dics[user[i]].list.Add(item);
            }
        }
        List<Items> items = new List<Items>();
        foreach (string key in dics.Keys)
        {
            int sum = 0;
            foreach (Item item in dics[key].list)
            {
                sum += item.duration;
            }
            dics[key].DurationSum = sum;
            items.Add(dics[key]);
        }
        dics.Clear();
        items.Sort(new Items());
        double[] result = new double[duration.Length];
        double[] before = new double[items.Count+1];
        int j = 0;
        foreach (Items itemse in items)
        {
            int sum = 0;
            foreach (Item item in itemse.list)
            {
                sum += item.duration;
            }
            before[++j] = sum;
        }
        for (int i = 1; i < before.Length; i++)
        {
            before[i] += before[i - 1];
        }
        for (int i = 0; i < result.Length; i++)
        {
            int k = 0;
            foreach (Items itemse in items)
            {
                foreach (Item item in itemse.list)
                {
                    if (i == item.ITh)
                    {
                        result[i] = before[k] + item.duration/2.0 + itemse.DurationSum/2.0;
                        break;
                    }
                }
                k++;
            }
        }


        return result;
    }
}

