using System;
using System.Linq;

namespace B
{
	class Program
	{
		static void Main(string[] args)
		{
			var totalTests = int.Parse(Console.ReadLine());
			for (int i = 0; i < totalTests; i++)
			{
				Console.ReadLine();
				var skills = Console.ReadLine()
					.Split(' ')
					.Select(int.Parse)
					.ToArray();
				var set = Enumerable.Range(0, skills.Length).ToHashSet();
				
				while (set.Count != 0)
				{
					var min = set.Min();
					var diff = int.MaxValue;
					var res = 0;
					
					for (var a = min + 1; a < skills.Length; a++)
					{
						if (!set.Contains(a))
						{
							continue;
						}

						var currentDiff = skills[min] - skills[a];
						if (Math.Abs(currentDiff) >= Math.Abs(diff))
						{
							continue;
						}
							
						diff = currentDiff;
						res = a;
					}
					Console.WriteLine($"{min + 1} {res + 1}");
					set.Remove(min);
					set.Remove(res);
				}
				Console.WriteLine();
			}
		}
	}
}
