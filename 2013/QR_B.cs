using System;
using System.IO;
using System.Text;

namespace Application
{
	public class QR_B
	{
		StreamReader input;
		StreamWriter output;
		
		int counter = 0;

		public QR_B (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;
			
			counter = int.Parse(input.ReadLine());
		}

		public QR_B ()
		{
		}

		public void Run()
		{
			for (int index = 1; index <= counter; index++) {
				string line = input.ReadLine();
				string[] limit = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
				
				int lines = int.Parse(limit[0]);
				int columns = int.Parse(limit[1]);

				int[,] matrix = new int[lines,columns];
				
				ReadMatrix(matrix);
				
				string result = CheckMatrix(index, matrix);
				Console.Out.WriteLine(result + "\n");
				output.WriteLine(result);
			}
		}

		void ReadMatrix (int[,] matrix)
		{
			for (int line = 0; line < matrix.GetLength (0); line++) {
				string matrixLine = input.ReadLine();
				string[] columns = matrixLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				for (int column = 0; column < columns.Length; column++) {
					matrix[line, column] = int.Parse(columns[column]);
				}
			}
		}

		string CheckMatrix (int index, int[,] matrix)
		{
			bool result = true;

			int lines = matrix.GetLength(0);
			int columns = matrix.GetLength (1);

			for (int i = 0; i < lines; i++) {
				result &= CheckLine (matrix, i);
			}

			for (int i = 0; i < columns; i++) {
				result &= CheckColumn (matrix, i);
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("Case #");
			sb.Append(index);
			sb.Append(": ");

			if (result)
				sb.Append("YES");
			else
				sb.Append("NO");

			return sb.ToString();
		}

		static bool CheckLine (int[,] matrix, int line)
		{
			bool result = true;

			int lines = matrix.GetLength(0);
			int columns = matrix.GetLength (1);

			int greaterLineEndpoint = matrix[line, 0] >= matrix[line, columns - 1] ? matrix[line, 0] : matrix[line, columns - 1];
			int lesserLineEndpoint = matrix[line, 0] <= matrix[line, columns - 1] ? matrix[line, 0] : matrix[line, columns - 1];
			bool equalLineEndpoints = greaterLineEndpoint == lesserLineEndpoint;

			int last = matrix[line, 0];

			int greaterLine = 0;
			for (int column = 0; column < columns; column++) {
				if (matrix[line, column] > greaterLine)
					greaterLine = matrix[line, column];
			}

			for (int column = 0; column < columns; column++) {
				int item = matrix[line, column];

				int greaterColumnEndpoint = matrix[0, column] >= matrix[lines - 1, column] ? matrix[0, column] : matrix[lines - 1, column];
				int lesserColumnEndpoint = matrix[0, column] <= matrix[lines - 1, column] ? matrix[0, column] : matrix[lines - 1, column];
				bool equalColumnEndpoints = greaterColumnEndpoint == lesserColumnEndpoint;

//				if (item > greaterLineEndpoint && item > greaterColumnEndpoint)
//				{
//					result &= false;
//					break;
//				}

//				int greaterColumn = 0;
//				for (int index = 0; index < lines; index++) {
//					if (matrix[index, column] > greaterColumn)
//						greaterColumn = matrix[index, column];
//				}
//
//				if (item < greaterLine && item < greaterColumn)
//				{
//					result &= false;
//					break;
//				}

				if (item != last)
				{
					if (item > last)
					{

					}
					else
					{
//						if (item > greaterColumnEndpoint)
//						{
//							result &= false;
//							break;
//						}
//
//						if (item < lesserColumnEndpoint)
//						{
//							result &= false;
//							break;
//						}
					}
				}
				else
				{
//					if (item > greaterColumnEndpoint && columns > 1)
//					{
//						result &= false;
//						break;
//					}
				}
			}

			DumpLine(matrix, line);
			if (result)
				Console.Out.WriteLine("YES");
			else
				Console.Out.WriteLine("NO");

			return result;
		}

		static bool CheckColumn (int[,] matrix, int column)
		{
			bool result = true;
			
			int lines = matrix.GetLength(0);
			int columns = matrix.GetLength (1);
			
			int greaterColumnEndpoint = matrix[0, column] >= matrix[lines - 1, column] ? matrix[0, column] : matrix[lines - 1, column];
			int lesserColumnEndpoint = matrix[0, column] <= matrix[lines - 1, column] ? matrix[0, column] : matrix[lines - 1, column];
			bool equalColumnEndpoints = greaterColumnEndpoint == lesserColumnEndpoint;
			
			int last = matrix[0, column];
			
			for (int line = 0; line < lines; line++) {
				int item = matrix[line, column];

				int greaterLineEndpoint = matrix[line, 0] >= matrix[line, columns - 1] ? matrix[line, 0] : matrix[line, columns - 1];
				int lesserLineEndpoint = matrix[line, 0] <= matrix[line, columns - 1] ? matrix[line, 0] : matrix[line, columns - 1];
				bool equalLineEndpoints = greaterLineEndpoint == lesserLineEndpoint;

//				if (item > greaterColumnEndpoint && item > greaterLineEndpoint)
//				{
//					result &= false;
//					break;
//				}

				int east = column == 0 ? -1 : matrix [line, column - 1];
				int west = column == columns - 1 ? -1 : matrix[line, column + 1];
				if (east == -1)
					east = west;
				if (west == -1)
					west = east;

				int north = line == 0 ? -1 : matrix [line - 1, column];
				int south = line == lines - 1 ? -1 : matrix [line + 1, column];
				if (north == -1)
					north = south;
				if (south == -1)
					south = north;

				if (item < east && item < west && item < north && item < south)
				{
					result &= false;
					break;
				}

				if ((item < east || item < west) && (item < north || item < south))
				{
					result &= false;
					break;
				}

				if (item != last)
				{
					if (item > last)
					{

					}
					else
					{
//						if (item > greaterLineEndpoint)
//						{
//							result &= false;
//							break;
//						}
//						
//						if (item < lesserLineEndpoint)
//						{
//							result &= false;
//							break;
//						}
					}
				}
				else
				{
//					if (item > greaterLineEndpoint && lines > 1)
//					{
//						result &= false;
//						break;
//					}
				}
			}

			if (result)
				Console.Out.WriteLine("Column {0}: YES", column);
			else
				Console.Out.WriteLine("Column {0}: NO", column);
			
			return result;
		}

		void DumpMatrix (int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++) {
				DumpLine (matrix, i);
				Console.Out.Write ("\n");
			}
			Console.Out.Write("\n");
		}

		static void DumpLine (int[,] matrix, int line)
		{
			for (int j = 0; j < matrix.GetLength (1); j++) {
				Console.Out.Write ("{0} ", matrix [line, j]);
			}
		}
	}
}

