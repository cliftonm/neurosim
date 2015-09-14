using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neurosim
{
	public class Network : GraphicsPanel, ITimeComponent
	{
		protected List<NeuronPlot> plots;

		protected Bitmap bitmap;
		protected FastPixel fp;

		public Network()
		{
			plots = new List<NeuronPlot>();
		}

		public void SetPlots(List<NeuronPlot> plots)
		{
			this.plots = plots;
		}

		public void Tick()
		{
			Refresh();
		}

		// TODO: This needs to be implemented as a memory mapped bitmap.
		protected override void OnPaint(PaintEventArgs e)
		{
			if (bitmap == null)
			{
				bitmap = new Bitmap(Width, Height, e.Graphics);
				fp = new FastPixel(bitmap);
			}

			fp.Lock();
			fp.Clear(Color.Black);

			foreach (NeuronPlot np in plots)
			{
				Color color = Color.Black;

				switch (np.Neuron.ActionState)
				{
					case Neuron.State.Integrating:
						int offset = np.Neuron.ActionPotentialThreshold - np.Neuron.CurrentMembranePotential;
						int range = np.Neuron.ActionPotentialThreshold - np.Neuron.RestingPotential;
						int percent = 255 - (offset * 255 / range);
						int cval = percent.Min(0).Max(255);
						color = Color.FromArgb(0, cval, 0);
						break;

					case Neuron.State.Firing:
						color = Color.White;
						break;

					case Neuron.State.RefractoryStart:
					case Neuron.State.AbsoluteRefractory:
						color = Color.FromArgb(255, 64, 64);
						break;

					case Neuron.State.RelativeRefractory:
						color = Color.Yellow;
						break;
				}

				fp.SetPixel(np.Location, color);
				fp.SetPixel(np.Location + new Size(1, 0), color);
				fp.SetPixel(np.Location + new Size(0, 1), color);
				fp.SetPixel(np.Location + new Size(1, 1), color);
			}

			fp.Unlock(true);
			e.Graphics.DrawImage(bitmap, Point.Empty);
		}
	}
}
