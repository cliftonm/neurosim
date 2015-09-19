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

		public static int Max(this int v, int maxVal)
		{
			return v < maxVal ? v : maxVal;
		}

		/// <summary>
		/// Convert a neuron potential integer composed of upper 8 bits integer and lower 8 bits as fraction
		/// to a string with two decimal places.
		/// </summary>
		public static string ToDisplayValue(this int n)
		{
			decimal d = (n >> 8) + ((decimal)(n & 0xFF) / 256) / 100;

			return d.ToString("###0.00");
		}

		/// <summary>
		/// Convert a display value to a potential (upper 8 bits as the integer, lower 8 bits as the fractional component.)
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static int ToPotential(this string s)
		{
			decimal d = Convert.ToDecimal(s);
			int ret = ((int)d) << 8;
			ret = ret + (int)(256 * (d - (int)d));

			return ret;
		}
	}
}
