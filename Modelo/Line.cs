using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Modelo
{   [Serializable]
    public class Line
    {
        private String lineId;
        private String ShortName;
        private Hashtable buses;

        public Line(string lineId, string shortName)
        {
            this.LineId = lineId;
            ShortName1 = shortName;
            this.Buses = new Hashtable();
        }

        public string LineId { get => lineId; set => lineId = value; }
        public string ShortName1 { get => ShortName; set => ShortName = value; }
        public Hashtable Buses { get => buses; set => buses = value; }

        public void addBus(Bus b) {
            buses.Add(b.IdBus,b);
        }
    }
}
