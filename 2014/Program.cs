using System;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			string inputPath = "../../input/";
			string outputPath = "../../output/";
			string fileName = "qr-d-sample.txt";

			StreamReader input = File.OpenText(inputPath + fileName);
			StreamWriter output = new StreamWriter(outputPath + fileName);

			var problem = new QR_D(input, output);
			problem.Run();

			input.Close();
			output.Close();
		}
	}
}
