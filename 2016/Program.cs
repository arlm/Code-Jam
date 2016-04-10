using System.Globalization;
using System.IO;
using System.Threading;

namespace Application
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            const string inputPath = "../../input/";
            const string outputPath = "../../output/";
            const string fileName = "qr-a-sample.txt";

            var input = File.OpenText(inputPath + fileName);
            var output = new StreamWriter(outputPath + fileName);

            var problem = new QR_A(input, output);
            problem.Run();

            input.Close();
            output.Close();
        }
    }
}
