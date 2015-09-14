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
	public partial class MainForm : Form
	{
		protected List<NeuronPlot> neuronPlots;
		protected Neuron pacemakerNeuron;
		protected Neuron receiverNeuron;
		protected Timer timer;
		protected String filename;
		protected bool paused;

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
			pnlScope.Initialized();

			pacemakerNeuron = new Neuron();
			pacemakerNeuron.Leakage = 2 << 8;
			pacemakerNeuron.Integration = 0;

			receiverNeuron = new Neuron();

			pacemakerNeuron.AddConnection(new Connection(receiverNeuron));

			neuronPlots.Add(new NeuronPlot() { Neuron = pacemakerNeuron, Location = new Point(pnlNetwork.Width / 2, pnlNetwork.Height / 2) });
			neuronPlots.Add(new NeuronPlot() { Neuron = receiverNeuron, Location = new Point(pnlNetwork.Width / 2 + 20, pnlNetwork.Height / 2) });

			pnlNetwork.SetPlots(neuronPlots);
			pnlScope.AddProbe(pacemakerNeuron, Color.LightBlue);
			pnlScope.AddProbe(receiverNeuron, Color.Red);

			timer = new Timer();
			timer.Interval = 10;
			timer.Tick += OnTick;
			timer.Start();
		}

		protected void OnTick(object sender, EventArgs e)
		{
			// scopedNeuron.TestPattern();
			foreach (NeuronPlot np in neuronPlots)
			{
				np.Neuron.Tick();
			}

			pnlScope.Tick();
			pnlNetwork.Tick();
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
			paused ^= true;

			if (paused)
			{
				btnPauseGo.Text = "Resume";
				Pause();
			}
			else
			{
				btnPauseGo.Text = "Pause";
				Resume();
			}
		}

		protected void Pause()
		{
			timer.Stop();
		}

		protected void Resume()
		{
			timer.Start();
		}
	}
}
