using System;
using System.Collections.Generic;
using System.Linq;

namespace H
{
	class Program
	{
		static void Main(string[] args)
		{
			var tests = int.Parse(Console.ReadLine());
			for (var i = 0; i < tests; i++)
			{
				var info = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				var rowCount = info[0];
				var hexagons = new Dictionary<string, HashSet<(int, int)>>();
				var verified = new Dictionary<string, HashSet<(int, int)>>();

				for (var a = 0; a < rowCount; a++)
				{
					var rowValues = Console.ReadLine().Split('.').Where(p => !string.IsNullOrEmpty(p)).ToArray();
					for (var b = 0; b < rowValues.Length; b++)
					{
						var color = rowValues[b];
						if (!verified.TryGetValue(color, out _))
						{
							verified.Add(color, new HashSet<(int, int)> { (b, a) });
							hexagons.Add(color, new HashSet<(int, int)>());
						}
						else
						{
							hexagons[color].Add((b, a));
						}
					}
				}


				for (int m = 0; m < rowCount; m++)
				{
					foreach (var item in hexagons.Where(p => p.Value.Count > 0))
					{
						var type = item.Key;
						var verifiedNodes = verified[type];
						var colorNotVerified = hexagons[type];
						var colorNotVerifiedCopy = new HashSet<(int, int)>(colorNotVerified);
						foreach (var (b, a) in colorNotVerifiedCopy)
						{
							var left = (b - 1, a);
							var right = (b + 1, a);
							var topLeft = (b, a - 1);
							var topRight = (b + 1, a - 1);
							var botRight = (b + 1, a + 1);
							var botLeft = (b, a + 1);
							if (a % 2 == 0)
							{
								topLeft = (b - 1, a - 1);
								topRight = ( b, a - 1);
								botRight = ( b, a + 1);
								botLeft = (b - 1, a + 1);
							}

							if (verifiedNodes.Contains(left)
							    || verifiedNodes.Contains(right)
							    || verifiedNodes.Contains(topLeft)
							    || verifiedNodes.Contains(topRight)
							    || verifiedNodes.Contains(botRight)
							    || verifiedNodes.Contains(botLeft))
							{
								verifiedNodes.Add((b, a));
								colorNotVerified.Remove((b, a));
							}
						}
					}
				}

				var result = hexagons.Select(p => p.Value.Count).Sum();
				Console.WriteLine(result == 0 ? "YES" : "NO");
			}
		}
	}
}
