using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Connection
	{
		public enum CMode
		{
			Excitatory,
			Inhibitory,
		}

		public Neuron Neuron { get; set; }
		public CMode Mode { get { return postSynapticActionPotential < 0 ? CMode.Inhibitory : CMode.Excitatory; } }

		protected int postSynapticActionPotential;

		public Connection(Neuron targetNeuron, int psap = 20<<8)
		{
			Neuron = targetNeuron;
			postSynapticActionPotential = psap;
		}

		public void Fire()
		{
			Neuron.PostSynapticAction(postSynapticActionPotential);
		}
	}
}
