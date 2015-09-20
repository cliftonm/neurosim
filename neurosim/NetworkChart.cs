using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public abstract class NetworkChart
	{
		public abstract bool Draw(FastPixel fp, Graphics gr, List<NeuronPlot> plots);
		public virtual void DeselectObject() { }
		public virtual void SelectObject(Point pos, List<NeuronPlot> plots) { }
		public virtual void MoveObject(Size dist) { }

		public void Plot(FastPixel fp, Point location, Color color)
		{
			fp.SetPixel(location, color);
			fp.SetPixel(location + new Size(1, 0), color);
			fp.SetPixel(location + new Size(0, 1), color);
			fp.SetPixel(location + new Size(1, 1), color);
		}
	}
}
