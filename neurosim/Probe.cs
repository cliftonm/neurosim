using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class Probe : ITimeComponent
	{
		protected Neuron neuron;
		protected List<int> buffer;
		protected int head;
		protected int width;
		protected Pen dataPen;
		protected int vOffset;

		public Probe(Neuron neuron, int width, Color color, int vOffset)
		{
			buffer = new List<int>();
			this.width = width;
			this.neuron = neuron;
			this.vOffset = vOffset;
			dataPen = new Pen(color);
		}

		public void Tick()
		{
			NewValue(neuron.CurrentMembranePotential / 256);
		}

		public void NewValue(int val)
		{
			if (buffer.Count < width)
			{
				buffer.Add(val);
			}
			else
			{
				buffer[head] = val;
				Inc(ref head);
			}
		}

		public void DrawBuffer(Graphics gr)
		{
			if (buffer.Count > 0)
			{
				int n = head;
				int v = 100 - buffer[n] + vOffset;
				Inc(ref n);

				for (int i = 1; i < buffer.Count; i++)
				{
					// gr.DrawRectangle(dataPen, Width - buffer.Count + i, 100 - buffer[n] + 20, 1, 1);
					int v2 = 100 - buffer[n] + vOffset;
					gr.DrawLine(dataPen, width - buffer.Count + (i - 1), v, width - buffer.Count + i, v2);
					v = v2;
					Inc(ref n);
				}
			}
		}

		protected void Inc(ref int n)
		{
			if (++n == width)
			{
				n = 0;
			}
		}
	}
}
