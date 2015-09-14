using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class NeuronPlot
	{
		public Neuron Neuron { get; set; }
		public Point Location { get; set; }
		public int FiredCountDown { get; set; }
	}
}
