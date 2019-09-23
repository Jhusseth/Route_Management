using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    class Zone
    {
        private String name;
        private int id;
        private MetroCali metroCali;
       

        public Zone(String name, int id)
        {
            this.Name = name;
            this.Id = id;
            metroCali = new MetroCali();

        }

        public String Name { get => name; set => name = value; }
        public int Id { get => Id; set=> id= value;}

        public Hashtable getBusSations()
        {
            return metroCali.BusStations;
        }
        public Hashtable getBusStops()
        {
            return metroCali.BusStops;
        }

        public void setBusStations(Hashtable bs)
        {
            metroCali.BusStations = bs;
        }

        public void setBusStops(Hashtable bs)
        {
            metroCali.BusStops = bs;
        }


    }
}
