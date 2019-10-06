using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    [Serializable]
   public  class Bus
    {

        private int idBus;
        private string plate;
        private List<Double> lenght;
        private List<Double> latitude;
        

   
        public Bus(int idBus, string plate, List<Double> lenght, List<Double> latitude)
        {
            this.IdBus = idBus;
            this.plate = plate;
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

        public string plate1 { get => plate; set => plate = value; }
        public List<Double> Lenght { get => lenght; set => lenght = value; }
        public List<Double> Latitude { get => latitude; set => latitude = value; }
    }
}
