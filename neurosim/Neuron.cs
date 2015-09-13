using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Neuron : ITimeComponent
	{
		public int RestingPotential { get; set; }
		public int ActionPotentialThreshold { get; set; }
		public int CurrentMembranePotential { get; set; }
		public int Leakage { get; set; }
		public int ActionPotentialValue { get; set; }

		protected int testPatternDir = 1;
		protected int actionState;

		public Neuron()
		{
			actionState = -1;
			RestingPotential = -65;
			CurrentMembranePotential = -65;
			ActionPotentialThreshold = -35;
			ActionPotentialValue = 40;
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
					CurrentMembranePotential = RestingPotential - 20;
					++actionState;
					break;

				case 2:
					CurrentMembranePotential += 1;

					if (CurrentMembranePotential == RestingPotential)
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

			if (CurrentMembranePotential > 65)
			{
				testPatternDir = -1;
			}

			if (CurrentMembranePotential < -65)
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
