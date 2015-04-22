using System;
using System.IO;
using System.Text;

namespace Application
{
	public class QR_C
	{
		StreamReader input;
		StreamWriter output;

		const string IMPOSSIBLE = "Impossible";

		int counter = 0;

		public QR_C (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;

			counter = int.Parse(input.ReadLine());
		}

		public QR_C ()
		{
		}

		public void Run()
		{
			for (int index = 1; index <= counter; index++) {
				var values = input.ReadLine ().Split(' ');

				int rows = int.Parse(values [0]);
				int columns = int.Parse(values [1]);
				int mines = int.Parse(values [2]);

				string result = GetResult (rows, columns, mines);

				var str = string.Format ("Case #{0}:\n{1:F7}", index, result);
				output.WriteLine (str);
				Console.WriteLine (str);
			}
		}

		string GetResult (int rows, int columns, int mines)
		{
			if (mines == 0)
				return ""; //PrintBoard (rows, columns, mines);

			if (rows == 1 && columns == 1) {
				if (mines == 0)
					return "c";
				else
					return IMPOSSIBLE;
			}

			if (rows * columns == mines) {
				return IMPOSSIBLE;
			}

			if (rows * columns  - 1 == mines) {
				return ""; //PrintBoard (rows, columns, mines);
			}

			if (rows == 1 || columns == 1) {
				if (rows * columns - 2 < mines) {
					return IMPOSSIBLE;
				} else {
					return  ""; //PrintBoard (rows, columns, mines);
				}
			} else {
				if (rows * columns - 4 < mines) {
					return IMPOSSIBLE;
				} else {
					return PrintBoard (rows, columns, mines);
				}
			}
		}

		static string PrintBoard (int rows, int columns, int mines)
		{
			var sb = new StringBuilder ();
			int lastCells = 4;
			for (int row = 0; row < rows; row++) {
				for (int column = 0; column < columns; column++) {
					if (mines > 0) {
						int cells = (rows - row) * columns - column;
						bool lastRows = row >= rows - 2;
						bool lastColumns = column >= columns - 2;
						if (lastRows && lastColumns && cells - lastCells >= mines) {
							sb.Append (".");
							lastCells--;
						} else {
							sb.Append ("*");
							mines--;
						}
					}
					else {
						sb.Append (".");
					}
				}
				sb.Append ("\n");
			}

			sb.Remove (sb.Length - 2, 2);
			sb.Append ("c");

			if (mines > 0)
				sb.AppendLine (">>>>>>ERROR<<<<<<");

			return sb.ToString();
		}
	}
}

