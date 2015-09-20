using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class NeuronConfig
	{
		/// <summary>
		/// The quiescent resting potential state of the neuron.
		/// </summary>
		public int RestingPotential { get; set; }

		/// <summary>
		/// The membrane potential threshold that must be achieved for an action potential to occur.
		/// </summary>
		public int ActionPotentialThreshold { get; set; }

		/// <summary>
		/// Potential delta per tick in returning to the resting potential for non-action potential depolarization.
		/// Also applies to hyperpolarization resulting from inhibitory signals (not refractory period.)
		/// This value should be negative (to increase potential) as it applies for when the current membrane potential
		/// is > the resting potential.
		/// </summary>
		public int RestingPotentialReturnRate { get; set; }

		/// <summary>
		/// Potential delta per tick in returning to the resting potential while in refractory period.
		/// </summary>
		public int RefractoryRecoveryRate { get; set; }

		/// <summary>
		/// The membrane potential value that the neuron goes to on an action potential.
		/// </summary>
		public int ActionPotentialValue { get; set; }

		/// <summary>
		/// The overshoot of an action potential towards hyperpolarization.
		/// </summary>
		public int HyperPolarizationOvershoot { get; set; }

		/// <summary>
		/// The input to the neuron when it receives an action potential.
		/// </summary>
		// public int PostSynapticActionPotential { get; set; }

		public static NeuronConfig DefaultConfiguration = new NeuronConfig();

		public NeuronConfig()
		{
			RestingPotential = -65 << 8;
			ActionPotentialThreshold = -35 << 8;
			ActionPotentialValue = 40 << 8;
			RefractoryRecoveryRate = 1 << 8;
			HyperPolarizationOvershoot = 20 << 8;
			RestingPotentialReturnRate = -8;
			// PostSynapticActionPotential = 20 << 8;
		}
	}
}
