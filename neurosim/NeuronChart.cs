using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clifton.Extensions;

namespace neurosim
{
	public class NeuronChart : NetworkChart
	{
		protected Brush brushBlack;
		protected Pen penBlack;
		protected Pen penGreen;
		protected NeuronPlot selectedNeuron = null;

		protected Color[] countDownColor = new Color[]
		{
			Color.FromArgb(255, 250, 250),		  // 0
			Color.FromArgb(255, 225, 225),    // 1
			Color.FromArgb(255, 200, 200),    // 2
			Color.FromArgb(255, 175, 175),    // 3
			Color.FromArgb(255, 150, 150),    // 4
			Color.FromArgb(255, 125, 125),    // 5
			Color.FromArgb(255, 100, 100),	  // 6
			Color.FromArgb(255, 75, 75),	  // 7
			Color.FromArgb(255, 50, 50),    // 8
			Color.FromArgb(255, 25, 25),    // 9
			Color.FromArgb(255, 0, 0),	  // 10
		};

		protected Brush[] brushCountDown;

		public NeuronChart()
		{
			brushBlack = new SolidBrush(Color.Black);
			penBlack = new Pen(Color.Black);
			penGreen = new Pen(Color.Green);

			brushCountDown = new Brush[countDownColor.Length];
			countDownColor.ForEachWithIndex((c, idx) => brushCountDown[idx] = new SolidBrush(c));
		}

		public override void DeselectObject()
		{
			selectedNeuron = null;
		}

		public override void SelectObject(Point pos, List<NeuronPlot> plots)
		{
			foreach (NeuronPlot np in plots)
			{
				if ((np.Location.X - 5 < pos.X) &&
					 (np.Location.X + 5 > pos.X) &&
					 (np.Location.Y - 5 < pos.Y) &&
					 (np.Location.Y + 5 > pos.Y))
				{
					selectedNeuron = np;
					break;
				}
			}
		}

		public override void MoveObject(Size dist)
		{
			if (selectedNeuron != null)
			{
				selectedNeuron.Location += dist;
			}
		}

		public override bool Draw(FastPixel fp, Graphics gr, List<NeuronPlot> plots)
		{
			gr.Clear(Color.White);

			foreach (NeuronPlot np in plots)
			{
				int colorIdx = TestNeuronFiring(np);
				Pen pen = np == selectedNeuron ? penGreen : penBlack;

				// Draw the neuron circle as a border if not firing, otherwise as a solid circle on a fire event and post-fire countdown.
				if (colorIdx == -1)
				{
					gr.DrawEllipse(pen, new Rectangle(np.Location.X - 5, np.Location.Y - 5, 10, 10));
				}
				else
				{
					gr.FillEllipse(brushCountDown[colorIdx], new Rectangle(np.Location.X - 5, np.Location.Y - 5, 10, 10));
				}

				// If no connections, just draw a vertical "no connection" endpoint
				if (np.Neuron.Connections.Count == 0)
				{
					Point endpoint = np.Location - new Size(0, 45);
					DrawSynapse(pen, gr, np.Location, endpoint, Connection.CMode.Excitatory);
				}
				else
				{
					foreach (Connection conn in np.Neuron.Connections)
					{
						NeuronPlot npConn = plots.Single(p => p.Neuron == conn.Neuron);
						Point endpoint = npConn.Location;
						DrawSynapse(pen, gr, np.Location, endpoint, conn.Mode);
					}
				}
			}

			return false;
		}

		protected int TestNeuronFiring(NeuronPlot np)
		{
			int idx = -1;

			if (np.Neuron.ActionState == Neuron.State.Firing)
			{
				np.FiredCountDown = 11;

			}

			if (np.FiredCountDown > 0)
			{
				--np.FiredCountDown;
				idx = np.FiredCountDown;
			}

			return idx;
		}

		protected void DrawSynapse(Pen pen, Graphics gr, Point start, Point end, Connection.CMode mode)
		{
			double t = Math.Atan2(end.Y - start.Y, end.X - start.X);
			double endt = Math.Atan2(start.Y - end.Y, start.X - end.X);

			// start at the circumference of the circle.
			Size offset = new Size((int)(5 * Math.Cos(t)), (int)(5 * Math.Sin(t)));

			// end at the circumference of the target neuron circle.
			Point endOffset = new Point((int)(15 * Math.Cos(endt)), (int)(15 * Math.Sin(endt)));
			end.Offset(endOffset);
			gr.DrawLine(pen, start + offset, end);

			// the synapse is a triangle whose base is opposite and perpendicular to the endpoint.
			double v1angle = t - 0.785398163;
			double v2angle = t + 0.785398163;

			Point v1 = new Point((int)(10 * Math.Cos(v1angle)), (int)((10 * Math.Sin(v1angle))));
			v1.Offset(end);

			Point v2 = new Point((int)(10 * Math.Cos(v2angle)), (int)((10 * Math.Sin(v2angle))));
			v2.Offset(end);

			switch (mode)
			{
				case Connection.CMode.Excitatory:
					// A white triangle.
					gr.DrawLine(pen, end, v1);
					gr.DrawLine(pen, end, v2);
					gr.DrawLine(pen, v1, v2);
					break;

				case Connection.CMode.Inhibitory:
					// A black triangle.
					gr.FillPolygon(brushBlack, new Point[] { end, v1, v2 }, System.Drawing.Drawing2D.FillMode.Winding);
					break;
			}
		}
	}
}
