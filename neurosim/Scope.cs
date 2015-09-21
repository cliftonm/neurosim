using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neurosim
{
	public class Scope : GraphicsPanel, ITimeComponent
	{
		protected Pen axisPen;
		protected Font vFont;
		protected Brush vBrush;
		protected int vOffset;
		protected List<Probe> probes;

		public Scope()
		{
			axisPen = new Pen(Color.Green);
			vFont = new Font("Consolas", 8);
			vBrush = new SolidBrush(Color.Green);
			probes = new List<Probe>();
		}

		public void Initialized()
		{
			vOffset = (Height - 200) / 2;
		}

		public void ClearProbes()
		{
			probes.Clear();
		}

		public void AddProbe(Neuron n, Color color)
		{
			probes.Add(new Probe(n, Width, color, vOffset));
		}

		public void Tick()
		{
			probes.ForEach(p => p.Tick());
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawHorizontalAxis(e.Graphics);
			DrawVerticalAxis(e.Graphics);

			probes.ForEach(p => p.DrawBuffer(e.Graphics));
		}

		protected void DrawHorizontalAxis(Graphics gr)
		{
			gr.DrawLine(axisPen, 0, Height / 2, Width, Height / 2);

			for (int n = 0; n < Width; n += 10)
			{
				gr.DrawLine(axisPen, n, Height / 2 - 5, n, Height / 2 + 5);
			}
		}

		protected void DrawVerticalAxis(Graphics gr)
		{
			gr.DrawLine(axisPen, Width / 2, 0, Width / 2, Height);

			for (int n = -100; n <= 100; n += 20)
			{
				int heightLine = 100 - n + vOffset;
				int heightText = 100 - n + vOffset - 6;

				if (n != 0)
				{
					gr.DrawLine(axisPen, Width / 2 - 5, heightLine, Width / 2 + 5, heightLine);
					gr.DrawString(n.ToString(), vFont, vBrush, new Point(Width / 2 + 7, heightText));
				}
			}
		}
	}
}
