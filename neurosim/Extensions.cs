using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public static class Extensions
	{
		public static int Min(this int v, int minVal)
		{
			return v < minVal ? minVal : v;
		}
	}
}
