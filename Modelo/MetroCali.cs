using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Globalization;

namespace Modelo
{

    public class MetroCali
    {
        private Hashtable busStations;
        private Hashtable busStops;
        private Hashtable lines;
		private List<StopPolygon> sPoly;

		public List<Zone> zonas { get; set; }


		public Hashtable BusStations { get => busStations; set => busStations = value; }

        public Hashtable BusStops { get => busStops; set => busStops = value; }
        
        public Hashtable Lines { get => lines; set => lines = value; }

		public List<StopPolygon> PolygonStations { get => sPoly; set => sPoly = value; }

		public Hashtable StateBusOperation { get; set; }

		public MetroCali()
        {
            BusStations = new Hashtable();
			PolygonStations = new List<StopPolygon>();
			BusStops = new Hashtable();
            Lines = new Hashtable();
			this.zonas = new List<Zone>();
			zones();
			this.StateBusOperation = new Hashtable();
		}


        public void deserializeS()
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
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

        public void deserializeP()
        {
            FileStream fs = new FileStream("DataFileP.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
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

		public void uploadStatiosStops()
		{
			StreamReader reader;
			reader = new StreamReader("stopStations.csv");
			String line = "";
			while ((line = reader.ReadLine()) != null)
			{
				String[] stops = line.Split(';');
				StopPolygon stop = new StopPolygon(stops[0], int.Parse(stops[1]), stops[2], stops[3], double.Parse(stops[6]), double.Parse(stops[7]));
				PolygonStations.Add(stop);
			}
		}

		public void uploadOperationalDates()
		{
			StreamReader reader = new StreamReader("operational.csv");
			String line = "";
			reader.ReadLine();
			while ((line = reader.ReadLine()) != null)
			{
				String[] dates = line.Split(';');
			
				String busId = dates[0];
				int dataTime =int.Parse(dates[3]);
				String lineId = dates[4];
				String tripId = dates[5];
				String llave = busId + tripId;

				OperationalData stateOperational = new OperationalData(busId,tripId,lineId,dataTime);
				add(llave, stateOperational);
			}
		}

		public void add(string llave, OperationalData stateOperational)
		{
			foreach (String d in StateBusOperation.Keys)
			{
				if (!llave.Equals(d))
				{
					StateBusOperation.Add(llave, stateOperational);
				}

			}
		}


		public void dataReadingLines(String file)
        {
            StreamReader st = new StreamReader(file);

            String lin = "";            

            while ((lin = st.ReadLine()) != null)
            {
                String[] line = lin.Split(';');
                int idLine = Convert.ToInt32(line[0]);
                string shortName = line[2];
                Line l = new Line(idLine,shortName, line[3]);
                addLines(l,l.LineId);
            }
        }

        public void dataSerealize()
        {
            dataReadingLines("lines.csv");
        }

		public void zones()
		{
			Zone zona1 = new Zone(3.457664, 3.441622, -76.598407, -76.524088);
			zonas.Add(zona1);

			Zone zona2 = new Zone(3.380145, 3.287627, -76.598407, -76.449366);
			zonas.Add(zona2);

			Zone zona3 = new Zone(3.516009, 3.457664, -76.598407, -76.505034);
			zonas.Add(zona3);

			Zone zona4 = new Zone(3.516009, 3.449274, -76.505034, 76.449366);
			zonas.Add(zona4);

			Zone zona5 = new Zone(3.449274, 3.442681, -76.524088, -76.460200);
			zonas.Add(zona5);

			Zone zona6 = new Zone(3.442681, 3.380145, -76.524088, -76.460200);
			zonas.Add(zona6);

			Zone zona7 = new Zone(3.441622, 3.380145, -76.598407, -76.524088);
			zonas.Add(zona7);

			Zone zona8 = new Zone(3.441622, 3.380145, -76.598407, -76.524088);
			zonas.Add(zona8);
		}

		public int isZone(double altitud, double longitud)
		{
			int pos = -1;
			for (int i = 0; i < zonas.Count; i++)
			{
				Zone z = zonas[i];
				if ( altitud >= z.LatitudeMin && altitud <= z.LatitudeMax)
				{
					if (longitud <= z.LongitudeMin && longitud >= z.LongitudeMax)
					{
						pos = i;
					}
				}
			}
			return pos;
		}

		public string stateTimeBus(int time)
		{

			string type = "";
			double value = 0;
			string stateBus = "";
			if (time > 0)
			{
				stateBus = " Adelantado";
			}
			else if (time < 0)
			{
				stateBus = " de Retrazo";
				time = Math.Abs(time);
			}
			if (time > 60)
			{
				type = "Minutos";
				value = time / 60.0;
			}
			else
			{
				type = "Segundos";
				value = time;
			}
			return value.ToString("0.00") + " " + type + stateBus;
		}

		public void addLines(Line line, int lineId) {
            Lines.Add(lineId,line);
        }
    }  


}
