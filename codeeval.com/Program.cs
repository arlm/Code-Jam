using System;
using System.IO;

namespace codeeval.com
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string inputPath = "../../input/";
			string outputPath = "../../output/";
			string fileName = "easy-1-fizz-buzz.txt";

			StreamReader input = File.OpenText(inputPath + fileName);
			StreamWriter output = new StreamWriter(outputPath + fileName);

			var problem = new FizzBuzz(input, output);
			problem.Run();

			input.Close();
			output.Close();
		}

	}
}
