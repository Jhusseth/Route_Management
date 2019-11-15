using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
	public class OperationalData
	{

		public string BusId { get; set; }
		public int DesviationTime { get; set; }
		public string TripId { get; set; }
		public string LineId { get; set; }


		public OperationalData(string busId, string tripId,string lineId, int desviationTime)
		{
			this.BusId = busId;
			this.TripId = tripId;
			this.LineId = lineId;
			this.DesviationTime = desviationTime;
		}


	}
}
