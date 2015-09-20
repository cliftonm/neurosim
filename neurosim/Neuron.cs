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
		/// The current membrane potential.
		/// </summary>
		public int CurrentMembranePotential { get; set; }

		/// <summary>
		/// Positive depolarization leakage.  If non-zero, creates a "pacemaker" neuron.
		/// </summary>
		public int Leakage { get; set; }

		/// <summary>
		/// The sum of excitatory and inhibitory signals.  This value is computed per tick and
		/// is added to the CurrentMembranePotential.
		/// </summary>
		public int Integration { get; set; }

		public State ActionState { get { return actionState; } }

		public List<Connection> Connections { get { return connections; } }

		/// <summary>
		/// Returns true if the neuron has fired.
		/// </summary>
		public bool Fired { get; set; }

		public NeuronConfig Config
		{
			get { return config; }
			set { config = value; }
		}

		protected int testPatternDir = 1;
		protected State actionState;
		protected List<Connection> connections;
		protected List<int> inputs;
		protected NeuronConfig config;

		/// <summary>
		/// Use default configuration for the neuron.
		/// </summary>
		public Neuron()
		{
			config = NeuronConfig.DefaultConfiguration;
			Initialize();
		}

		/// <summary>
		/// Instantiate the neuron with a custom configuration.
		/// </summary>
		public Neuron(NeuronConfig config)
		{
			this.config = config;
			Initialize();
		}

		protected void Initialize()
		{
			connections = new List<Connection>();
			inputs = new List<int>();
			actionState = State.Integrating;
			CurrentMembranePotential = config.RestingPotential;
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
						int dir = Math.Sign(config.RestingPotential - CurrentMembranePotential);
						// Get the min delta so that we return exactly to the resting potential on the last step.

						if (dir == -1)		// current membrane potential > resting potential, so return at some rate to the resting potential.
						{
							CurrentMembranePotential += config.RestingPotentialReturnRate;
						}
						// int minDelta = Math.Min(config.RestingPotentialReturnRate, Math.Abs(config.RestingPotential - CurrentMembranePotential));	
						// CurrentMembranePotential += minDelta * dir;
					}

					break;

				case State.Firing:
					Fired = false;
					++actionState;		// hold for one 1 tick
					break;

				case State.RefractoryStart:
					// refactory period start
					CurrentMembranePotential = config.RestingPotential - config.HyperPolarizationOvershoot;
					++actionState;
					break;

				case State.AbsoluteRefractory:
					// refactory period, linear ramp back to the resting potential.
					CurrentMembranePotential += config.RefractoryRecoveryRate;

					if (CurrentMembranePotential >= config.RestingPotential)
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

		public void PostSynapticAction(int psap)
		{
			AddInput(psap);
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
			CurrentMembranePotential = config.ActionPotentialValue;
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
			CurrentMembranePotential = Math.Max(CurrentMembranePotential, config.RestingPotential - config.HyperPolarizationOvershoot);

			// CMP limited to not exceed APT -- we're doing this mainly for display purposes.
			CurrentMembranePotential = Math.Min(CurrentMembranePotential, config.ActionPotentialThreshold);
			inputs.Clear();
		}

		protected bool FireOnActionPotential()
		{
			bool ret = false;

			if (CurrentMembranePotential >= config.ActionPotentialThreshold)
			{
				ret = true;
				ActionPotential();
				TriggerConnections();
			}

			return ret;
		}
	}
}
