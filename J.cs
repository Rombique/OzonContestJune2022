using System;
using System.Collections.Generic;
using System.Linq;

namespace J
{
	class Program
	{
		static void Main(string[] args)
		{
			var dictCount = int.Parse(Console.ReadLine());
			var dict1 = new Dictionary<string, HashSet<int>>();
			var dict2 = new Dictionary<int, HashSet<string>>();
			for (var i = 0; i < dictCount; i++)
			{
				var word = Console.ReadLine();
				if (dict2.TryGetValue(i, out _))
				{
					dict2[i].Add(word);
				}
				else
				{
					dict2.Add(i, new HashSet<string> { word });
				}
				
				var reversedArr = word!.Reverse().ToArray();


				if (reversedArr.Length == 10)
				{
					dict1.TryAdd(new string(reversedArr), new HashSet<int> { i });
				}

				for (var a = 9; a > 0; a--)
				{
					TryAddToDict(dict1, word, reversedArr, a, i);
				}
			}
			
			var requestsCount = int.Parse(Console.ReadLine());
			for (var i = 0; i < requestsCount; i++)
			{
				var word = Console.ReadLine();
				var reversedArr = word.Reverse().ToArray();
				string res = "";
				while (string.IsNullOrWhiteSpace(res))
				{
					var fullLetter = new string(reversedArr);
					if (dict1.TryGetValue(fullLetter, out var set))
					{
						foreach (var item in set)
						{
							var dictWords = dict2[item];
							var anotherWord = dictWords.FirstOrDefault(p => p != word);
							if (!string.IsNullOrWhiteSpace(anotherWord))
							{
								res = anotherWord;
								break;
							}
						}

						if (!string.IsNullOrWhiteSpace(res))
						{
							break;
						}
					}

					for (int c = 1; c < reversedArr.Length; c++)
					{
						res = GetWord(c, dict1, dict2, word, reversedArr);
						if (!string.IsNullOrWhiteSpace(res))
						{
							break;
						}
					}

					if (string.IsNullOrWhiteSpace(res))
					{
						res = new string(dict1.First(p => p.Key != word).Key.Reverse().ToArray());
					}
				}
				Console.WriteLine(res);
			}
		}

		static string GetWord(int minusLetters, Dictionary<string, HashSet<int>> dict1,
			Dictionary<int, HashSet<string>> dict2, string word, char[] reversedArr)
		{
			var res = "";
			var minus2Letter = new string(reversedArr.Take(reversedArr.Length - minusLetters).ToArray());
			if (!string.IsNullOrWhiteSpace(minus2Letter) && dict1.TryGetValue(minus2Letter, out var set2))
			{
				foreach (var item in set2)
				{
					var dictWords = dict2[item];
					var anotherWord = dictWords.FirstOrDefault(p => p != word);
					if (!string.IsNullOrWhiteSpace(anotherWord))
					{
						return anotherWord;
					}
				}
			}

			return null;
		}
		
		static void TryAddToDict(Dictionary<string, HashSet<int>> dict, string word, char[] reversedArr, int length, int i)
		{
			if (reversedArr.Length >= length)
			{
				var str = new string(reversedArr.Take(length).ToArray());
				if (!string.IsNullOrWhiteSpace(str))
				{
					if (dict.TryGetValue(str, out _))
					{
						dict[str].Add(i);
					}
					else
					{
						dict.Add(str, new HashSet<int> { i });
					}
				}
			}
		}
	}
}
