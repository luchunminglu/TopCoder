using System;
using System.Collections.Generic;

public class CountExpressions2
{

    public int calcExpressions(int x, int y, int val)
    {
        List<Tuple<int,int>> stack = new List<Tuple<int,int>>();
        List<Tuple<string,string,string>> ops = new List<Tuple<string,string,string>>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = i+1; j < 4; j++)
            {
                stack.Add(new Tuple<int, int>(i,j));
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    ops.Add(new Tuple<string, string, string>(i == 0 ? "+" : i == 1 ? "-" : "*", j == 0 ? "+" : j == 1 ? "-" : "*", k == 0 ? "+" : k == 1 ? "-" : "*"));
                }
            }
        }

        int count = 0;
        foreach (var tuple in stack)
        {
            int[] arr = new int[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = y;
            }
            arr[tuple.Item1] = x;
            arr[tuple.Item2] = x;

            foreach (var op in ops)
            {
                int result = 0;
                if (op.Item1 == "+")
                {
                    result = arr[0] + arr[1];
                }
                if (op.Item1 == "-")
                {
                    result = arr[0] - arr[1];
                }
                if (op.Item1 == "*")
                {
                    result = arr[0]*arr[1];
                }

                if (op.Item2 == "+")
                {
                    result = result + arr[2];
                }
                if (op.Item2 == "-")
                {
                    result = result - arr[2];
                }
                if (op.Item2 == "*")
                {
                    result = result * arr[2];
                }


                if (op.Item3 == "+")
                {
                    result = result + arr[3];
                }
                if (op.Item3 == "-")
                {
                    result = result - arr[3];
                }
                if (op.Item3 == "*")
                {
                    result = result * arr[3];
                }

                if (result == val) 
                    count++;
            }
        }

        return x == y ? count/stack.Count : count;
    }
}

