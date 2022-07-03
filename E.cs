using System;
using System.Collections.Generic;
using System.Linq;

namespace E
{
	class Program
	{
		static void Main(string[] args)
		{
			var totalTests = int.Parse(Console.ReadLine());
			for (var i = 0; i < totalTests; i++)
			{
				Console.ReadLine();
				var tasks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				var set = new HashSet<int>();
				var res = "YES";
				for (var a = 0; a < tasks.Length - 1; a++)
				{
					if (set.Contains(tasks[a]))
					{
						res = "NO";
						break;
					}
					if (tasks[a] != tasks[a + 1])
					{
						set.Add(tasks[a]);
					}
				}

				if (res == "YES" && tasks[^1] != tasks[^2] && set.Contains(tasks[^1]))
				{
					res = "NO";
				}
				Console.WriteLine(res);
			}
		}
	}
}
