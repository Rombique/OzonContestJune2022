using System;
using System.Collections.Generic;
using System.Linq;

namespace G
{
	class Program
	{
		static void Main(string[] args)
		{
			var firstRow = GetRow();
			var (users, pairs) = (firstRow[0], firstRow[1]);
			//var set = new SortedSet<Edge>();
			var dict = new SortedDictionary<int, SortedSet<int>>();
			for (int i = 0; i < pairs; i++)
			{
				var row = GetRow();
				var (first, second) = (row[0], row[1]);
				if (!dict.TryAdd(first, new SortedSet<int> { second }))
				{
					dict[first].Add(second);
				}
				if (!dict.TryAdd(second, new SortedSet<int> { first }))
				{
					dict[second].Add(first);
				}
			}

			for (var i = 1; i < users + 1; i++)
			{
				if (!dict.TryGetValue(i, out var friends))
				{
					Console.WriteLine("0");
					continue;
				}
				var counts = friends.Select(friend => dict[friend]).SelectMany(recs => recs.Where(p => p != i))
					.Where(x => !friends.Contains(x))
					.GroupBy(p => p).ToDictionary(x => x.Key, y => y.Count());

				if (counts.Count == 0)
				{
					Console.WriteLine("0");
					continue;
				}

				if (counts.Count == 1)
				{
					Console.WriteLine(counts.First().Key);
					continue;
				}
				
				var max = counts.Select(p => p.Value).Max();
				var recommends = counts.Where(p => p.Value == max).Select(p => p.Key).ToArray();
				Array.Sort(recommends);
				Console.WriteLine(string.Join(" ", recommends));
			}
		}

		static int[] GetRow() => Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
	}
	

	public class Edge
	{        
		public int From { get; }

		public int To { get; }

		public Edge(int from, int to)
		{
			From = from;
			To = to;
		}
	}
}
