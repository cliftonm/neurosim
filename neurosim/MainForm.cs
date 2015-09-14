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
		protected Neuron scopedNeuron;
		protected Timer timer;
		protected String filename;

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

			pnlNetwork.SetPlots(neuronPlots);

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

			pnlScope.NewValue(scopedNeuron.CurrentMembranePotential >> 8);
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
			scopedNeuron = neuronPlots[0].Neuron;
		}

		protected void SaveNetwork(string filename)
		{
			this.filename = filename;
			XmlSerializer xs = new XmlSerializer(neuronPlots.GetType());
	        FileStream fs = File.Create(filename);
			xs.Serialize(fs, neuronPlots);
			fs.Close();
		}
	}
}
