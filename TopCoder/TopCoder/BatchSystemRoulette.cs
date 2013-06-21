using System.Collections.Generic;

public class BatchSystemRoulette
{
    public class Item
    {
        public long duration;
        public long ITh;
        public double Expection;
    }

    public class Items : IComparer<Items>
    {
        public long DurationSum;
        public List<Item> list = new List<Item>();
        public int Compare(Items x, Items y)
        {
            return x.DurationSum - y.DurationSum>0?1:(x.DurationSum==y.DurationSum?0:-1);
        }
    }


    public class ItemsList
    {
        public long DurationSum
        {
            get
            {
                if (duration > 0)
                {
                    return duration;
                }
                long sum1 = 0;
                for (int i = 0; i < ListItems.Count; i++)
                {
                    sum1 += ListItems[i].DurationSum;
                }
                duration = sum1;
                return sum1;
            }
        }
        public List<Items> ListItems = new List<Items>();
        public long SameValue;
        private long duration = -1;

    }


    public double[] expectedFinishTimes(int[] duration, string[] user)
    {
        Dictionary<string, Items> dics = new Dictionary<string, Items>();
        for (long i = 0; i < duration.Length; i++)
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
            long sum = 0;
            foreach (Item item in dics[key].list)
            {
                sum += item.duration;
            }
            dics[key].DurationSum = sum;
            items.Add(dics[key]);
        }
        dics.Clear();
        items.Sort(new Items());

        Dictionary<long,ItemsList> dicItems = new Dictionary<long, ItemsList>();
        foreach (Items item in items)
        {
            if (dicItems.ContainsKey(item.DurationSum))
            {
                dicItems[item.DurationSum].ListItems.Add(item);
            }
            else
            {
                ItemsList itemslist = new ItemsList();
                itemslist.SameValue = item.DurationSum;
                itemslist.ListItems.Add(item);
                dicItems.Add(item.DurationSum, itemslist);
            }
        }

        double sum1 = 0;
        foreach (KeyValuePair<long, ItemsList> keyValuePair in dicItems)
        {
            double exp1 = keyValuePair.Value.SameValue*(keyValuePair.Value.ListItems.Count-1.0)/2.0;
            foreach (Items items2 in keyValuePair.Value.ListItems)
            {
                double exp2 = items2.DurationSum/2.0;
                foreach (Item _item in items2.list)
                {
                    _item.Expection = sum1 + exp1 + exp2 + _item.duration/2.0;
                }
            }
            sum1 += keyValuePair.Value.DurationSum;
        }
        double[] result = new double[duration.Length];

        foreach (Items itemse in items)
        {
            foreach (Item _item in itemse.list)
            {
                result[_item.ITh] = _item.Expection;
            }
        }

        return result;
    }
}

