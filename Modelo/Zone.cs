using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
	public class Zone
	{
		public double LatitudeMax { get; set; }
		public double LatitudeMin { get; set; }
		public double LongitudeMax { get; set; }
		public double LongitudeMin { get; set; }

		public Zone(double latitudeM, double latitudem, double longitudeM, double longitudem)
		{
			this.LatitudeMax = latitudeM;
			this.LatitudeMin = latitudem;
			this.LongitudeMax = longitudeM;
			this.LongitudeMin = longitudem;
		}
	}
}
