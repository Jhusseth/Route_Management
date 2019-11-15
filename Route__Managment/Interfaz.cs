using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Modelo;

namespace Route__Managment
{
    public partial class Interfaz : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        GMapOverlay markerOverlay1;
        GMapOverlay markerOverlay2;
        GMapOverlay markerOverlay3;
        GMapOverlay markerOverlay4;
        GMapOverlay markerOverlay5;
        GMapOverlay markerOverlay6;
        GMapOverlay markerOverlay7;
        GMapOverlay markerOverlay8;


        GMapPolygon poligonos1;
        GMapPolygon poligonos2;
        GMapPolygon poligonos3;
        GMapPolygon poligonos4;
        GMapPolygon poligonos5;
        GMapPolygon poligonos6;
        GMapPolygon poligonos7;
        GMapPolygon poligonos8;

		GMapOverlay Poligono;


		List<Bus> buses;

		double Initiallatitude = 3.42158;
        double initialLength = -76.5205;
        private MetroCali MetroCa;

		private bool isVisible;

		public Interfaz()
        {
            InitializeComponent();
            MetroCa = new MetroCali();
			buses =  new List<Bus>();
			isVisible = false;
			Poligono = new GMapOverlay("Poligono");
		}

        private void Button1_Click(object sender, EventArgs e)
        {
			//paintStations();
			paintPolyStops();
		}

        public void list()
        {
            List<string> items = new List<string>();
			items.Add("");
			items.Add("TODAS");
			foreach (int id in MetroCa.Lines.Keys)
            {
				Line v = (Line) MetroCa.Lines[id];
                items.Add(v.ShortName);
            }
            listBox.DataSource = items;
        }

        public void paintStations()
        {
			//foreach (String de in MetroCa.BusStations.Keys)
			//{
			//	BusStation b = (BusStation)MetroCa.BusStations[de];
			//	showStations(b.Latitude1, b.Lenght, b.LongName);
			//}

			//foreach (var p in MetroCa.PolygonStations)
			//{
			//	PolygonStops n = (PolygonStops) p;
			//	ShowStations(n.Latitude, n.Lenght, n.ShortName);
			//}
			//refreshMap();

		}

		public void paintPolyStops()
		{
			for (int i = 0; i < MetroCa.PolygonStations.Count; i++)
			{
				showStops(MetroCa.PolygonStations[i].Latitude, MetroCa.PolygonStations[i].Lenght, MetroCa.PolygonStations[i].ShortName);
			}
			refreshMap();
		}



		public void paintStops()
        {
            foreach (String de in MetroCa.BusStops.Keys)
            {
                BusStops b = (BusStops)MetroCa.BusStops[de];
                showStops(b.Latitude1, b.Lenght, b.LongName);
            }
			refreshMap();

		}

        public void showStations(double lat, double len, String name)
        {

            PointLatLng point = new PointLatLng(lat, len);
            Bitmap bmpMaker = (Bitmap)Image.FromFile("stationMarker.png");

            marker = new GMarkerGoogle(point, bmpMaker);

            markerOverlay = new GMapOverlay("markersStop");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format(name);
            gMapControl1.Overlays.Add(markerOverlay);
        }

		public void showStops(double lat, double len, String name)
        {
            PointLatLng point = new PointLatLng(lat, len);
            Bitmap bmpMaker = (Bitmap)Image.FromFile("marker.png");
            marker = new GMarkerGoogle(point, bmpMaker);
            markerOverlay = new GMapOverlay("markersP");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format(name);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(Initiallatitude, initialLength);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 13;
			zoomBar.Value = (int) gMapControl1.Zoom;
			CheckForIllegalCrossThreadCalls = false;
        }

        private void TimerBuses_Tick(object sender, EventArgs e)
        {
            zoomBar.Value = Convert.ToInt32(gMapControl1.Zoom);

			if (!buses.Any())
			{
				buses = showBus(int.Parse(tiempo.Text), null);
			}
			else
			{
				Bus busLast = buses.Last();

				buses.Clear();

				buses = showBus(int.Parse(tiempo.Text), busLast);
			}

			if (buses.Count > 0)
			{
				string draw = listBox.Text;
				removeAllM();
				drawBus(draw);
			}
			else
			{
				timerBuses.Stop();
			}
		}

		private void ZoomBar_Scroll(object sender, EventArgs e)
		{
			gMapControl1.Zoom = zoomBar.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paintStops();
        }


