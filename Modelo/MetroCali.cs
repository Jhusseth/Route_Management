using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Modelo
{
    public class MetroCali
    {
        private Hashtable busStations;
        private Hashtable busStops;
        private Bus bus1;
        

        public Hashtable BusStations { get => busStations; set => busStations = value; }

        public Hashtable BusStops { get => busStops; set => busStops = value; }
        public Bus Bus1 { get => bus1; set => bus1 = value; }

        public MetroCali()
        {
            BusStations = new Hashtable();
            BusStops = new Hashtable();
            List<Double> x=latitudeBus();
            List<Double> y = lenghtBus();
            Bus1 = new Bus(1, 525, y, x);

        }

        public void serializeS(BusStation station)
        {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            BusStation b = station;
            if (BusStations[b.StationId] == null)
            {
                BusStations.Add(station.StationId, b);
            }
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, BusStations);
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

        public void deserializeS()
        {


            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                BusStations = (Hashtable)formatter.Deserialize(fs);
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

        public void serializeP(BusStops stops)
        {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            BusStops b = stops;
            if (BusStops[b.StopId] == null)
            {
                BusStops.Add(stops.StopId, b); 
            }
            FileStream fs = new FileStream("DataFileP.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, BusStops);
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

        public void deserializeP()
        {
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFileP.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                BusStops = (Hashtable)formatter.Deserialize(fs);
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

        public void serializeBus1(Bus bus) {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            Bus b = bus;
            
            FileStream fs = new FileStream("Bus1.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, BusStops);
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

        public List<Double> latitudeBus() {

            List<Double> latitude = new List<Double>();

            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            while((line= st.ReadLine()) != null) {
                String [] lines = st.ReadLine().Split(';');
                double latitud = Convert.ToDouble(lines[4]);
                latitud = latitud / 10000000;
                latitude.Add(latitud);
            }
            return latitude;
        }
        public List<Double> lenghtBus()
        {

            List<Double> lenght = new List<Double>();

            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            while ((line = st.ReadLine()) != null)
            {
                String[] lines = st.ReadLine().Split(';');
                double latitud = Convert.ToDouble(lines[5]);
                latitud = latitud / 10000000;
                lenght.Add(latitud);
            }
            return lenght;
        }
    }  


}
