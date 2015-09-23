using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neurosim
{
	public class NetworkConfig
	{
		public int NumConnections { get; set; }
		public int MaxDistance { get; set; }
		public int Radius { get; set; }
		public int Pacemakers { get; set; }

		public static NetworkConfig DefaultConfiguration = new NetworkConfig();

		public NetworkConfig()
		{
			NumConnections = 4;
			MaxDistance = 2;
			Radius = 4;
			Pacemakers = 10;
		}
	}
}
