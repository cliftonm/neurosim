using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Neuron : ITimeComponent
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
		/// The current membrane potential.
		/// </summary>
		public int CurrentMembranePotential { get; set; }

		/// <summary>
		/// Positive depolarization leakage.  If non-zero, creates a "pacemaker" neuron.
		/// </summary>
		public int Leakage { get; set; }

		/// <summary>
		/// The membrane potential value that the neuron goes to on an action potential.
		/// </summary>
		public int ActionPotentialValue { get; set; }

		/// <summary>
		/// The sum of excitatory and inhibitory signals.  This value is computed per tick and
		/// is used to determine the CurrentMembranePotential.
		/// </summary>
		public int Integration { get; set; }

		protected int testPatternDir = 1;
		protected int actionState;

		public Neuron()
		{
			actionState = -1;
			RestingPotential = -65 << 8;
			CurrentMembranePotential = -65 << 8;
			ActionPotentialThreshold = -35 << 8;
			ActionPotentialValue = 40 << 8;
		}

		public void Tick()
		{
			switch (actionState)
			{
				case -1:		// not in action potential
					CurrentMembranePotential += Leakage;

					if (CurrentMembranePotential >= ActionPotentialThreshold)
					{
						ActionPotential();
					}

					break;

				case 0:
					++actionState;		// hold for one 1 tick
					break;

				case 1:
					// refactory period start
					CurrentMembranePotential = RestingPotential - (20 << 8) + Integration;
					++actionState;
					break;

				case 2:
					// refactory period, linear ramp back to the resting potential.
					CurrentMembranePotential += (1 << 8);

					if (CurrentMembranePotential >= RestingPotential)
					{
						// Done with refactory period.
						actionState = -1;
					}

					break;
			}
		}

		public void TestPattern()
		{
			CurrentMembranePotential += testPatternDir;

			if (CurrentMembranePotential > (65 << 8))
			{
				testPatternDir = -1;
			}

			if (CurrentMembranePotential < (-65 << 8))
			{
				testPatternDir = 1;
			}
		}

		protected void ActionPotential()
		{
			CurrentMembranePotential = ActionPotentialValue;
			actionState = 0;
		}
	}
}
