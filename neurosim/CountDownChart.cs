using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class CountDownChart : NetworkChart
	{
		protected Color[] countDownColor = new Color[]
		{
			Color.FromArgb(0, 0, 0),		  // 0
			Color.FromArgb(64, 0, 0),    // 1
			Color.FromArgb(128, 0, 0),    // 2
			Color.FromArgb(192, 0, 0),    // 3
			Color.FromArgb(255, 64, 0),    // 4
			Color.FromArgb(255, 128, 0),    // 5
			Color.FromArgb(255, 192, 0),	  // 6
			Color.FromArgb(255, 255, 64),	  // 7
			Color.FromArgb(255, 255, 128),    // 8
			Color.FromArgb(255, 255, 192),    // 9
			Color.FromArgb(255, 255, 255),	  // 10
		};

		public override bool Draw(FastPixel fp, Graphics gr, List<NeuronPlot> plots)
		{
			fp.Clear(Color.Black);

			foreach (NeuronPlot np in plots)
			{
				ShowNeuronBasedOnFiredCountDown(fp, np);
			}

			return true;
		}

		protected void ShowNeuronBasedOnFiredCountDown(FastPixel fp, NeuronPlot np)
		{
			if (np.Neuron.ActionState == Neuron.State.Firing)
			{
				np.FiredCountDown = 11;
			}

			if (np.FiredCountDown > 0)
			{
				--np.FiredCountDown;
				Color color = countDownColor[np.FiredCountDown];
				Plot(fp, np.Location, color);
			}
		}
	}
}
