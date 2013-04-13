using System;
using System.IO;

namespace Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string inputPath = "../../input/";
			string outputPath = "../../output/";
			string fileName = "A-large.in";

			StreamReader input = File.OpenText(inputPath + fileName);
			StreamWriter output = new StreamWriter(outputPath + fileName);

			var problem = new QR_A(input, output);
			problem.Run();

			input.Close();
			output.Close();

		}
	}
}
