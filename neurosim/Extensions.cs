using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

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
		public static string ToDisplayValue(this int p)
		{
			decimal d = ((p / 256) * 10 + ((Math.Abs(p) & 0xFF) * 10 / 256) * Math.Sign(p)) / 10M;

			return d.ToString("###0.0");
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

		public static void Serialize(this DataTable dt, Stream stream)
		{
			BinaryFormatter serializer = new BinaryFormatter();
			serializer.Serialize(stream, dt);
		}

		public static DataTable Deserialize(this DataTable dt, Stream stream)
		{
			BinaryFormatter serializer = new BinaryFormatter();
			return (DataTable)serializer.Deserialize(stream);
		} 
	}
}
