using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neurosim
{
	public class GraphicsPanel : Panel
	{
		public Brush BackgroundBrush { get; set; }
		public Rectangle RectRegion { get { return new Rectangle(0, 0, Width, Height); } }

		public GraphicsPanel()
		{
			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.FillRectangle(BackgroundBrush, RectRegion);
		}
	}
}
