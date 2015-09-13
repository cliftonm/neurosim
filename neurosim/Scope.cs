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
		protected Pen axisPen { get; set; }
		protected Font vFont { get; set; }
		protected Brush vBrush { get; set; }
		protected Pen dataPen { get; set; }
		protected List<int> buffer { get; set; }
		protected int head;

		public Scope()
		{
			axisPen = new Pen(Color.Green);
			vFont = new Font("Consolas", 8);
			vBrush = new SolidBrush(Color.Green);
			dataPen = new Pen(Color.White);
			BackgroundBrush = new SolidBrush(Color.Black);
			buffer = new List<int>();
		}

		public void NewValue(int val)
		{
			if (buffer.Count < Width)
			{
				buffer.Add(val);
			}
			else
			{
				buffer[head] = val;
				Inc(ref head);
			}
		}

		public void Tick()
		{
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawHorizontalAxis(e.Graphics);
			DrawVerticalAxis(e.Graphics);
			DrawBuffer(e.Graphics);
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
				if (n != 0)
				{
					gr.DrawLine(axisPen, Width / 2 - 5, 100 - n + 20, Width / 2 + 5, 100 - n + 20);
					gr.DrawString(n.ToString(), vFont, vBrush, new PointF(Width / 2 + 7, 100 - n + 14));
				}
			}
		}

		protected void DrawBuffer(Graphics gr)
		{
			if (buffer.Count > 0)
			{
				int n = head;
				int v = 100 - buffer[n] + 20;
				Inc(ref n);

				for (int i = 1; i < buffer.Count; i++)
				{
					// gr.DrawRectangle(dataPen, Width - buffer.Count + i, 100 - buffer[n] + 20, 1, 1);
					int v2 = 100 - buffer[n] + 20;
					gr.DrawLine(dataPen, Width - buffer.Count + (i - 1), v, Width - buffer.Count + i, v2);
					v = v2;
					Inc(ref n);
				}
			}
		}

		protected void Inc(ref int n)
		{
			if (++n == Width)
			{
				n = 0;
			}
		}
	}
}
