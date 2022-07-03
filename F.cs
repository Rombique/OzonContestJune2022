using System;
using System.Collections.Generic;
using System.Linq;

namespace F
{
	class Program
	{
		static void Main(string[] args)
		{
			var tests = int.Parse(GetRow());
			for (var i = 0; i < tests; i++)
			{
				var rows = int.Parse(GetRow());
				var seconds = new SortedSet<int>();
				var result = "YES";
				for (var a = 0; a < rows; a++)
				{
					var dates = GetRow().Split('-').Select(p => p.Split(":").Select(int.Parse).ToArray()).ToArray();
					if (result != "YES")
					{
						continue;
					}
					if (!IsTimeCorrect(dates[0]) || !IsTimeCorrect(dates[1]))
					{
						result = "NO";
						continue;
					}

					var (first, second) = GetTimes(dates[0], dates[1]);
					if (second - first < 0)
					{
						result = "NO";
						continue;
					}

					var beforeAdd = seconds.Count;
					for (var b = first; b <= second; b++)
					{
						seconds.Add(b);
					}

					var added = second + 1 - first;

					if (a == 0)
					{
						continue;
					}
					var afterAdd = seconds.Count;
					
					if (afterAdd - beforeAdd != added)
					{
						result = "NO";
					}
				}
				Console.WriteLine(result);
			}
		}

		static string GetRow() => Console.ReadLine();

		static bool IsTimeCorrect(int[] date)
		{
			return (date[0] >= 0 && date[0] <= 23) && 
			       (date[1] >= 0 && date[1] <= 59) &&
			       (date[2] >= 0 && date[2] <= 59);
		}

		static (int, int) GetTimes(int[] first, int[] second)
		{
			return (first[0] * 3600 + first[1] * 60 + first[2], second[0] * 3600 + second[1] * 60 + second[2]);
		}
	}
}
