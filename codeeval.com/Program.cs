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
			string fileName = "r1a-a-sample.txt";

			StreamReader input = File.OpenText(inputPath + fileName);
			StreamWriter output = new StreamWriter(outputPath + fileName);

			var problem = new R1A_A(input, output);
			problem.Run();

			input.Close();
			output.Close();

		}

	}
}