        public void clear()
        {
            Sector1.Enabled = true;
            Sector2.Enabled = true;
            Sector3.Enabled = true;
            Sector4.Enabled = true;
            Sector5.Enabled = true;
            Sector6.Enabled = true;
            Sector7.Enabled = true;
            Sector8.Enabled = true;
            Sector1.Checked = false;
            Sector2.Checked = false;
            Sector3.Checked = false;
            Sector4.Checked = false;
            Sector5.Checked = false;
            Sector6.Checked = false;
            Sector7.Checked = false;
            Sector8.Checked = false;
			refreshMap();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			removeAllM();
            clear();
		}

        private void UpdateMap_Tick(object sender, EventArgs e)
        {

		}
        private void AllSectors_CheckedChanged(object sender, EventArgs e)
        {
            if (AllSectors.Checked == true)
            {
                Sector1.Enabled = false;
                Sector2.Enabled = false;
                Sector3.Enabled = false;
                Sector4.Enabled = false;
                Sector5.Enabled = false;
                Sector6.Enabled = false;
                Sector7.Enabled = false;
                Sector8.Enabled = false;
                Sector1.Checked = false;
                Sector2.Checked = false;
                Sector3.Checked = false;
                Sector4.Checked = false;
                Sector5.Checked = false;
                Sector6.Checked = false;
                Sector7.Checked = false;
                Sector8.Checked = false;

                Sector1.Checked = true;
                Sector2.Checked = true;
                Sector3.Checked = true;
                Sector4.Checked = true;
                Sector5.Checked = true;
                Sector6.Checked = true;
                Sector7.Checked = true;
                Sector8.Checked = true;

            }
            else {
                Sector1.Enabled = true;
                Sector2.Enabled = true;
                Sector3.Enabled = true;
                Sector4.Enabled = true;
                Sector5.Enabled = true;
                Sector6.Enabled = true;
                Sector7.Enabled = true;
                Sector8.Enabled = true;

                Sector1.Checked = false;
                Sector2.Checked = false;
                Sector3.Checked = false;
                Sector4.Checked = false;
                Sector5.Checked = false;
                Sector6.Checked = false;
                Sector7.Checked = false;
                Sector8.Checked = false;
            }
        }

