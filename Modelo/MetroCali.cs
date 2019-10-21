using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Modelo
{
    [Serializable]
=======
using System.Globalization;

namespace Modelo
{

>>>>>>> categorization
    public class MetroCali
    {
        private Hashtable busStations;
        private Hashtable busStops;
<<<<<<< HEAD
        private Bus bus1;
        private Hashtable lines;
=======
        private List<Line> lines;
        StreamReader stLatLng;
        String linLatLng;
       private String datePattern = "dd-MMM-yy hh.mm.ss.ffffff tt";

>>>>>>> categorization

        public Hashtable BusStations { get => busStations; set => busStations = value; }

        public Hashtable BusStops { get => busStops; set => busStops = value; }
<<<<<<< HEAD
        public Bus Bus1 { get => bus1; set => bus1 = value; }
        public Hashtable Lines { get => lines; set => lines = value; }
=======
        
        public List<Line> Lines { get => lines; set => lines = value; }
>>>>>>> categorization

        public MetroCali()
        {
            BusStations = new Hashtable();
            BusStops = new Hashtable();
<<<<<<< HEAD
            Lines = new Hashtable();
=======
            Lines = new List<Line>();
            stLatLng = new StreamReader("datagrams.csv");
            stLatLng.ReadLine();
>>>>>>> categorization
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

<<<<<<< HEAD
        public void serializeBus1(Bus bus) {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            Bus b = bus;
            
            FileStream fs = new FileStream("Bus1.dat", FileMode.Create);
=======
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
>>>>>>> categorization

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
<<<<<<< HEAD
                formatter.Serialize(fs, BusStops);
=======
                formatter.Serialize(fs, Lines);
>>>>>>> categorization
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

<<<<<<< HEAD
        public List<Double> latitudeBus() {

            List<Double> latitude = new List<Double>();

            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            st.ReadLine();
            while((line= st.ReadLine()) != null) {
                String [] lines = st.ReadLine().Split(';');
                double latitud = Convert.ToDouble(lines[4]);
                latitud = latitud / 10000000;
                latitude.Add(latitud);
            }
            return latitude;
        }
        public List<Double> lenghtBus()
=======
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

        public List<Double>[] dataReadingSpecificLine(DateTime dt, String name)
        {
            StreamReader st = new StreamReader("lines.csv");
            String lin = "";
            st.ReadLine();
            while ((lin = st.ReadLine()) != null)
            {
                String[] line = lin.Split(';');
                int idLine = Convert.ToInt32(line[0]);
                string shortName = line[2];
                if (line[2].Equals(name))
                {
                    return latitudeLenghtLine(dt, line[0]);
                }
            }
            return null;
        }

        public void dataSerealize()
        {
            dataReadingLines("lines.csv");
        }

        public List<Double> lenghtLine(int lineId)
>>>>>>> categorization
        {

            List<Double> lenght = new List<Double>();

<<<<<<< HEAD
            StreamReader st = new StreamReader("Bus1.csv");
            String line = "";
            st.ReadLine();
            while ((line = st.ReadLine()) != null)
            {
                String[] lines = st.ReadLine().Split(';');
                double latitud = Convert.ToDouble(lines[5]);
                latitud = latitud / 10000000;
                lenght.Add(latitud);
=======
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

>>>>>>> categorization
            }
            return lenght;
        }

<<<<<<< HEAD
        public void addLines(Line line) {
            Lines.Add(line.LineId, line);
=======
        public List<Double>[] latitudeLenghtLine(DateTime dt, String nm)
        {
            List<Double>[] point = new List<double>[2];
            List<Double> latitude = new List<Double>();
            List<Double> lenght = new List<Double>();

            Boolean sRead = true;
            if(linLatLng != null)
            {

            }
            else
            {
                linLatLng = stLatLng.ReadLine();
            }
            
            while ((linLatLng) != null &&sRead)
            {
                String[] lines = linLatLng.Split(';');
                String b = lines[10];

                DateTime date;
                DateTime.TryParseExact(b, datePattern, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out date);
                Console.WriteLine(dt.TimeOfDay + "  "+ date.TimeOfDay);
                if (dt.TimeOfDay >= date.TimeOfDay)
                {


                    int num = int.Parse(lines[7]);
                   

                    
                    if (lines[7].Equals(nm))
                    {


                        double lent = Convert.ToDouble(lines[5]);
                        lent = lent / 10000000;
                        lenght.Add(lent);
                        double latitud = Convert.ToDouble(lines[4]);
                        latitud = latitud / 10000000;
                        latitude.Add(latitud);
                      
                    }
                    linLatLng = stLatLng.ReadLine();
                }
                else
                {
                    sRead = false;
                }
            }
            point[0] = latitude;
            point[1] = lenght;
            return point;
        }

   



        public void addLines(Line line) {
            Lines.Add(line);
>>>>>>> categorization
        }
    }  


}
