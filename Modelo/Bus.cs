using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    [Serializable]
   public  class Bus
    {

        private int idBus;
        private int busNumber;
        private String identif;
        private List<Double> lenght;
        private List<Double> latitude;
        

   
        public Bus(int idBus,int busNumer, String identif, List<Double> lenght, List<Double> latitude)
        {
            this.IdBus = idBus;
            this.Identif = identif;
            this.Lenght = lenght;
            this.Latitude = latitude;
            this.BusNumber = busNumber;

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

        public int BusNumber { get => busNumber; set => busNumber = value; }

        public String Identif { get => identif; set => identif = value; }
        public List<Double> Lenght { get => lenght; set => lenght = value; }
        public List<Double> Latitude { get => latitude; set => latitude = value; }
    }
}
