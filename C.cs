using System;
using System.Linq;

namespace C
{
	class Program
	{
		static void Main(string[] args)
		{
			var row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var (users, tests, last, index) = (row[0], row[1], 0, 1);
			var array = new int[users];
			for (var i = 0; i < tests; i++)
			{
				var str = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				var (type, userId) = (str[0], str[1]);
				if (type == 1)
				{
					if (userId != 0)
					{
						array[userId - 1] = index;
						index++;
					}
					else
					{
						last = index;
						index++;
					}
				}
				else
				{
					Console.WriteLine(array[userId - 1] > last ? array[userId - 1] : last); 
				}
			}
		}
	}
}
