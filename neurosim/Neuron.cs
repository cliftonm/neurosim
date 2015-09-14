using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Neuron : ITimeComponent
	{
		public enum State
		{
			Integrating,
			Firing,
			RefractoryStart,
			AbsoluteRefractory,
			RelativeRefractory,
		}

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

		public State ActionState { get { return actionState; } }

		protected int testPatternDir = 1;
		protected State actionState;
		protected List<Connection> connections;
		protected List<int> inputs;

		public Neuron()
		{
			connections = new List<Connection>();
			inputs = new List<int>();
			actionState = State.Integrating;
			RestingPotential = -65 << 8;
			CurrentMembranePotential = -65 << 8;
			ActionPotentialThreshold = -35 << 8;
			ActionPotentialValue = 40 << 8;
		}

		public void AddConnection(Connection c)
		{
			connections.Add(c);
		}

		public void AddInput(int val)
		{
			inputs.Add(val);
		}

		public void Tick()
		{
			switch (actionState)
			{
				case State.Integrating:
					Integrate();
					FireOnActionPotential();
					break;

				case State.Firing:
					++actionState;		// hold for one 1 tick
					break;

				case State.RefractoryStart:
					// refactory period start
					CurrentMembranePotential = RestingPotential - (20 << 8) + Integration;
					++actionState;
					break;

				case State.AbsoluteRefractory:
					// refactory period, linear ramp back to the resting potential.
					CurrentMembranePotential += (1 << 8);

					if (CurrentMembranePotential >= RestingPotential)
					{
						// Done with refactory period.
						actionState = State.Integrating;
					}

					break;

				case State.RelativeRefractory:
					// Not implemented.
					break;
			}
		}

		public void TestPattern()
		{
			CurrentMembranePotential += testPatternDir << 8;

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
			actionState = State.Firing;
		}

		protected void TriggerConnections()
		{
			foreach (Connection c in connections)
			{
				c.Fire();
			}
		}

		protected void Integrate()
		{
			CurrentMembranePotential += Leakage;
			inputs.ForEach(v => CurrentMembranePotential += v);
			inputs.Clear();
		}

		protected void FireOnActionPotential()
		{
			if (CurrentMembranePotential >= ActionPotentialThreshold)
			{
				ActionPotential();
				TriggerConnections();
			}
		}
	}
}
