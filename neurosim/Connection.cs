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

		protected Neuron neuron;
		protected Mode mode;

		public Connection(Neuron targetNeuron, Mode mode = Mode.Excitatory)
		{
			neuron = targetNeuron;
			this.mode = mode;
		}

		public void Fire()
		{
			switch (mode)
			{
				case Mode.Excitatory:
					neuron.AddInput(20 << 8);		// TODO: User settable.
					break;

				case Mode.Inhibitory:
					break;
			}
		}
	}
}
