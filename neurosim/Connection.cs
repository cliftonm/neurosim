using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Connection
	{
		public enum Mode
		{
			Excitatory,
			Inhibitory,
		}

		public Neuron Neuron { get; set; }
		protected Mode mode;

		public Connection(Neuron targetNeuron, Mode mode = Mode.Excitatory)
		{
			Neuron = targetNeuron;
			this.mode = mode;
		}

		public void Fire()
		{
			switch (mode)
			{
				case Mode.Excitatory:
					Neuron.PostSynapticAction();
					break;

				case Mode.Inhibitory:
					break;
			}
		}
	}
}
