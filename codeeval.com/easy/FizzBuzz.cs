using System;
using System.IO;
using System.Text;

namespace codeeval.com
{
	public class FizzBuzz
	{
		StreamReader input;
		StreamWriter output;

		int counter = 0;
		int A = 1;
		int B = 1;

		public FizzBuzz (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;
		}

		private bool Fizz(int number) {
			return number % A == 0;
		}

		private bool Buzz(int number) {
			return number % B == 0;
		}

		public void Run()
		{
			string line = input.ReadLine ();
			while (!string.IsNullOrEmpty(line)) {
				StringBuilder sb = new StringBuilder();
				string[] elements = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				A = int.Parse(elements[0]);
				B = int.Parse(elements[1]);
				counter = int.Parse(elements[2]);

				for (int i = 1; i <= counter; i++) {
					bool f = Fizz (i);
					bool b = Buzz(i);

					if (f) {
						sb.Append ("F");
					}
					if (b) {
						sb.Append ("B");
					}
					if (!f && !b) {
						sb.Append (i);
					}
					if (i < counter) {
						sb.Append (" ");
					}
				}

				output.WriteLine(sb.ToString());
				line = input.ReadLine ();
			}
		}
	}
}

