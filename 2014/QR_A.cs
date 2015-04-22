using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Application
{
	public class QR_A
	{
		StreamReader input;
		StreamWriter output;

		int counter = 0;

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
				int firstRowIndex = int.Parse (value);

				int[][] matrix = new int[4][];

				ReadMatrix(matrix);

				int[] firstRow = matrix[firstRowIndex - 1];

				int secondRowIndex = int.Parse (input.ReadLine ());

				matrix = new int[4][];

				ReadMatrix(matrix);

				int[] secondRow = matrix[secondRowIndex - 1];

				var intersect = firstRow.Intersect (secondRow);

				var list = new List<int> (intersect);

				string result = string.Empty;

				if (list.Count == 0)
					result = "Volunteer cheated!";

				if (list.Count > 1)
					result = "Bad magician!";

				if (list.Count == 1)
					result = list[0].ToString();

				StringBuilder sb = new StringBuilder ();
				sb.AppendFormat ("Case #{0}: {1}", index, result);

				output.WriteLine(sb.ToString());
			}
		}

		void ReadMatrix (int[][] matrix)
		{
			for (int line = 0; line < 4; line++) {
				string[] text = input.ReadLine ().Split (' ');
				matrix[line] = new int[4];
				for (int column = 0; column < 4; column++) {
					matrix[line][column] = int.Parse(text[column]);
				}
			}
		}
	}
}

