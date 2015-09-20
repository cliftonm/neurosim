using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class NeuronChart : NetworkChart
	{
		protected Pen penBlack;
		protected Pen penGreen;
		protected NeuronPlot selectedNeuron = null;

		public NeuronChart()
		{
			penBlack = new Pen(Color.Black);
			penGreen = new Pen(Color.Green);
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
				Pen pen = np == selectedNeuron ? penGreen : penBlack;
				gr.DrawEllipse(pen, new Rectangle(np.Location.X - 5, np.Location.Y - 5, 10, 10));

				// If no connections, just draw a vertical "no connection" endpoint
				if (np.Neuron.Connections.Count == 0)
				{
					Point endpoint = np.Location - new Size(0, 45);
					DrawSynapse(pen, gr, np.Location, endpoint);
				}
				else
				{
					foreach (Connection conn in np.Neuron.Connections)
					{
						NeuronPlot npConn = plots.Single(p => p.Neuron == conn.Neuron);
						Point endpoint = npConn.Location;
						DrawSynapse(pen, gr, np.Location, endpoint);
					}
				}
			}

			return false;
		}

		public void DrawSynapse(Pen pen, Graphics gr, Point start, Point end)
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

			gr.DrawLine(pen, end, v1);
			gr.DrawLine(pen, end, v2);
			gr.DrawLine(pen, v1, v2);
		}
	}
}
