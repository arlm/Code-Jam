using System;
using System.IO;

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
		}
	}
}

