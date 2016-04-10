using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Application
{
    public class QR_A
    {
        readonly StreamReader input;
        readonly StreamWriter output;

        readonly int counter;

        public QR_A (StreamReader input, StreamWriter output)
        {
            this.input = input;
            this.output = output;

            counter = int.Parse(input.ReadLine());
        }

        public QR_A ()
        {
        }

        public void Run()
        {
            for (int index = 1; index <= counter; index++) {
                var value = input.ReadLine ();
                int intValue = int.Parse (value);

                bool[] digits = { false, false, false, false, false,
                    false, false, false, false, false};

                int iteration = 1;
                int iterationValue;
                do
                {
                    if (iteration > 10000)
                        break;

                    iterationValue = intValue * iteration;
                    iteration++;
                    foreach (char digit in iterationValue.ToString())
                    {
                        digits[(int)char.GetNumericValue(digit)] = true;
                    }
                } while (digits.Count(d => d) < 10);


                var sb = new StringBuilder();
                if (iteration > 10000)
                {
                    sb.AppendFormat("Case #{0}: INSOMNIA", index);
                }
                else
                {
                    sb.AppendFormat("Case #{0}: {1}", index, iterationValue);
                }

                output.WriteLine(sb);
            }
        }
    }
}

