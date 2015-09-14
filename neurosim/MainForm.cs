using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neurosim
{
	public partial class MainForm : Form
	{
		protected List<NeuronPlot> neuronPlots;
		protected Neuron scopedNeuron;
		protected Timer timer;

		public MainForm()
		{
			InitializeComponent();
			Shown += OnShown;
		}

		protected void OnShown(object sender, EventArgs e)
		{
			Initialize();
		}

		protected void Initialize()
		{
			neuronPlots = new List<NeuronPlot>();

			scopedNeuron = new Neuron();
			scopedNeuron.Leakage = 2 << 8;
			scopedNeuron.Integration = 0;

			neuronPlots.Add(new NeuronPlot() { Neuron = scopedNeuron, Location = new Point(pnlNetwork.Width / 2, pnlNetwork.Height / 2) });

			pnlNetwork.Plots = neuronPlots;

			timer = new Timer();
			timer.Interval = 10;
			timer.Tick += OnTick;
			timer.Start();
		}

		protected void OnTick(object sender, EventArgs e)
		{
			// scopedNeuron.TestPattern();
			scopedNeuron.Tick();
			pnlScope.NewValue(scopedNeuron.CurrentMembranePotential >> 8);
			pnlScope.Tick();
			pnlNetwork.Tick();
		}
	}
}
