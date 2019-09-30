using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
   public  class Bus
    {

        private int idBus;
        private int tripId;
        private List<Double> lenght;
        private List<Double> latitude;
   
        public Bus(int idBus, int tripId, List<Double> lenght, List<Double> latitude)
        {
            this.IdBus = idBus;
            this.TripId = tripId;
            this.Lenght = lenght;
            this.Latitude = latitude;

        }




        public void addLenght(double l)
        {
            lenght.Add(l);
        }

        public void addLatitude(double l)
        {
            lenght.Add(l);
        }


        public int IdBus { get => idBus; set => idBus = value; }
        public int TripId { get => tripId; set => tripId = value; }
        public List<Double> Lenght { get => lenght; set => lenght = value; }
        public List<Double> Latitude { get => latitude; set => latitude = value; }
    }
}
