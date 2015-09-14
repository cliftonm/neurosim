using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace neurosim
{
	public partial class MainForm : Form, ITimeComponent
	{
		public const int REFRESH_RATE = 60;

		protected List<NeuronPlot> neuronPlots;
		protected Neuron pacemakerNeuron;
		protected Neuron receiverNeuron;
		protected Timer timer;
		protected String filename;
		protected bool paused;
		protected bool stepping;
		protected Random rnd;

		public MainForm()
		{
			InitializeComponent();
			Shown += OnShown;
		}

		public void Tick()
		{
			bool networkFired = false;
			// scopedNeuron.TestPattern();
			foreach (NeuronPlot np in neuronPlots)
			{
				np.Neuron.Tick();
				networkFired |= np.Neuron.Fired;
			}

			pnlScope.Tick();
			pnlNetwork.Tick();

			if (stepping && networkFired)
			{
				Pause();
			}
		}

		protected void OnShown(object sender, EventArgs e)
		{
			Initialize();
		}

		protected void Initialize()
		{
			btnStep.Enabled = false;

			rnd = new Random(2);						// always use the same seed so we can generate the same dataset.
			neuronPlots = new List<NeuronPlot>();
			pnlScope.Initialized();

			int m = 60;				// grid size
			int c = 4;				// # of connections each neuron makes
			int d = 2;				// max distance of each connection.			Must be multiple of 2
			int r = 4;				// radius (as a square) of connections.		Must be multiple of 2
			int p = 10;

			// Does some interesting stuff, but not yet what I'm looking for.
			//int m = 60;				// grid size
			//int c = 6;				// # of connections each neuron makes
			//int d = 10;				// max distance of each connection.			Must be multiple of 2
			//int r = 6;				// radius (as a square) of connections.		Must be multiple of 2

			// A really interesting pattern:
			//int m = 60;				// grid size
			//int c = 7;				// # of connections each neuron makes			// Change c to 6 and it takes a long time to achieve runaway state.
			//int d = 10;				// max distance of each connection.
			//int r = 7;				// radius (as a square) of connections.


			// Initialize an m x m array of neurons.  The edges wrap top-bottom / left-right.
			for (int x = 0; x < m; x++)
			{
				for (int y = 0; y < m; y++)
				{
					Neuron n = new Neuron();
					neuronPlots.Add(new NeuronPlot() { Neuron = n, Location = new Point(x * 4, y * 4) });
				}
			}

			// Each neuron connects to c other neurons in a localized r x r region at a maximum distance of d from the originating neuron.
			foreach (NeuronPlot np in neuronPlots)
			{
				int x = np.Location.X / 4;
				int y = np.Location.Y / 4;

				// Note: rnd.Next(min,max) is inclusive of the lower bound and exclusive of the upper bound.
				// To avoid introducing bias, we add 1 to the upper bound.

				// Target location:
				int targetx = x + rnd.Next(-d / 2, (d / 2) + 1);
				int targety = y + rnd.Next(-d / 2, (d / 2) + 1);

				for (int i = 0; i < c; i++)
				{
					// Connection location around the target.
					int adjx = targetx + rnd.Next(-r / 2, (r / 2) + 1);
					int adjy = targety + rnd.Next(-r / 2, (r / 2) + 1);

					if (adjx < 0) adjx += m;
					if (adjy < 0) adjy += m;

					int qx = adjx % m;
					int qy = adjy % m;

					// Find the neuron at this location
					NeuronPlot npTarget = neuronPlots.Single(np2 => np2.Location.X == qx * 4 & np2.Location.Y == qy * 4);
					np.Neuron.AddConnection(new Connection(npTarget.Neuron));
				}
			}

			// Pick p neurons to be pacemakers at different rates.
			for (int i = 0; i < p; i++)
			{
				neuronPlots[rnd.Next(m * m)].Neuron.Leakage = 256 + rnd.Next(256);
			}

			pnlNetwork.SetPlots(neuronPlots);

			/*
			pacemakerNeuron = new Neuron();
			pacemakerNeuron.Leakage = 2 << 8;
			pacemakerNeuron.Integration = 0;

			receiverNeuron = new Neuron();

			pacemakerNeuron.AddConnection(new Connection(receiverNeuron));

			neuronPlots.Add(new NeuronPlot() { Neuron = pacemakerNeuron, Location = new Point(pnlNetwork.Width / 2, pnlNetwork.Height / 2) });
			neuronPlots.Add(new NeuronPlot() { Neuron = receiverNeuron, Location = new Point(pnlNetwork.Width / 2 + 20, pnlNetwork.Height / 2) });

			pnlScope.AddProbe(pacemakerNeuron, Color.LightBlue);
			pnlScope.AddProbe(receiverNeuron, Color.Red);
			*/

			timer = new Timer();
			timer.Interval = REFRESH_RATE;
			timer.Tick += OnTick;
			Pause();
		}

		protected void OnTick(object sender, EventArgs e)
		{
			timer.Stop();
			Tick();

			if (!paused)
			{
				timer.Start();
			}
		}

		private void mnuNew_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void mnuOpen_Click(object sender, EventArgs e)
		{
			Clear();
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				LoadNetwork(ofd.FileName);
			}
		}

		private void mnuSave_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(filename))
			{
				mnuSaveAs_Click(sender, e);
			}
		}

		private void mnuSaveAs_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				SaveNetwork(sfd.FileName);
			}
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		protected void Clear()
		{
			neuronPlots.Clear();
			pnlNetwork.SetPlots(neuronPlots);
			filename = String.Empty;
		}

		protected void LoadNetwork(string filename)
		{
			this.filename = filename;
			XmlSerializer xs = new XmlSerializer(neuronPlots.GetType());
			FileStream fs = File.Open(filename, FileMode.Open);
			neuronPlots = (List<NeuronPlot>)xs.Deserialize(fs);
			pnlNetwork.SetPlots(neuronPlots);
			fs.Close();

			// TODO: Save scoped neuron indices.
			pacemakerNeuron = neuronPlots[0].Neuron;
		}

		protected void SaveNetwork(string filename)
		{
			this.filename = filename;
			XmlSerializer xs = new XmlSerializer(neuronPlots.GetType());
	        FileStream fs = File.Create(filename);
			xs.Serialize(fs, neuronPlots);
			fs.Close();
		}

		private void btnPauseGo_Click(object sender, EventArgs e)
		{
			if (paused) Resume(); else Pause();
		}

		protected void Pause()
		{
			paused = true;
			stepping = false;
			btnPauseGo.Text = "Resume";
			btnStep.Enabled = true;
			timer.Stop();
		}

		protected void Resume()
		{
			paused = false;
			btnPauseGo.Text = "Pause";
			btnStep.Enabled = false;
			timer.Start();
		}

		private void btnStep_Click(object sender, EventArgs e)
		{
			stepping = true;
			Resume();
		}
	}
}
