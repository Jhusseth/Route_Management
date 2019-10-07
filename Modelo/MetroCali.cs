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
        private List<Line> lines;

        public Hashtable BusStations { get => busStations; set => busStations = value; }

        public Hashtable BusStops { get => busStops; set => busStops = value; }
        
        public List<Line> Lines { get => lines; set => lines = value; }

        public MetroCali()
        {
            BusStations = new Hashtable();
            BusStops = new Hashtable();
            Lines = new List<Line>();
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

        public void serializeL(Line lines)
        {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            
            for(int i = 0; i < Lines.Count; i++)
            {
                if(Lines[i].LineId != lines.LineId)
                {
                    addLines(lines);
                }
            }
            
            FileStream fs = new FileStream("DataFileL.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, Lines);
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

        public void deserializeL()
        {
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFileL.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                Lines = (List<Line>)formatter.Deserialize(fs);
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


        public void dataReadingLines(String file)
        {
            StreamReader st = new StreamReader(file);
            String lin = "";
            st.ReadLine();            
            while ((lin = st.ReadLine()) != null)
            {
                String[] line = lin.Split(';');
                int idLine = Convert.ToInt32(line[0]);
                string shortName = line[2];
                Line l = new Line(idLine,shortName);
                l.dataReadingBuses("buses.csv");
                addLines(l);
                //serializeL(l);
            }
        }

        public void dataSerealize()
        {
            dataReadingLines("lines.csv");
        }

        public List<Double> lenghtLine(int lineId)
        {

            List<Double> lenght = new List<Double>();

            StreamReader st = new StreamReader("datagrams.csv");
            String lin = "";
            st.ReadLine();
            while ((lin = st.ReadLine()) != null)
            {
                String[] lines = lin.Split(';');
                if (lineId == Convert.ToInt32(lines[7]))
                {
                    double lent = Convert.ToDouble(lines[5]);
                    lent = lent / 10000000;
                    lenght.Add(lent);
                }

            }
            return lenght;
        }

        public List<Double> latitudeLine(int lineId)
        {

            List<Double> latitude = new List<Double>();

            StreamReader st = new StreamReader("datagrams.csv");
            String lin = "";
            st.ReadLine();
            while ((lin = st.ReadLine()) != null)
            {
                String[] lines = lin.Split(';');
                if (lineId == Convert.ToInt32(lines[7]))
                {
                    double latitud = Convert.ToDouble(lines[4]);
                    latitud = latitud / 10000000;
                    latitude.Add(latitud);
                }
            }
            return latitude;
        }



        public void addLines(Line line) {
            Lines.Add(line);
        }
    }  


}
