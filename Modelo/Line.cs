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
        private int lineId;
        private String shortName;
        private Hashtable buses;

        public Line(int lineId, string shortName)
        {
            this.LineId = lineId;
            this.ShortName = shortName;
            this.Buses = new Hashtable();
        }

        public int LineId { get => lineId; set => lineId = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public Hashtable Buses { get => buses; set => buses = value; }

        public void addBus(Bus b) {
            buses.Add(b.IdBus,b);
        }

        public void serializeBuses(Bus bus)
        {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            Bus b = bus;

            FileStream fs = new FileStream("Buses.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, buses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public void deserializeBuses()
        {
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("Buses.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                Buses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }


        public void dataReadingBuses(String file)
        {
            StreamReader st = new StreamReader(file);
            String lin = "";
            st.ReadLine();
            while ((lin = st.ReadLine()) != null)
            {
                String[] line = lin.Split(';');
                int idBus = Convert.ToInt32(line[0]);
                int busNumber = Convert.ToInt32(line[1]);
                String identif = line[2];
                List<Double> lenght = new List<Double>();
                List<Double> latitude = new List<Double>();
                Bus b = new Bus(idBus, busNumber, identif, lenght, latitude);
                addBus(b);
               // serializeBuses(b);
            }  
        }

        public List<Double> latitudeBus(int lineId)
        {

            List<Double> latitude = new List<Double>();

            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            st.ReadLine();
            while ((line = st.ReadLine()) != null)
            {
                String[] lines = st.ReadLine().Split(';');
                if (lineId == Convert.ToInt32(lines[7]))
                {
                    double latitud = Convert.ToDouble(lines[4]);
                    latitud = latitud / 10000000;
                    latitude.Add(latitud);
                }
            }
            return latitude;
        }
        public List<Double> lenghtBus(int lineId)
        {

            List<Double> lenght = new List<Double>();

            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            st.ReadLine();
            while ((line = st.ReadLine()) != null)
            {
                String[] lines = st.ReadLine().Split(';');
                if (lineId == Convert.ToInt32(lines[7]))
                {
                    double latitud = Convert.ToDouble(lines[5]);
                    latitud = latitud / 10000000;
                    lenght.Add(latitud);
                }

            }
            return lenght;
        }
    }
}
