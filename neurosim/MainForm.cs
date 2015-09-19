using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
		protected DataTable dtStudy;
		protected DataView dvStudy;
		protected Dictionary<DataRow, Neuron> rowNeuronMap = new Dictionary<DataRow, Neuron>();

		protected Color[] probeColors = new Color[] 
		{
			Color.Cyan,
			Color.Blue,
			Color.Red,
			Color.Orange,
			Color.Yellow,
			Color.Purple,
			Color.LightGreen,
			Color.Maroon,
		};
		protected int probeColorIdx = 0;

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
			BindSliders();
			InitializeStudyView();
			pnlScope.Initialized();
			pnlScope.Tick();			// refreshes the display to deal with panel height.
		}

		protected void Initialize()
		{
			neuronPlots = new List<NeuronPlot>();
			btnStep.Enabled = false;

			rnd = new Random(2);						// always use the same seed so we can generate the same dataset.

			timer = new Timer();
			timer.Interval = REFRESH_RATE;
			timer.Tick += OnTick;
			Pause();

			tcTabs.SelectTab(1);
		}

		protected void InitializeStudyView()
		{
			dtStudy = new DataTable();
			dtStudy.Columns.Add("n");
			dtStudy.Columns.Add("RP");
			dtStudy.Columns.Add("APT");
			dtStudy.Columns.Add("APV");
			dtStudy.Columns.Add("RRR");
			dtStudy.Columns.Add("HPO");
			dtStudy.Columns.Add("RPRR");
			dtStudy.Columns.Add("PSAP");
			dtStudy.Columns.Add("LKG");
			dtStudy.Columns.Add("PCOLOR");
			dtStudy.Columns.Add("Conn");
			dvStudy = new DataView(dtStudy);
			dgvStudy.DataSource = dvStudy;
		}

		protected void CreateNetwork()
		{
			neuronPlots = new List<NeuronPlot>();

			int mx = pnlNetwork.Width / 4;
			int my = pnlNetwork.Height / 4;
			int c = 4;				// # of connections each neuron makes
			int d = 2;				// max distance of each connection.			Must be multiple of 2
			int r = 4;				// radius (as a square) of connections.		Must be multiple of 2
			int p = 10;

			// Initialize an mx x my array of neurons.  The edges wrap top-bottom / left-right.
			for (int x = 0; x < mx; x++)
			{
				for (int y = 0; y < my; y++)
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

					if (adjx < 0) adjx += mx;
					if (adjy < 0) adjy += my;

					int qx = adjx % mx;
					int qy = adjy % my;

					// Find the neuron at this location
					NeuronPlot npTarget = neuronPlots.Single(np2 => np2.Location.X == qx * 4 & np2.Location.Y == qy * 4);
					np.Neuron.AddConnection(new Connection(npTarget.Neuron));
				}
			}

			// Pick p neurons to be pacemakers at different rates.
			for (int i = 0; i < p; i++)
			{
				Neuron n = neuronPlots[rnd.Next(mx * my)].Neuron;
				// You get more interesting patterns when the leakage is randomized so that pacemaker neurons do not all
				// fire synchronously.
				n.Leakage = 256 + rnd.Next(256);			
				
				if (i == 0)
				{
					pnlScope.AddProbe(n, Color.LightBlue);
					// Pick the first connecting neuron for a second trace.
					pnlScope.AddProbe(n.Connections[0].Neuron, Color.Red);
				}
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
			else
			{
				SaveNetwork(filename);
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

		/*
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
		*/

		// TODO: Only saves study datatable right now.

		protected void LoadNetwork(string filename)
		{
			this.filename = filename;
			FileStream fs = File.Open(filename, FileMode.Open);
			dtStudy = dtStudy.Deserialize(fs);			// awkward.
			dvStudy = new DataView(dtStudy);
			dgvStudy.DataSource = dvStudy;
			UpdatePlotters(dtStudy);
			fs.Close();
		}

		protected void SaveNetwork(string filename)
		{
			this.filename = filename;
			FileStream fs = File.Create(filename);
			dtStudy.Serialize(fs);
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

		protected void BindSliders()
		{
			Bind(tbApThreshold, lblApThresholdValue, NeuronConfig.DefaultConfiguration, "ActionPotentialThreshold");
			Bind(tbApValue, lblApValueValue, NeuronConfig.DefaultConfiguration, "ActionPotentialValue");
			Bind(tbHpOvershoot, lblHpOvershootValue, NeuronConfig.DefaultConfiguration, "HyperPolarizationOvershoot");
			Bind(tbPsap, lblPsapValue, NeuronConfig.DefaultConfiguration, "PostSynapticActionPotential");
			Bind(tbRp, lblRpValue, NeuronConfig.DefaultConfiguration, "RestingPotential");
			Bind(tbRprr, lblRprrValue, NeuronConfig.DefaultConfiguration, "RestingPotentialReturnRate");
			Bind(tbRrr, lblRrrValue, NeuronConfig.DefaultConfiguration, "RefractoryRecoveryRate");
		}

		/// <summary>
		/// Convert potential as 24 bit + 8 bit fraction to a value between -1000 and 1000 representing -100mv to 100mv
		/// </summary>
		protected int ConvertPotential(int p)
		{
			return (p / 256) * 10 + ((Math.Abs(p) & 0xFF) * 10 / 256) * Math.Sign(p);
		}

		/// <summary>
		/// Convert a value from -1000 to 1000 to a 24 bit + 8 bit fractional component
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		protected int ConvertTrackBar(int v)
		{
			return ((v / 10) << 8) + ((256 * (Math.Abs(v) % 10)) / 10) * Math.Sign(v);
		}

		protected void Bind(TrackBar tb, Label lbl, NeuronConfig config, string field)
		{
			Type t = config.GetType();
			PropertyInfo pi = t.GetProperty(field, BindingFlags.Instance | BindingFlags.Public);
			int p = (int)pi.GetValue(config);
			int v = ConvertPotential(p);
			tb.Value = v;
			lbl.Text = (v / 10.0).ToString("###.0");
			tb.ValueChanged += (sender, args) =>
				{
					v = tb.Value;
					lbl.Text = (v / 10.0).ToString("###.0");
					p = ConvertTrackBar(v);
					pi.SetValue(config, p);					
				};
		}

		/// <summary>
		/// Add a study neuron using the default neuron config.
		/// </summary>
		private void btnAddNeuron_Click(object sender, EventArgs e)
		{
			Neuron n = new Neuron();
			AddNeuron(n, dtStudy, NeuronConfig.DefaultConfiguration);
			pnlScope.AddProbe(n, probeColors[probeColorIdx]);
			neuronPlots.Add(new NeuronPlot() { Neuron = n, Location = new Point(pnlNetwork.Width + 20 + probeColorIdx * 30, pnlNetwork.Height / 2) });
			probeColorIdx = (probeColorIdx + 1) % probeColors.Length;
			pnlNetwork.SetPlots(neuronPlots);
		}

		private void btnRemoveNeuron_Click(object sender, EventArgs e)
		{
			// remove entry from rowNeuronMap.			
			// remove entry from pnlScope probes
			// remove entry from neuronPlots
			// remove the row from the DataTable.
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			CreateNetwork();
		}

		protected void AddNeuron(Neuron n, DataTable dt, NeuronConfig cfg)
		{
			DataRow row = dt.NewRow();
			row["n"] = dt.Rows.Count + 1;
			row["RP"] = cfg.RestingPotential.ToDisplayValue();
			row["APT"] = cfg.ActionPotentialThreshold.ToDisplayValue();
			row["APV"] = cfg.ActionPotentialValue.ToDisplayValue();
			row["RRR"] = cfg.RefractoryRecoveryRate.ToDisplayValue();
			row["HPO"] = cfg.HyperPolarizationOvershoot.ToDisplayValue();
			row["RPRR"] = cfg.RestingPotentialReturnRate.ToDisplayValue();
			row["PSAP"] = cfg.PostSynapticActionPotential.ToDisplayValue();
			row["LKG"] = "0";
			row["PCOLOR"] = probeColors[probeColorIdx];
			dt.Rows.Add(row);
			rowNeuronMap[row] = n;
		}

		private void dgvStudy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Neuron n = rowNeuronMap[dvStudy[e.RowIndex].Row];
			DataRow row = dvStudy[e.RowIndex].Row;
			UpdateNeuronProperty(n, row, e.ColumnIndex);
		}

		protected void UpdateNeuronProperty(Neuron n, DataRow row, int colIdx)
		{
			string[] colProps = new string[] 
			{
				"RestingPotential",
				"ActionPotentialThreshold",
				"ActionPotentialValue",
				"RefractoryRecoveryRate",
				"HyperPolarizationOvershoot",
				"RestingPotentialReturnRate",
				"PostSynapticActionPotential",
			};

			string newVal = row[colIdx].ToString();

			switch (colIdx)
			{
				case 0:					// row index is not allowed to be changed
					break;

				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:					// The 7 neuron parameters
					UpdateProperty(n, colProps[colIdx - 1], newVal);
					break;

				case 8:					// Leakage
					n.Leakage = newVal.ToPotential();
					break;

				case 9:					// probe color
					break;

				case 10:				// connections
					break;
			}
		}

		private void UpdateProperty(Neuron n, string propName, string newVal)
		{
			Type t = n.Config.GetType();
			object obj = n.Config;
			PropertyInfo pi = t.GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
			pi.SetValue(obj, newVal.ToPotential());
		}

		protected void UpdatePlotters(DataTable dt)
		{
			rowNeuronMap.Clear();
			neuronPlots.Clear();
			probeColorIdx = 0;

			foreach (DataRow row in dt.Rows)
			{
				Neuron n = new Neuron();
				rowNeuronMap[row] = n;

				for (int colIdx = 1; colIdx <= 7; ++colIdx)
				{
					UpdateNeuronProperty(n, row, colIdx);
				}
				n.Leakage = row["LKG"].ToString().ToPotential();

				pnlScope.AddProbe(n, probeColors[probeColorIdx]);
				neuronPlots.Add(new NeuronPlot() { Neuron = n, Location = new Point(pnlNetwork.Width + 20 + probeColorIdx * 30, pnlNetwork.Height / 2) });
				probeColorIdx = (probeColorIdx + 1) % probeColors.Length;
			}

			pnlNetwork.SetPlots(neuronPlots);
		}
	}
}
