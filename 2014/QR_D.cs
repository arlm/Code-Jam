using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Application
{
	public class QR_D
	{
		StreamReader input;
		StreamWriter output;

		const string IMPOSSIBLE = "Impossible";

		int counter = 0;

		public QR_D (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;

			counter = int.Parse(input.ReadLine());
		}

		public QR_D ()
		{
		}

		public void Run()
		{
			for (int index = 1; index <= counter; index++) {
				int count = int.Parse(input.ReadLine ());
				int wins_deceive = 0;
				int wins_war = 0;

				var values = input.ReadLine ().Split(' ');

				List<double> naomi = new List<double>(GetWeights (values));
				naomi.Sort ();

				values = input.ReadLine ().Split(' ');
				List<double> ken = new List<double>(GetWeights (values));
				ken.Sort ();

				for (int i = 0; i < count; i++) {
					if (naomi [i] > ken [i]) {
						wins_war++;
					}
				}

				for (int i = count - 1; i < 0; i++) {
					if (naomi [i] > ken [i]) {
						wins_deceive++;
					}
				}

				string str = string.Format("Case #{0}: {1} {2}", index, wins_deceive, wins_war);
				output.WriteLine (str);
				Console.WriteLine (str);
			}
		}

		double[] GetWeights(string[] values) {
			var result = new double[values.Length];

			for (int i = 0; i < values.Length; i++) {
				result [i] = double.Parse (values[i]);
			}

			return result;
		}
	}
}

