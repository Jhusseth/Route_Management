using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
	public class Stop
	{
		public String ShortName { get; set; }
		public String LongName { get; set; }
		public Double Lenght { get; set; }
		public Double Latitude { get; set; }

		public Stop(string shortName, string longName,double latitude, double longitude)
		{
			this.ShortName = shortName;
			this.Latitude = latitude;
			this.Lenght = longitude;
			this.LongName = longName;
		}
	}
}
