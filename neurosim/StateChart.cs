using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class StateChart : NetworkChart
	{
		public override bool Draw(FastPixel fp, Graphics gr, List<NeuronPlot> plots)
		{
			fp.Clear(Color.Black);

			foreach (NeuronPlot np in plots)
			{
				ShowNeuronBasedOnState(fp, np);
			}

			return true;
		}

		protected void ShowNeuronBasedOnState(FastPixel fp, NeuronPlot np)
		{
			Color color = Color.Black;

			switch (np.Neuron.ActionState)
			{
				case Neuron.State.Integrating:
					int offset = np.Neuron.Config.ActionPotentialThreshold - np.Neuron.CurrentMembranePotential;
					int range = np.Neuron.Config.ActionPotentialThreshold - np.Neuron.Config.RestingPotential;
					int percent = 255 - (offset * 255 / range);
					int cval = percent.Min(0).Max(255);
					color = Color.FromArgb(0, cval, 0);
					break;

				case Neuron.State.Firing:
					color = Color.White;
					break;

				case Neuron.State.RefractoryStart:
				case Neuron.State.AbsoluteRefractory:
					color = Color.FromArgb(255, 64, 64);
					break;

				case Neuron.State.RelativeRefractory:
					color = Color.Yellow;
					break;
			}

			Plot(fp, np.Location, color);
		}
	}
}
