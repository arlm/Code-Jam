using System;
using System.IO;
using System.Text;

class Program
{
	public static void Main (string[] args)
	{
		string inputPath = "../../input/";
		string outputPath = "../../output/";
		string fileName = "easy-1-fizz-buzz.txt";

		using (StreamReader input = File.OpenText(inputPath + fileName)) {
			//using (StreamReader input = File.OpenText(args[0])) {

			using (StreamWriter output = new StreamWriter (outputPath + fileName)) {
				// using (StreamWriter output = new StreamWriter (Console.OpenStandardOutput())) {

				var problem = new FizzBuzz (input, output);
				problem.Run ();
			}
		}
	}
}

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

	public void Run()
	{
		while (!input.EndOfStream) {
			string line = input.ReadLine ();
			StringBuilder sb = new StringBuilder();
			string[] elements = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			A = int.Parse(elements[0]);
			B = int.Parse(elements[1]);
			counter = int.Parse(elements[2]);

			for (int number = 1; number <= counter; number++) {
				bool f = number % A == 0;
				bool b = number % B == 0;

				if (f) {
					sb.Append ("F");
				}
				if (b) {
					sb.Append ("B");
				}
				if (!f && !b) {
					sb.Append (number);
				}
				if (number < counter) {
					sb.Append (" ");
				}
			}

			output.WriteLine(sb.ToString());
		}
	}
}