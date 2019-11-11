using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
	public class Bus
	{

		public Bus(string date, string hour, int stopId, double latitude, double longitude, int taskId, int lineId, int tripId, long dataGramId,int busId)
		{
			this.date = date;
			this.hour = hour;
			this.stopId = stopId;
			this.latitude = latitude;
			this.longitude = longitude;
			this.taskId = taskId;
			this.lineId = lineId;
			this.tripId = tripId;
			this.dataGramId = dataGramId;
			this.busId = busId;
		}

		public string date { get; set; }
		public string hour { get; set; }
		public int stopId { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public int taskId { get; set; }
		public int lineId { get; set; }
		public int tripId { get; set; }
		public int busId { get; set; }
		public long dataGramId { get; set; }
	}
}
