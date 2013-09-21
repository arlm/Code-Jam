using System;
using System.Collections.Generic;
using System.IO;

class SumOfPrimesMain
{
	public static void Main (string[] args)
	{
		using (StreamWriter output = new StreamWriter (Console.OpenStandardOutput())) {

			var problem = new SumOfPrimes (output);
			problem.Run ();
		}
	}
}

public class SumOfPrimes
{
	StreamWriter output;

	public SumOfPrimes (StreamWriter output)
	{
		this.output = output;
	}

	public void Run()
	{
		var primes = FristNPrimes (1000).GetEnumerator();
		int sum = 0;

		while (primes.MoveNext()) {
			sum += primes.Current;
		}

		output.WriteLine(sum);
	}

	public IEnumerable<int> FristNPrimes( int max )
	{
		int count = 1;
		yield return 2;

		List<int> found = new List<int>();
		found.Add( 3 );
		int candidate = 3;

		while ( count < max )
		{
			bool isPrime = true;
			foreach ( int prime in found )
			{
				if ( prime * prime > candidate )
				{
					break;
				}
				if ( candidate % prime == 0 )
				{
					isPrime = false;
					break;
				}
			}
			if (isPrime)
			{
				found.Add( candidate );
				count++;
				yield return candidate;
			}
			candidate += 2;
		}
	}
}

