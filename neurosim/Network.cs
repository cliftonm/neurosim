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
		public NetworkChart Chart { get; set; }

		protected List<NeuronPlot> plots;

		protected Bitmap bitmap;
		protected FastPixel fp;
		protected int mx = 0, my = 0;

		public Network()
		{
			plots = new List<NeuronPlot>();
			Chart = new CountDownChart();

			MouseDown += OnMouseDown;
			MouseLeave += OnMouseLeave;
			MouseMove += OnMouseMove;
			MouseUp += OnMouseUp;
		}

		void OnMouseUp(object sender, MouseEventArgs e)
		{
			Chart.DeselectObject();
			Refresh();
		}

		void OnMouseMove(object sender, MouseEventArgs e)
		{
			int dx = e.X - mx;
			int dy = e.Y - my;

			Chart.MoveObject(new Size(dx, dy));
			Refresh();
	
			mx = e.X;
			my = e.Y;
		}

		void OnMouseLeave(object sender, EventArgs e)
		{
			Chart.DeselectObject();
			Refresh();
		}

		void OnMouseDown(object sender, MouseEventArgs e)
		{
			mx = e.X;
			my = e.Y;
			Chart.SelectObject(new Point(e.X, e.Y), plots);
			Refresh();
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
			bool updateFromBitmap = Chart.Draw(fp, e.Graphics, plots);
			fp.Unlock(true);

			if (updateFromBitmap)
			{
				e.Graphics.DrawImage(bitmap, Point.Empty);
			}
		}
	}
}
