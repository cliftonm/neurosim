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
				fp.SetPixel(np.Location, Color.FromArgb(0, (np.Neuron.CurrentMembranePotential >> 8) + 100, 0));
			}

			fp.Unlock(true);
			e.Graphics.DrawImage(bitmap, Point.Empty);
		}
	}
}
