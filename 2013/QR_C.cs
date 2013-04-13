using System;
using System.IO;
using System.Numerics;

namespace Application
{
	public class QR_C
	{
		StreamReader input;
		StreamWriter output;
		
		int counter = 0;
		
		public QR_C (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;
			
			counter = int.Parse(input.ReadLine());
		}
		
		public QR_C ()
		{
		}
		
		public void Run()
		{
			for (int index = 1; index <= counter; index++) {
				string line = input.ReadLine();
				string[] limit = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				BigInteger start = BigInteger.Parse(limit[0]);
				BigInteger end = BigInteger.Parse(limit[1]);

				long count = 0;

				for (BigInteger i = start; i <= end; i++) {
					bool fairAndSquare = isFairSquare(i);
					//Console.Out.WriteLine("{0} {1}: {2} {3} ", i, Sqrt(i), IsFair(i), fairAndSquare);

					if (fairAndSquare)
						count++;
				}

				string result = string.Format("Case #{0}: {1}", index, count);
				
				output.WriteLine(result);
			}
		}

		bool IsFair(BigInteger num)
		{
			return num == Reverse(num);
		}

		bool isFairSquare(BigInteger num)
		{
			if (IsFair(num))
			{
				BigInteger square = Sqrt(num);

				bool result = false;

				if (square != BigInteger.MinusOne)
				{
					try
					{
						result = IsFair(square);
					}
					catch (Exception) {}
				}

				return result;
			}
			else
			{
				return false;
			}
		}

		BigInteger Sqrt(BigInteger n)
		{
			if (n == 0) return 0;
			if (n > 0)
			{
				int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
				BigInteger root = BigInteger.One << (bitLength / 2);
				
				while (!isSqrt(n, root))
				{
					root += n / root;
					root /= 2;
				}

				if (BigInteger.Pow(root, 2) == n)
					return root;
				else
					return BigInteger.MinusOne;
			}
			
			throw new ArithmeticException("NaN");
		}

		bool isSqrt(BigInteger n, BigInteger root)
		{
			BigInteger lowerBound = root*root;
			BigInteger upperBound = (root + 1)*(root + 1);
			
			return (n >= lowerBound && n < upperBound);
		}

		BigInteger Reverse (BigInteger number)
		{
			char[] charArray = number.ToString().ToCharArray();
			Array.Reverse( charArray );
			string reverse = new string( charArray );

			return BigInteger.Parse(reverse);
		}
	}
}

