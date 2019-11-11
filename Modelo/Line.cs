using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace Modelo
{   [Serializable]
    public class Line
    {

		public Line(int lineId, string shortName, string description)
        {
            this.LineId = lineId;
            this.ShortName = shortName;
			this.description = description;
        }

        public int LineId { get; set; }
        public string ShortName { get; set; }
		public string description { get; set; }

    }
}
