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
			for (int index = 1; index <= counter; index++) {
				var values = input.ReadLine ().Split(' ');

				double farmCost = double.Parse(values [0]);
				double cookiesPerFarm = double.Parse(values [1]);
				double winState = double.Parse(values [2]);

				double timeSpent = 0;
				double turnReward = 2;


				double turnValue = -1;

				while (turnValue < 0) {
					turnValue = DoTurn (farmCost, cookiesPerFarm, winState, turnReward);
					if (turnValue == -1) {
						timeSpent += farmCost / turnReward;
						turnReward += cookiesPerFarm;
					} else {
						timeSpent += turnValue;
					}
				}

				var str = string.Format ("Case #{0}: {1:F7}", index, timeSpent);
				output.WriteLine (str);
				Console.WriteLine (str);
			}
		}

		double DoTurn (double farmCost, double cookiesPerFarm, double winState, double turnReward)
		{
			double timeToWin = winState / turnReward;
			double waitForFarm = farmCost / turnReward;
			double nextWinState = winState / (turnReward + cookiesPerFarm);
			if (timeToWin <= waitForFarm + nextWinState)
				return timeToWin;
			else
				return -1;
		}
	}
}

