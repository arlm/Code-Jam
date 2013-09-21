using System;
using System.IO;
using System.Text;

namespace Application
{
	public class R1A_A
	{
		StreamReader input;
		StreamWriter output;
		
		int counter = 0;
		
		public R1A_A (StreamReader input, StreamWriter output)
		{
			this.input = input;
			this.output = output;
			
			counter = int.Parse(input.ReadLine());
		}
		
		public R1A_A ()
		{
		}
		
		public void Run()
		{
			for (int index = 1; index <= counter; index++) {
				double r, t;
				long circles = 0; 

				string text = input.ReadLine();
				string[] elements = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				r = double.Parse(elements[0]);
				t = double.Parse(elements[1]);

				double inner = r;

				while( t >= 0 )
				{
					t -= 2 * inner + 1;
					inner += 2;
					if (t >=0 )
						circles++;
				}

				StringBuilder sb = new StringBuilder();
				sb.Append("Case #");
				sb.Append(index);
				sb.Append(": ");
				sb.Append(circles);

				output.WriteLine(sb.ToString());
			}
		}
	}
}

