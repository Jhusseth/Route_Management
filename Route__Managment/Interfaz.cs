using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        double Initiallatitude = 3.42158;
        double initialLength = -76.5205;
        private MetroCali MetroCa;
        public Interfaz()
        {
            InitializeComponent();
            MetroCa = new MetroCali();
        }

        private void Button1_Click(object sender, EventArgs e)
        {   
            //Esta parte se usó para crear elarchivo.dat que da la parsistencia 
            //a la HashTable que uso en la clase MetroCali.
            /*
            int counter = 0;
            String line;
            StreamReader file = new StreamReader("stations1.csv");
            while ((line = file.ReadLine()) != null)
            {
                String[] separator = line.Split(';');
                String busId = separator[0];
                String longName = separator[3];
                double latitude = Convert.ToDouble(separator[7]);
                double lenght = Convert.ToDouble(separator[6]);
                BusStation b = new BusStation(busId, longName, latitude, lenght);
                MetroCa.serialize(b);
            }
            MessageBox.Show("Finalizó");*/
            MetroCa.deserializeS();
            //BusStation b =(BusStation) MetroCa.BusStations["512055"];
            //MessageBox.Show(""+ b.LongName);
            paintStations();
        }

        public void paintStations()
        {
            MetroCa.deserializeS();
            foreach (String de in MetroCa.BusStations.Keys)
            {
                BusStation b = (BusStation)MetroCa.BusStations[de];
                //MessageBox.Show(b.Latitude1 + " " + b.Lenght);
                showStations(b.Latitude1, b.Lenght, b.LongName);

            }

            gMapControl1.Zoom = 12;                
        }

        public void paintStops()
        {
            MetroCa.deserializeP();
            foreach (String de in MetroCa.BusStops.Keys)
            {
                BusStops b = (BusStops)MetroCa.BusStops[de];
                //MessageBox.Show(b.Latitude1 + " " + b.Lenght);
                showStops(b.Latitude1, b.Lenght, b.LongName);
            }
            gMapControl1.Zoom = 12;

        }

        public void showStations(double lat, double len, String name)
        {
            PointLatLng point = new PointLatLng(lat, len);
            marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
            markerOverlay = new GMapOverlay("markers");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format(name);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        public void showStops(double lat, double len, String name)
        {
            PointLatLng point = new PointLatLng(lat, len);
            marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
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
            gMapControl1.Zoom = 11;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            zoomBar.Value = Convert.ToInt32(gMapControl1.Zoom);
        }

        private void ZoomBar_Scroll(object sender, EventArgs e)
        {
            gMapControl1.Zoom = zoomBar.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetroCa.deserializeP();
            paintStops();
        }


        public void clear()
        {
            foreach (String st in MetroCa.BusStations.Keys)
            {
                foreach (String pt in MetroCa.BusStops.Keys)
                {

                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
