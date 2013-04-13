using System;
using System.IO;
using System.Text;

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
				char[][] matrix = new char[4][];

				ReadMatrix(matrix);

				string result = CheckMatrix(index, matrix);

				output.WriteLine(result);

				input.ReadLine();
			}
		}

		void ReadMatrix (char[][] matrix)
		{
			for (int line = 0; line < 4; line++) {
				string text = input.ReadLine();
				matrix[line] = new char[4];
				for (int column = 0; column < 4; column++) {
					matrix[line][column] = text[column];
				}
			}
		}

		string CheckMatrix (int index, char[][] matrix)
		{
			bool hasEmpty = false;
			bool XWon = false;
			bool OWon = false;

			char[] check = new char[4];

			for (int line = 0; line < 4; line++) {
				check = GetLine(line, matrix);
				hasEmpty |= IsEmpty(check);
				XWon |= HasWon("X", check);
				OWon |= HasWon("O", check);
			}

			for (int column = 0; column < 4; column++) {
				check = GetColumn(column, matrix);
				hasEmpty |= IsEmpty(check);
				XWon |= HasWon("X", check);
				OWon |= HasWon("O", check);
			}

			check = GetDiagonal(0, matrix);
			hasEmpty |= IsEmpty(check);
			XWon |= HasWon("X", check);
			OWon |= HasWon("O", check);

			check = GetDiagonal(3, matrix);
			hasEmpty |= IsEmpty(check);
			XWon |= HasWon("X", check);
			OWon |= HasWon("O", check);

			StringBuilder sb = new StringBuilder();
			sb.Append("Case #");
			sb.Append(index);
			sb.Append(": ");

			if (XWon)
			{
				sb.Append("X won");
				return sb.ToString();
			}

			if (OWon)
			{
				sb.Append("O won");
				return sb.ToString();
			}

			if (hasEmpty)
			{
				sb.Append("Game has not completed");
				return sb.ToString();
			}

			sb.Append("Draw");
			return sb.ToString();
		}

		char[] GetLine (int line, char[][] matrix)
		{
			return matrix[line];
		}

		char[] GetColumn (int column, char[][] matrix)
		{
			char[] result = new char[4];

			for (int line = 0; line < 4; line++) {
				result[line] = matrix[line][column];
			}

			return result;
		}

		char[] GetDiagonal (int type, char[][] matrix)
		{
			char[] result = new char[4];
			
			for (int i = 0; i < 4; i++) {
				result[i] = matrix[i][Math.Abs(type - i)];
			}
			
			return result;
		}

		bool IsEmpty (char[] check)
		{
			foreach (var item in check) {
				if (item == '.')
					return true;
			}

			return false;
		}

		bool HasWon (string type, char[] check)
		{
			bool won = true;

			foreach (var item in check) {
				var str = item.ToString ().ToUpper ();
				won &= str == "T" || str == type.ToUpper ();
			}

			return won;
		}
	}
}

