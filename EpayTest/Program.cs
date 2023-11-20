using System;
using System.Collections.Generic;

class Program
{
    static readonly int[] denominations = { 100, 50, 10 };
    static readonly Dictionary<int, string> names = new ()
    {
        { 100, "100 EUR" },
        { 50, "50 EUR" },
        { 10, "10 EUR" }
    };

    static int CountCombs(int left, int i, List<Tuple<int, int>> comb, Tuple<int, int>? add)
    {
        if (add != null) comb.Add(add);
        if (left == 0 || (i + 1) == denominations.Length)
        {
            if ((i + 1) == denominations.Length && left > 0)
            {
                if (left % denominations[i] != 0)
                    return 0;
                comb.Add(new Tuple<int, int>(left / denominations[i], denominations[i]));
                i += 1;
            }
            while (i < denominations.Length)
            {
                comb.Add(new Tuple<int, int>(0, denominations[i]));
                i += 1;
            }
            Console.WriteLine(string.Join(" + ", comb.Where(x=>x.Item1>0).Select(x => $"{x.Item1} x {names[x.Item2]}")));
            return 1;
        }
        int cur = denominations[i];
        return Enumerable.Range(0, (int)(left / cur) + 1)
            .Sum(x => CountCombs(left - x * cur, i + 1, new List<Tuple<int, int>>(comb), new Tuple<int, int>(x, cur)));

        
    }

    static void Main(string[] args)
    {
        CountCombs(30, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(50, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(60, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(80, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(140, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(230, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(370, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(610, 0, new List<Tuple<int, int>>(), null);
        Console.WriteLine("----------------------------");
        CountCombs(980, 0, new List<Tuple<int, int>>(), null);


    }
}

