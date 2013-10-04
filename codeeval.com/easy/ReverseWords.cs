using System;
using System.IO;
using System.Text;

public class ReverseWordsMain {
    public static void Main(string[] args) {
        string inputPath = "../../input/";
        string outputPath = "../../output/";
        string fileName = "easy-4-reverse-words.txt";

        using (StreamReader input = File.OpenText(inputPath + fileName)) {
            //using (StreamReader input = File.OpenText(args[0])) {

            using (StreamWriter output = new StreamWriter(outputPath + fileName)) {
                // using (StreamWriter output = new StreamWriter (Console.OpenStandardOutput())) {

                var problem = new ReverseWords(input, output);
                problem.Run();
            }
        }
    }
}

public class ReverseWords {
    StreamReader input;
    StreamWriter output;

    public ReverseWords(StreamReader input, StreamWriter output) {
        this.input = input;
        this.output = output;
    }

    public void Run() {
        while (!input.EndOfStream) {
            string line = input.ReadLine();
            StringBuilder sb = new StringBuilder();
            string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int index = elements.Length - 1; index >= 0; index--) {
                sb.Append(elements[index]);
                sb.Append(" ");
            }

            output.WriteLine(sb.ToString());
        }
    }
}

