using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    [Serializable]
   public  class Bus
    {

        private int idBus;
<<<<<<< HEAD
        private string plate;
=======
        private int busNumber;
        private String identif;
>>>>>>> categorization
        private List<Double> lenght;
        private List<Double> latitude;
        

   
<<<<<<< HEAD
        public Bus(int idBus, string plate, List<Double> lenght, List<Double> latitude)
        {
            this.IdBus = idBus;
            this.plate = plate;
            this.Lenght = lenght;
            this.Latitude = latitude;           

=======
        public Bus(int idBus,int busNumer, String identif, List<Double> lenght, List<Double> latitude)
        {
            this.IdBus = idBus;
            this.Identif = identif;
            this.Lenght = lenght;
            this.Latitude = latitude;
            this.BusNumber = busNumber;
>>>>>>> categorization
        }

        public void addLenght(double l)
        {
            lenght.Add(l);
        }

        public void addLatitude(double l)
        {
            lenght.Add(l);
        }
<<<<<<< HEAD
        public int IdBus { get => idBus; set => idBus = value; }       

        public string plate1 { get => plate; set => plate = value; }
        public List<Double> Lenght { get => lenght; set => lenght = value; }
        public List<Double> Latitude { get => latitude; set => latitude = value; }
=======
        public int IdBus { get => idBus; set => idBus = value; }

        public int BusNumber { get => busNumber; set => busNumber = value; }

        public String Identif { get => identif; set => identif = value; }
        public List<Double> Lenght { get => lenght; set => lenght = value; }
        public List<Double> Latitude { get => latitude; set => latitude = value; }




>>>>>>> categorization
    }
}
