using System;
using System.Collections.Generic;

namespace D
{
	class Program
	{
		static readonly HashSet<char> Vowels = new HashSet<char> { 'e', 'u', 'i', 'o', 'a', 'y' };
		static readonly HashSet<char> Consonants = new HashSet<char> 
		{ 
			'b', 'c', 'd', 'f', 'g', 'j', 'k', 'l', 'm', 'n',
			'p', 'q', 's', 't', 'v', 'x', 'z', 'h', 'r', 'w'
		};

		static void Main(string[] args)
		{
			var tests = int.Parse(Console.ReadLine());
			for (var i = 0; i < tests; i++)
			{
				var password = Console.ReadLine();
				Console.WriteLine(GetCorrectPassword(password));
			}
		}

		static string GetCorrectPassword(string password)
		{
			var (consonants, digits, vowels, upperCases, lowerCases) = (0, 0, 0, 0, 0) ;

			foreach (var letter in password)
			{
				if (char.IsDigit(letter))
				{
					digits++;
				}
				else
				{
					if (Vowels.Contains(char.ToLower(letter)))
					{
						vowels++;
					}

					if (Consonants.Contains(char.ToLower(letter)))
					{
						consonants++;
					}

					if (char.IsUpper(letter))
					{
						upperCases++;
					}
					else
					{
						lowerCases++;
					}
				}
			}
			
			if (digits == 0)
			{
				password += "1";
			}

			if (upperCases == 0)
			{
				if (consonants == 0)
				{
					password += 'B';
					consonants++;
				}
				else
				{
					password += 'A';
					vowels++;
				}
			}

			if (lowerCases == 0)
			{
				if (consonants == 0)
				{
					password += 'b';
					consonants++;
				}
				else
				{
					password += 'a';
					vowels++;
				}
			}

			if (consonants == 0)
			{
				password += 'b';
			}

			if (vowels == 0)
			{
				password += 'a';
			}

			return password;
		}
	}
}
