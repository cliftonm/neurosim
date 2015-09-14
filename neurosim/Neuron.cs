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
		/// Potential delta per tick in returning to the resting potential for non-action potential depolarization.
		/// Also applies to hyperpolarization resulting from inhibitory signals (not refractory period.)
		/// </summary>
		public int RestingPotentialReturnRate { get; set; }

		/// <summary>
		/// Potential delta per tick in returning to the resting potential while in refractory period.
		/// </summary>
		public int RefractoryRecoveryRate { get; set; }

		/// <summary>
		/// Positive depolarization leakage.  If non-zero, creates a "pacemaker" neuron.
		/// </summary>
		public int Leakage { get; set; }

		/// <summary>
		/// The membrane potential value that the neuron goes to on an action potential.
		/// </summary>
		public int ActionPotentialValue { get; set; }

		/// <summary>
		/// The overshoot of an action potential towards hyperpolarization.
		/// </summary>
		public int HyperPolarizationOvershoot { get; set; }

		/// <summary>
		/// The sum of excitatory and inhibitory signals.  This value is computed per tick and
		/// is added to the CurrentMembranePotential.
		/// </summary>
		public int Integration { get; set; }

		public State ActionState { get { return actionState; } }

		/// <summary>
		/// Returns true if the neuron has fired.
		/// </summary>
		public bool Fired { get; set; }

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
			RefractoryRecoveryRate = 1 << 8;
			HyperPolarizationOvershoot = 20 << 8;
			RestingPotentialReturnRate = 8;
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
					Fired = FireOnActionPotential();
					
					if (!Fired)
					{
						// Incrementally return to resting potential.
						int dir = Math.Sign(RestingPotential - CurrentMembranePotential);
						// Get the min delta so that we return exactly to the resting potential on the last step.
						int minDelta = Math.Min(RestingPotentialReturnRate, Math.Abs(RestingPotential - CurrentMembranePotential));	
						CurrentMembranePotential += minDelta * dir;
					}

					break;

				case State.Firing:
					Fired = false;
					++actionState;		// hold for one 1 tick
					break;

				case State.RefractoryStart:
					// refactory period start
					CurrentMembranePotential = RestingPotential - HyperPolarizationOvershoot;
					++actionState;
					break;

				case State.AbsoluteRefractory:
					// refactory period, linear ramp back to the resting potential.
					CurrentMembranePotential += RefractoryRecoveryRate;

					if (CurrentMembranePotential >= RestingPotential)
					{
						// Done with absolute refractory period.
						inputs.Clear();		// The neuron doesn't integrate any inputs during the absolute refractory period.
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
			Integration = 0;
			inputs.ForEach(v => Integration += v);
			CurrentMembranePotential += Integration;

			// We use the HP overshoot so that we don't exceed the floor of the membrane potential.
			CurrentMembranePotential = Math.Max(CurrentMembranePotential, RestingPotential - HyperPolarizationOvershoot);
			inputs.Clear();
		}

		protected bool FireOnActionPotential()
		{
			bool ret = false;

			if (CurrentMembranePotential >= ActionPotentialThreshold)
			{
				ret = true;
				ActionPotential();
				TriggerConnections();
			}

			return ret;
		}
	}
}
