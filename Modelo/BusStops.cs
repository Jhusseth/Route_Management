using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    [Serializable]
    public class BusStops
    {
        private String stopId;
        private String longName;
        private double Latitude;
        private double lenght;

        public BusStops(string stopId, string longName, double latitude, double lenght)
        {
            this.StopId = stopId;
            this.LongName = longName;
            this.Latitude1 = latitude;
            this.Lenght = lenght;
        }

        public string StopId { get => stopId; set => stopId = value; }
        public string LongName { get => longName; set => longName = value; }
        public double Latitude1 { get => Latitude; set => Latitude = value; }
        public double Lenght { get => lenght; set => lenght = value; }
    }
}
