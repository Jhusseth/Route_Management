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
        private ThreadBus thread;
        public Interfaz()
        {
            InitializeComponent();
            MetroCa = new MetroCali();
            thread = new ThreadBus("",0);
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
            gMapControl1.Zoom = 12;           
            foreach (String de in MetroCa.BusStations.Keys)
            {
                
                BusStation b = (BusStation)MetroCa.BusStations[de];
                if ((b.Latitude1 >= 3.447095 && b.Latitude1 <= 3.449836) && (b.Lenght >= -76.512240 && b.Lenght <= -76.546208)&&
                    (b.Latitude1>=0));
                {
                   // MessageBox.Show("hola");
                }
                showStations(b.Latitude1, b.Lenght, b.LongName);     
            }
            paintSector1();
            paintSector2();
            paintSector3();
            paintSector4();
            paintSector5();
            paintSector6();
            paintSector7();
            paintSector8();

            gMapControl1.Zoom = 13;          
        }

        public void paintStations1() {
            foreach (String de in MetroCa.BusStations.Keys)
            {
                BusStation b = (BusStation)MetroCa.BusStations[de];
                if (ValidateSector1(b) == true)
                {
                   // MessageBox.Show(b.Latitude1 + " " + b.Lenght);
                    showStations(b.Latitude1, b.Lenght, b.LongName);
                }
            }
        }

        public bool ValidateSector1(BusStation b) {
            int x = 0;
            bool validation = false;
            if (b.Latitude1 <= 3.46&&b.Latitude1>=3.44&&b.Lenght>=-76.51&&b.Lenght<=-76.5894) {
                validation = true;
            }
           
            return validation;
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
            gMapControl1.Zoom = 13;

        }

        public void showStations(double lat, double len, String name)
        {
            PointLatLng point = new PointLatLng(lat, len);
            Bitmap bmpMaker = (Bitmap)Image.FromFile("stationMarker.png");

            marker = new GMarkerGoogle(point,bmpMaker);

            markerOverlay = new GMapOverlay("markers");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format(name);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        public void showStops(double lat, double len, String name)
        {
            PointLatLng point = new PointLatLng(lat, len);
            Bitmap bmpMaker = (Bitmap)Image.FromFile("marker.png");
            marker = new GMarkerGoogle(point,bmpMaker);
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
            gMapControl1.Zoom = 12;
            gMapControl1.Zoom = 13;
        }


        public void clear()
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Zoom = 12;
            gMapControl1.Zoom = 13;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void UpdateMap_Tick(object sender, EventArgs e)
        {
            
        }

        private void UpdateMap_Tick(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            
        }

        public void paintBus(Double lat, Double len)
        {   
            PointLatLng point = new PointLatLng(lat, len);
            Bitmap bmpMaker = (Bitmap)Image.FromFile("stationMarker.png");
            marker = new GMarkerGoogle(point, bmpMaker);
            markerOverlay = new GMapOverlay("markers");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format("E21");
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            List<Double> x = MetroCa.Bus1.Latitude;
            List<Double> y = MetroCa.Bus1.Lenght;
            Double[] x1 = x.ToArray();
            Double[] x2 = y.ToArray();
            for (int i = 0; i < x1.Length; i++)
            {

            }

        }

        //ESTE METODO DESMARCA TODAS LAS OPCIONES EN CASO DE QUE SE SELECCIONE "Todos" en el check
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
                
            }
        }


        //PINTA LOS 8 SECTORES DE LA CIUDAD, SE DIVIDIERON 
        //EN 8 METODOS PARA OBTENER UNA REFERENCIA POR CADA UNO
        public void paintSector1() {

            markerOverlay = new GMapOverlay("Poligon");
            List<PointLatLng> points = new List<PointLatLng>();
            PointLatLng p1 = new PointLatLng(3.506029,-76.491583);
            PointLatLng p2 = new PointLatLng(3.467794, -76.512240);
            PointLatLng p3 = new PointLatLng(3.447095, -76.546208);
            PointLatLng p4 = new PointLatLng(3.449836, -76.579166);
            PointLatLng p5 = new PointLatLng(3.465260, -76.589468);
            PointLatLng p6 = new PointLatLng(3.464230, -76.559254);
            //PointLatLng p7 = new PointLatLng(3.464230, -76.559254);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            points.Add(p6);
            GMapPolygon poligonos = new GMapPolygon(points,"Poligono");
            markerOverlay.Polygons.Add(poligonos);
      
            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }
        public void paintSector2()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            PointLatLng p1 = new PointLatLng(3.506029, -76.491583);
            PointLatLng p2 = new PointLatLng(3.467794, -76.512240);
            PointLatLng p3 = new PointLatLng(3.465259, -76.473766);
            PointLatLng p4 = new PointLatLng(3.440926, -76.475141);
            PointLatLng p5 = new PointLatLng(3.448809, -76.514622);
            
            //PointLatLng p7 = new PointLatLng(3.464230, -76.559254);
            points.Add(p2);
            points.Add(p1);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);          
            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector3()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            PointLatLng p1 = new PointLatLng(3.448809, -76.514622);
            PointLatLng p2 = new PointLatLng(3.41145, -76.51855);
            PointLatLng p3 = new PointLatLng(3.42927, -76.49795);
            PointLatLng p4 = new PointLatLng(3.44344, -76.49409);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector8()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            PointLatLng p1 = new PointLatLng(3.467794, -76.512240);
            PointLatLng p2 = new PointLatLng(3.41145, -76.51855);
            PointLatLng p3 = new PointLatLng(3.40974, -76.5491);
            PointLatLng p4 = new PointLatLng(3.447095, -76.546208);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector7()
        {
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

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector4()
        {
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

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector5()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            PointLatLng p1 = new PointLatLng(3.42927, -76.49795);
            PointLatLng p2 = new PointLatLng(3.40958, -76.4894);
            PointLatLng p3 = new PointLatLng(3.39519, -76.46777);
            PointLatLng p4 = new PointLatLng(3.37705, -76.50698);
            PointLatLng p5 = new PointLatLng(3.41145, -76.51855);
            //PointLatLng p6 = new PointLatLng(3.44344, -76.49409);


            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
           // points.Add(p6);

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        public void paintSector6()
        {
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

            GMapPolygon poligonos = new GMapPolygon(points, "Poligono");
            markerOverlay.Polygons.Add(poligonos);
            gMapControl1.Zoom = 11;
            gMapControl1.Zoom = 13;

        }

        private void Sector1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Sector2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void Sector3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
