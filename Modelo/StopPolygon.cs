using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
	public class StopPolygon
	{
		public string Id { get; set; }
		public int PlanVersionId { get; set; }
		public String ShortName { get; set; }
		public String LongName { get; set; }
		public double Lenght { get; set; }
		public double Latitude { get; set; }

		public StopPolygon(string stopid, int planVersionId, string shortName, string longName, double decLong, double decLat)
		{
			this.Id = stopid;
			this.PlanVersionId = planVersionId;
			this.ShortName = shortName;
			this.LongName = longName;
			this.Lenght = decLong;
			this.Latitude = decLat;
		}
	}
}
