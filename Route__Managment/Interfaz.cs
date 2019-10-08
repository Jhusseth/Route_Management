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




        double Initiallatitude = 3.42158;
        double initialLength = -76.5205;
        private MetroCali MetroCa;
        
        public Interfaz()
        {
            InitializeComponent();
            MetroCa = new MetroCali();
            list();
            MetroCa.dataSerealize();
            //addLines();
            //serializeMainClass();
            //MetroCa.Lines.Clear();
            // MessageBox.Show(""+MetroCa.Lines.ContainsKey("T31"));

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


        public void list()
        {

            List<string> items = new List<string>();

            foreach (Line v in MetroCa.Lines)
            {
                items.Add(v.ShortName);
            }


            comboBoxLines.DataSource = items;
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
            Bitmap bmpMaker = (Bitmap)Image.FromFile("bus.png");
            marker = new GMarkerGoogle(point, bmpMaker);
            markerOverlay = new GMapOverlay("markersV");
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = string.Format("Bus");
            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Zoom = 13;
            gMapControl1.Zoom = 13.001;
        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            
            
            Refresh();

            //ThreadStart delegado = new ThreadStart(readingList);
            //Thread hilo = new Thread(delegado); 
            //hilo.Start();

            readingList();


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


        //PINTA LOS 8 SECTORES DE LA CIUDAD, SE DIVIDIERON 
        //EN 8 METODOS PARA OBTENER UNA REFERENCIA POR CADA UNO
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
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
                gMapControl1.Zoom = 11;
                gMapControl1.Zoom = 11.2;
            }
            else
            {
                markerOverlay6.Clear();
            }

        }

        public void serializeMainClass() {
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
           
            FileStream fs = new FileStream("MetroCali.dat", FileMode.Create);
            MessageBox.Show("compiló");


            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, MetroCa);
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

        public void readingList()
        {

           // String index = comboBoxLines.Text;


            //foreach (Line v in MetroCa.Lines)
            //{
               // if (v.ShortName.Equals(index))
                //{
                    // gMapControl1.Refresh();
                    //paintList(v.latitudeBus(v.LineId), v.lenghtBus(v.LineId), v);
                    //List<Double> lat = MetroCa.latitudeLine(v.LineId);
                    //List<Double> len = MetroCa.lenghtLine(v.LineId);
                    //paintList(lat, len, v);
                    //this.Refresh();


                    StreamReader st = new StreamReader("datagrams.csv");
                    String line = "";
                    st.ReadLine();
                    String anterior = "01:00:00";

                    while ((line = st.ReadLine()) != null)
                    {
                //MessageBox.Show(".");
                       String[] lines = line.Split(';');
                        
                        String[] timer = lines[10].Split(' ');
                        String[] timerH = timer[1].Split('.');
                        String times = timerH[0] + ":" + timerH[1] + ":" + timerH[2];
                        Time.Text = times;
                        int lat = Convert.ToInt32(4);
                        int len = Convert.ToInt32(5);
                        paintBus(lat, len);
                        //MessageBox.Show(times);
                if (anterior == times)
                {
                    paintBus(lat, len);
                }
                else{
                    gMapControl1.Overlays.Clear();
                    anterior = times;
                    paintBus(lat, len);
                }
            }
        }

        public void paintList(List<Double> lista1, List<Double> lista2 ,Line l)
        {

            Double[] x1 = lista1.ToArray();
            Double[] x2 = lista2.ToArray();
                int i = 0;
                while (i < x1.Length)
                {
                    paintBus(x1[i], x2[i]);
                    gMapControl1.Zoom = 11;
                    gMapControl1.Zoom = 11.01;
                    Thread.Sleep(800);
                    gMapControl1.Overlays.Clear();
                    i++;
                }

            MessageBox.Show("Finalizo la linea: " + l.ShortName);
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            readingList();
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
    }
}