        public void paintSector1() {
            if (Sector1.Checked == true)
            {
                markerOverlay1 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.506029, -76.491583);
                PointLatLng p2 = new PointLatLng(3.467794, -76.512240);
                PointLatLng p3 = new PointLatLng(3.447095, -76.546208);
                PointLatLng p4 = new PointLatLng(3.449836, -76.579166);
                PointLatLng p5 = new PointLatLng(3.465260, -76.589468);
                PointLatLng p6 = new PointLatLng(3.464230, -76.559254);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                points.Add(p6);
                poligonos1 = new GMapPolygon(points, "Poligono");
                markerOverlay1.Polygons.Add(poligonos1);
                gMapControl1.Overlays.Add(markerOverlay1);
				refreshMap();
			}
            else
            {
                markerOverlay1.Clear();
            }

        }
        public void paintSector2()
        {
            if (Sector2.Checked == true)
            {
                markerOverlay2 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.506029, -76.491583);
                PointLatLng p2 = new PointLatLng(3.467794, -76.512240);
                PointLatLng p3 = new PointLatLng(3.465259, -76.473766);
                PointLatLng p4 = new PointLatLng(3.440926, -76.475141);
                PointLatLng p5 = new PointLatLng(3.448809, -76.514622);
                points.Add(p2);
                points.Add(p1);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                poligonos2 = new GMapPolygon(points, "Poligono");
                markerOverlay2.Polygons.Add(poligonos2);
                gMapControl1.Overlays.Add(markerOverlay2);
				refreshMap();
			}
            else
            {
                markerOverlay2.Clear();
            }
        }

        public void paintSector3()
        {
            if (Sector3.Checked == true)
            {
                markerOverlay3 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.448809, -76.514622);
                PointLatLng p2 = new PointLatLng(3.41145, -76.51855);
                PointLatLng p3 = new PointLatLng(3.42927, -76.49795);
                PointLatLng p4 = new PointLatLng(3.44344, -76.49409);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                poligonos3 = new GMapPolygon(points, "Poligono");
                markerOverlay3.Polygons.Add(poligonos3);
                gMapControl1.Overlays.Add(markerOverlay3);
				refreshMap();
			}
            else
            {
                markerOverlay3.Clear();
            }
        }

        public void paintSector8()
        {
            if (Sector8.Checked == true)
            {
                markerOverlay8 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.467794, -76.512240);
                PointLatLng p2 = new PointLatLng(3.41145, -76.51855);
                PointLatLng p3 = new PointLatLng(3.40974, -76.5491);
                PointLatLng p4 = new PointLatLng(3.447095, -76.546208);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                poligonos8 = new GMapPolygon(points, "Poligono");
                markerOverlay8.Polygons.Add(poligonos8);
                gMapControl1.Overlays.Add(markerOverlay8);
				refreshMap();
			}
            else
            {
                markerOverlay8.Clear();
            }
        }

        public void paintSector7()
        {
            if (Sector7.Checked == true)
            {
                markerOverlay7 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.40974, -76.5491);
                PointLatLng p2 = new PointLatLng(3.37433, -76.54002);
                PointLatLng p3 = new PointLatLng(3.36434, -76.56145);
                PointLatLng p4 = new PointLatLng(3.449836, -76.579166);
                PointLatLng p5 = new PointLatLng(3.447095, -76.546208);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                poligonos7 = new GMapPolygon(points, "Poligono");
                markerOverlay7.Polygons.Add(poligonos7);
                gMapControl1.Overlays.Add(markerOverlay7);
				refreshMap();
            }
            else
            {
                markerOverlay7.Clear();
            }
        }

        public void paintSector4()
        {
            if (Sector4.Checked == true)
            {
                markerOverlay4 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.440926, -76.475141);
                PointLatLng p2 = new PointLatLng(3.437, -76.45301);
                PointLatLng p3 = new PointLatLng(3.39519, -76.46777);
                PointLatLng p4 = new PointLatLng(3.40958, -76.4894);
                PointLatLng p5 = new PointLatLng(3.42927, -76.49795);
                PointLatLng p6 = new PointLatLng(3.44344, -76.49409);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                points.Add(p6);
                poligonos4 = new GMapPolygon(points, "Poligono");
                markerOverlay4.Polygons.Add(poligonos4);
                gMapControl1.Overlays.Add(markerOverlay4);
				refreshMap();
			}
            else
            {
                markerOverlay4.Clear();
            }

        }

        public void paintSector5()
        {
            if (Sector5.Checked == true)
            {
                markerOverlay5 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.42927, -76.49795);
                PointLatLng p2 = new PointLatLng(3.40958, -76.4894);
                PointLatLng p3 = new PointLatLng(3.39519, -76.46777);
                PointLatLng p4 = new PointLatLng(3.37705, -76.50698);
                PointLatLng p5 = new PointLatLng(3.41145, -76.51855);
                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                poligonos5 = new GMapPolygon(points, "Poligono");
                markerOverlay5.Polygons.Add(poligonos5);
                gMapControl1.Overlays.Add(markerOverlay5);
				refreshMap();
			}
            else
            {
                markerOverlay5.Clear();
            }

        }

        public void paintSector6()
        {
            if (Sector6.Checked == true)
            {
                markerOverlay6 = new GMapOverlay("Poligon");
                List<PointLatLng> points = new List<PointLatLng>();
                PointLatLng p1 = new PointLatLng(3.41145, -76.51855);
                PointLatLng p2 = new PointLatLng(3.37705, -76.50698);
                PointLatLng p3 = new PointLatLng(3.31936, -76.51477);
                PointLatLng p4 = new PointLatLng(3.32004, -76.5527);
                PointLatLng p5 = new PointLatLng(3.36434, -76.56145);
                PointLatLng p6 = new PointLatLng(3.37433, -76.54002);
                PointLatLng p7 = new PointLatLng(3.40974, -76.5491);


                points.Add(p1);
                points.Add(p2);
                points.Add(p3);
                points.Add(p4);
                points.Add(p5);
                points.Add(p6);
                points.Add(p7);

                poligonos6 = new GMapPolygon(points, "Poligono");
                markerOverlay6.Polygons.Add(poligonos6);
                gMapControl1.Overlays.Add(markerOverlay6);
				refreshMap();
			}
            else
            {
                markerOverlay6.Clear();
            }

        }

        private void Sector1_CheckedChanged(object sender, EventArgs e)
        {
            paintSector1();
        }


        private void Sector2_CheckedChanged(object sender, EventArgs e)
        {
            paintSector2();
        }

        private void Sector3_CheckedChanged(object sender, EventArgs e)
        {
            paintSector3();
        }

        private void Sector4_CheckedChanged(object sender, EventArgs e)
        {
            paintSector4();
        }

        private void Sector5_CheckedChanged(object sender, EventArgs e)
        {
            paintSector5();
        }

        private void Sector6_CheckedChanged(object sender, EventArgs e)
        {
            paintSector6();
        }

        private void Sector7_CheckedChanged(object sender, EventArgs e)
        {
            paintSector7();
        }

        private void Sector8_CheckedChanged(object sender, EventArgs e)
        {
            paintSector8();
        }


		private void Button4_Click(object sender, EventArgs e)
        {
            MetroCa.dataSerealize();
			//MetroCa.deserializeS();
			MetroCa.dataread();
			MetroCa.deserializeP();
			List<string> items = new List<string>();

			items.Add("60");
			items.Add("30");
			items.Add("5");
			items.Add("1");
			tiempo.DataSource = items;

			list();
			upload_btn.Enabled = false;
		}

		private void Button4_Click_1(object sender, EventArgs e)
        {
			timerBuses.Enabled = true;
			timerBuses.Start();
		}

        private void Button5_Click(object sender, EventArgs e)
        {
			timerBuses.Stop();
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
	    }

		public List<Bus> showBus(int time, Bus last)
		{
			List<Bus> listBus = new List<Bus>();
			StreamReader read = new StreamReader("datagrams.csv");
			String line = "";
			Bus bus = null;
			String[] data;
			Bus actual;
			List<int> idBus = new List<int>();
			bool encontrado = false;
			if (last == null)
			{
				line = read.ReadLine();
				data = line.Split(';');
				actual = new Bus(data[0], data[1], int.Parse(data[2]), double.Parse(data[4]), double.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), long.Parse(data[9]), int.Parse(data[10]));
				bus = actual;
			}
			else
			{

				line = read.ReadLine();
				while (!encontrado && !read.EndOfStream)
				{
					data = line.Split(';');
					actual = new Bus(data[0], data[1], int.Parse(data[2]), double.Parse(data[4]), double.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), long.Parse(data[9]), int.Parse(data[10]));
					if (last.dataGramId == actual.dataGramId)
					{
						encontrado = true;
						if ((line = read.ReadLine()) != null)
						{
							data = line.Split(';');
							actual = new Bus(data[0], data[1], int.Parse(data[2]), double.Parse(data[4]), double.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), long.Parse(data[9]), int.Parse(data[10]));

						}
						bus = actual;
					}
					else
					{
						line = read.ReadLine();
						if (read.EndOfStream)
						{
							return null;
						}
					}
				}
			}

			String[] hourPrincipal = bus.hour.Split('.');
			encontrado = false;
			while (!encontrado && !read.EndOfStream)
			{
				if (horario(hourPrincipal))
				{
					encontrado = true;
				}
				else
				{
					line = read.ReadLine();
					data = line.Split(';');
					bus = new Bus(data[0], data[1], int.Parse(data[2]), double.Parse(data[4]), double.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), long.Parse(data[9]), int.Parse(data[10]));
					hourPrincipal = bus.hour.Split('.');
				}
			}
			encontrado = false;

			while (!read.EndOfStream && !encontrado && ((line = read.ReadLine()) != null))
			{

				data = line.Split(';');
				actual = new Bus(data[0], data[1], int.Parse(data[2]), double.Parse(data[4]), double.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), long.Parse(data[9]), int.Parse(data[10]));

				if ((actual.latitude != -1 && actual.longitude != -1))
				{
					String[] hourCompare = actual.hour.Split('.');
					bool isContain = timeCompare(hourPrincipal, hourCompare, time);
					if (isContain)
					{
						if (!idBus.Contains(actual.busId))
						{
							idBus.Add(actual.busId);
							listBus.Add(actual);
						}
					}
					else
					{
						encontrado = true;
					}
				}
			}

			return listBus;
		}


		private bool horario(String[] hour)
		{
			bool ok;
			int h = int.Parse(hour[0]);
			String t = hour[2].Substring(3, hour.Length - 1);
			if (t == "AM" && (h == 12 || h <= 5))
			{
				ok = false;
			}
			else
			{
				ok = true;
			}
			return ok;
		}

		private bool timeCompare(String[] hourPrincipal, String[] hourBuscado, int time)
		{
			bool mayor = false;
			int secondP = int.Parse(hourPrincipal[2].Substring(0, 2));
			int secondB = int.Parse(hourBuscado[2].Substring(0, 2));
			int mP = int.Parse(hourPrincipal[1]);
			int mB = int.Parse(hourBuscado[1]);

			int limited = time + secondP;

			if (time != 60)
			{
				if (limited > 60)
				{
					limited -= 60;
					if (secondB <= Math.Abs(limited) || secondB >= secondP)
					{
						mayor = true;
					}
				}
				else
				{
					if (secondB >= secondP && secondB <= limited)
					{
						mayor = true;
					}
				}
			}
			else
			{
				if ((secondB >= secondP && mB == mP) || (secondB <= secondP && mB == (mP + 1)))
				{
					mayor = true;
				}
			}
			return mayor;
		}

		private void removeAllM()
		{
			if (gMapControl1.Overlays.Count > 0)
			{
				gMapControl1.Overlays.Clear();
				gMapControl1.Refresh();
			}
		}

		private void drawBus(string draw)
		{
			List<Bus> theDefinitiveList = buses;

			String[] reloj2 = theDefinitiveList[0].hour.Split(' ');
			String[] reloj1 = reloj2[0].Split('.');

			RELOJ.Text = reloj1[0] + ":" + reloj1[1] + ":" + reloj1[2] + " " + reloj2[1];
			int n = theDefinitiveList.Count();

			if (!draw.Equals("") && !draw.Equals("TODAS"))
			{
				for (int i = 0; i < buses.Count; i++)
				{
					Line theLine = ((Line)(MetroCa.Lines[theDefinitiveList[i].lineId]));
					if (theLine != null)
					{
						Console.WriteLine("{0}, {1}", theLine.ShortName, draw);
						if (theLine.ShortName.Equals(draw))
						{
							busAllShow(theDefinitiveList[i].latitude, theDefinitiveList[i].longitude, theDefinitiveList[i].busId, theLine.LineId);
						}
					}
				}
				refreshMap();
			}
			else if (!draw.Equals("") && draw.Equals("TODAS"))
			{
				for (int i = 0; i < buses.Count; i++)
				{
					Line theLine = ((Line)(MetroCa.Lines[theDefinitiveList[i].lineId]));
					if (theLine != null)
					{
						busAllShow(theDefinitiveList[i].latitude, theDefinitiveList[i].longitude, theDefinitiveList[i].busId, theLine.LineId);
					}
				}
				refreshMap();
			}

			else
			{
				for (int i = 0; i < n; i++)
				{
					paintZone(theDefinitiveList[i]);

				}
				refreshMap();
			}

		}

		private void refreshMap()
		{
			gMapControl1.Zoom = gMapControl1.Zoom + 0.001;
			gMapControl1.Zoom = gMapControl1.Zoom - 0.001;
		}


		private void paintZone(Bus bus)
		{
			if (Sector1.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 0, bus.busId, bus.lineId);
			}
		
			if (Sector2.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 3, bus.busId, bus.lineId);
			}
			if (Sector3.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 5, bus.busId, bus.lineId);
			}
			if (Sector4.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 5, bus.busId, bus.lineId);
			}
			if (Sector5.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 4, bus.busId, bus.lineId);
			}
			if (Sector6.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 1, bus.busId, bus.lineId);
			}
			if (Sector7.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 7, bus.busId, bus.lineId);
			}

			if (Sector8.Checked == true)
			{
				busZone(bus.latitude, bus.longitude, 7, bus.busId, bus.lineId);
			}
		}

		private void busZone(double lat, double longi, int zone, int busId, int lineId)
		{
			if (MetroCa.isZone(lat, longi) == zone)
			{
				PointLatLng point = new PointLatLng(lat, longi);
				GMapMarker theMarker = new GMarkerGoogle(point, new Bitmap("bus.png"));
				addLabelPointBus(theMarker, busId, lineId);

				GMapOverlay markers = new GMapOverlay("markers");
				markers.Markers.Add(theMarker);
				gMapControl1.Overlays.Add(markers);
			}
		}

		private void busAllShow(double lat, double longi, int busId, int lineId)
		{
			PointLatLng point = new PointLatLng(lat, longi);
			GMapMarker theMarker = new GMarkerGoogle(point, new Bitmap("bus.png"));
			addLabelPointBus(theMarker, busId, lineId);

			GMapOverlay markers = new GMapOverlay("markers");
			markers.Markers.Add(theMarker);
			gMapControl1.Overlays.Add(markers);
		}

		private void addLabelPointBus(GMapMarker marck, int busId, int lineId)
		{
			Line ruta = ((Line)(MetroCa.Lines[lineId]));
			if (ruta != null)
			{
				marck.ToolTipText = $"ID: {busId}, \nRuta: {ruta.ShortName}, \nDesc: {ruta.description}";
			}
			else
			{
				marck.ToolTipText = $"ID: {busId}";
			}
			GMapToolTip theTip = new GMapToolTip(marck);
			theTip.Fill = new SolidBrush(Color.Black);
			theTip.Foreground = new SolidBrush(Color.White);

			marck.ToolTip = theTip;
		}

		public void PolygonsInStops()
		{
			int j;
			for (int i = 0; i < MetroCa.PolygonStations.Count; i++)
			{
				j = i;
				String name = MetroCa.PolygonStations[i].LongName.Substring(0, MetroCa.PolygonStations[i].LongName.Length - 3);
				String nameCompare = MetroCa.PolygonStations[j + 1].LongName.Substring(0, MetroCa.PolygonStations[j + 1].LongName.Length - 3);
				List<StopPolygon> listStopStation = new List<StopPolygon>();
				listStopStation.Add(MetroCa.PolygonStations[i]);
				while (name.Trim().Equals(nameCompare.Trim()))
				{
					j++;

					if (j < MetroCa.PolygonStations.Count)
					{

						if ((j + 1) < MetroCa.PolygonStations.Count)
						{
							listStopStation.Add(MetroCa.PolygonStations[j]);
							nameCompare = MetroCa.PolygonStations[j + 1].LongName.Substring(0, MetroCa.PolygonStations[j + 1].LongName.Length - 3);
						}
						else
						{
							nameCompare = "";
						}

					}
					else
					{
						nameCompare = "";
					}
					
				}
				PolygonStation(ConvexHull(listStopStation, listStopStation.Count));
				i = j;
			}
		}

		public List<StopPolygon> ConvexHull(List<StopPolygon> polyStop, int n)
		{

			List<StopPolygon> convex = new List<StopPolygon>();
			int l = 0;

			for (int i = 1; i < n; i++)
			{
				if (polyStop[i].Lenght < polyStop[l].Lenght)
				{
					l = i;
				}
			}

			int p = l, q;

			do
			{
				convex.Add(polyStop[p]);

				q = (p + 1) % n;

				for (int i = 0; i < n; i++)
				{
					if (Address(polyStop[p], polyStop[i], polyStop[q]) == 2)
						q = i;
				}
				p = q;
			} while (p != l);

			return convex;
		}

		public int Address(StopPolygon ponit1, StopPolygon point2, StopPolygon ponit3)
		{
			double value = (point2.Latitude - ponit1.Latitude) * (ponit3.Lenght - point2.Lenght) - (point2.Lenght - ponit1.Lenght) * (ponit3.Latitude - point2.Latitude);

			if (value == 0)
			{
				return 0;
			}

			return (value > 0) ? 1 : 2;
		}

		private void PolygonStation(List<StopPolygon> polyStop)
		{
			List<PointLatLng> puntos = new List<PointLatLng>();
			double lat, len;
			for (int i = 0; i < polyStop.Count; i++)
			{
				lat = polyStop[i].Latitude;
				len = polyStop[i].Lenght;
				puntos.Add(new PointLatLng(lat, len));
			}
			GMapPolygon polygonPoint = new GMapPolygon(puntos, "Polygono");
			Poligono.Polygons.Add(polygonPoint);
			gMapControl1.Overlays.Add(Poligono);
			refreshMap();
		}
		private void tiempo_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		public void MouseEventHandler()
		{
			//String zoom1 = gMapControl1.Zoom.ToString();
			//int zoom = int.Parse(zoom1);
			//if (zoom >= 16 && !isVisible)
			//{
			//	paintPolyStops();
			//	PolygonsInStops();
			//	isVisible = true;
			//}
			//else if (zoom < 16)
			//{
			//	Poligono.Clear();
			//	paintStations();
			//	isVisible = false;
			//	refreshMap();
			//}
		}
	}
}