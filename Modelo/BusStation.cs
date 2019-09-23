using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    [Serializable]
    public class BusStation
    {
        private String stationId;
        private String longName;
        private double Latitude;
        private double lenght;

        public BusStation(string stationId, string longName, double latitude, double lenght)
        {
            this.StationId = stationId;
            this.LongName = longName;
            Latitude1 = latitude;
            this.Lenght = lenght;
        }

        public string StationId { get => stationId; set => stationId = value; }
        public string LongName { get => longName; set => longName = value; }
        public double Latitude1 { get => Latitude; set => Latitude = value; }
        public double Lenght { get => lenght; set => lenght = value; }
    }
}
