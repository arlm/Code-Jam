using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;

class PrimePalindromeMain
{
	public static void Main (string[] args)
	{
		using (StreamWriter output = new StreamWriter(Console.OpenStandardOutput())) {

			var problem = new PrimePalindrome(output);
			problem.Run();
		}
	}
}

public class PrimePalindrome
{
	StreamWriter output;

	public PrimePalindrome(StreamWriter output)
	{
		this.output = output;
	}

	public void Run ()
	{
		var primes = BruteForcePrimes(1000).GetEnumerator ();
		int palindrome = 0;

		while (primes.MoveNext()) {
			int number = primes.Current;
			if (number == Reverse(number))
				palindrome = number;
		}

		output.WriteLine(palindrome);
	}

	int Reverse (int number)
	{
		char[] charArray = number.ToString().ToCharArray ();
		Array.Reverse (charArray);
		string reverse = new string(charArray);

		return int.Parse (reverse);
	}

	public IEnumerable<int> BruteForcePrimes(int max)
	{
		if (max < 2) yield break;
		yield return 2;

		List<int> found = new List<int>();

		found.Add (3);
		int candidate = 3;

		while (candidate <= max) {
			bool isPrime = true;
			foreach (int prime in found) {
				if (prime * prime > candidate) {
					break;
				}
				if (candidate % prime == 0) {
					isPrime = false;
					break;
				}
			}
			if (isPrime) {
				found.Add (candidate);
				yield return candidate;
			}
			candidate += 2;
		}
	}
}