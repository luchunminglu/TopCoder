using System;
using System.Collections.Generic;
using System.Text;

namespace TopCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            GoodString goodString = new GoodString();
            Console.WriteLine(goodString.isGood("aaaaaaaabbbaaabaaabbabababababaabbbbaabbabbbbbbabb"));
        }
    }

    public class GoodString
    {
        public String isGood(String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "Good";
            }

            if (s.Length%2 != 0)
            {
                return "Bad";
            }
            int countA = 0;
            int countB = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    countA++;
                }
                if (s[i] == 'b')
                {
                    countB++;
                }
            }

            if (countA != countB || countA + countB != s.Length)
            {
                return "Bad";
            }

            Stack<Char> stackA = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    stackA.Push(s[i]);
                }
                else if (s[i] == 'b')
                {
                    if (stackA.Count == 0)
                    {
                        return "Bad";
                    }
                    else
                    {
                        stackA.Pop();
                    }
                }

            }

            if (stackA.Count == 0)
            {
                return "Good";
            }
            else
            {
                return "Bad";
            }
        }
    }
}