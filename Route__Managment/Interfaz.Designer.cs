namespace Route__Managment
{
    partial class Interfaz
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.zoomBar = new System.Windows.Forms.TrackBar();
			this.timerBuses = new System.Windows.Forms.Timer(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.updateMap = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.Sector1 = new System.Windows.Forms.CheckBox();
			this.Sector2 = new System.Windows.Forms.CheckBox();
			this.Sector3 = new System.Windows.Forms.CheckBox();
			this.Sector4 = new System.Windows.Forms.CheckBox();
			this.Sector5 = new System.Windows.Forms.CheckBox();
			this.Sector6 = new System.Windows.Forms.CheckBox();
			this.Sector7 = new System.Windows.Forms.CheckBox();
			this.Sector8 = new System.Windows.Forms.CheckBox();
			this.AllSectors = new System.Windows.Forms.CheckBox();
			this.upload_btn = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.RELOJ = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ComboBox();
			this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
			this.panelMap = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tiempo = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
			this.panelMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Cyan;
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(9, 348);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 37);
			this.button1.TabIndex = 1;
			this.button1.Text = "Estaciones";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// zoomBar
			// 
			this.zoomBar.Location = new System.Drawing.Point(6, 607);
			this.zoomBar.Maximum = 25;
			this.zoomBar.Name = "zoomBar";
			this.zoomBar.Size = new System.Drawing.Size(101, 45);
			this.zoomBar.TabIndex = 2;
			this.zoomBar.Scroll += new System.EventHandler(this.ZoomBar_Scroll);
			// 
			// timerBuses
			// 
			this.timerBuses.Interval = 1000;
			this.timerBuses.Tick += new System.EventHandler(this.TimerBuses_Tick);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Cyan;
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.Location = new System.Drawing.Point(9, 407);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 37);
			this.button2.TabIndex = 4;
			this.button2.Text = "Paradas";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Cyan;
			this.button3.ForeColor = System.Drawing.Color.Black;
			this.button3.Location = new System.Drawing.Point(985, 197);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(62, 37);
			this.button3.TabIndex = 5;
			this.button3.Text = "Clear";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "  ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(46, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Paradas";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(46, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Estaciones";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.SystemColors.HotTrack;
			this.label6.Location = new System.Drawing.Point(12, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(13, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "  ";
			// 
			// updateMap
			// 
			this.updateMap.Interval = 1000;
			this.updateMap.Tick += new System.EventHandler(this.UpdateMap_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Sectores";
			// 
			// Sector1
			// 
			this.Sector1.AutoSize = true;
			this.Sector1.Location = new System.Drawing.Point(20, 117);
			this.Sector1.Name = "Sector1";
			this.Sector1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector1.Size = new System.Drawing.Size(32, 17);
			this.Sector1.TabIndex = 13;
			this.Sector1.Text = "1";
			this.Sector1.UseVisualStyleBackColor = true;
			this.Sector1.CheckedChanged += new System.EventHandler(this.Sector1_CheckedChanged);
			// 
			// Sector2
			// 
			this.Sector2.AutoSize = true;
			this.Sector2.Location = new System.Drawing.Point(73, 117);
			this.Sector2.Name = "Sector2";
			this.Sector2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector2.Size = new System.Drawing.Size(32, 17);
			this.Sector2.TabIndex = 14;
			this.Sector2.Text = "2";
			this.Sector2.UseVisualStyleBackColor = true;
			this.Sector2.CheckedChanged += new System.EventHandler(this.Sector2_CheckedChanged);
			// 
			// Sector3
			// 
			this.Sector3.AutoSize = true;
			this.Sector3.Location = new System.Drawing.Point(20, 140);
			this.Sector3.Name = "Sector3";
			this.Sector3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector3.Size = new System.Drawing.Size(32, 17);
			this.Sector3.TabIndex = 15;
			this.Sector3.Text = "3";
			this.Sector3.UseVisualStyleBackColor = true;
			this.Sector3.CheckedChanged += new System.EventHandler(this.Sector3_CheckedChanged);
			// 
			// Sector4
			// 
			this.Sector4.AutoSize = true;
			this.Sector4.Location = new System.Drawing.Point(73, 140);
			this.Sector4.Name = "Sector4";
			this.Sector4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector4.Size = new System.Drawing.Size(32, 17);
			this.Sector4.TabIndex = 16;
			this.Sector4.Text = "4";
			this.Sector4.UseVisualStyleBackColor = true;
			this.Sector4.CheckedChanged += new System.EventHandler(this.Sector4_CheckedChanged);
			// 
			// Sector5
			// 
			this.Sector5.AutoSize = true;
			this.Sector5.Location = new System.Drawing.Point(20, 163);
			this.Sector5.Name = "Sector5";
			this.Sector5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector5.Size = new System.Drawing.Size(32, 17);
			this.Sector5.TabIndex = 17;
			this.Sector5.Text = "5";
			this.Sector5.UseVisualStyleBackColor = true;
			this.Sector5.CheckedChanged += new System.EventHandler(this.Sector5_CheckedChanged);
			// 
			// Sector6
			// 
			this.Sector6.AutoSize = true;
			this.Sector6.Location = new System.Drawing.Point(73, 163);
			this.Sector6.Name = "Sector6";
			this.Sector6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector6.Size = new System.Drawing.Size(32, 17);
			this.Sector6.TabIndex = 18;
			this.Sector6.Text = "6";
			this.Sector6.UseVisualStyleBackColor = true;
			this.Sector6.CheckedChanged += new System.EventHandler(this.Sector6_CheckedChanged);
			// 
			// Sector7
			// 
			this.Sector7.AutoSize = true;
			this.Sector7.Location = new System.Drawing.Point(20, 186);
			this.Sector7.Name = "Sector7";
			this.Sector7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector7.Size = new System.Drawing.Size(32, 17);
			this.Sector7.TabIndex = 19;
			this.Sector7.Text = "7";
			this.Sector7.UseVisualStyleBackColor = true;
			this.Sector7.CheckedChanged += new System.EventHandler(this.Sector7_CheckedChanged);
			// 
			// Sector8
			// 
			this.Sector8.AutoSize = true;
			this.Sector8.Location = new System.Drawing.Point(73, 186);
			this.Sector8.Name = "Sector8";
			this.Sector8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Sector8.Size = new System.Drawing.Size(32, 17);
			this.Sector8.TabIndex = 20;
			this.Sector8.Text = "8";
			this.Sector8.UseVisualStyleBackColor = true;
			this.Sector8.CheckedChanged += new System.EventHandler(this.Sector8_CheckedChanged);
			// 
			// AllSectors
			// 
			this.AllSectors.AutoSize = true;
			this.AllSectors.Location = new System.Drawing.Point(20, 210);
			this.AllSectors.Name = "AllSectors";
			this.AllSectors.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AllSectors.Size = new System.Drawing.Size(56, 17);
			this.AllSectors.TabIndex = 21;
			this.AllSectors.Text = "Todos";
			this.AllSectors.UseVisualStyleBackColor = true;
			this.AllSectors.CheckedChanged += new System.EventHandler(this.AllSectors_CheckedChanged);
			// 
			// upload_btn
			// 
			this.upload_btn.BackColor = System.Drawing.Color.Aqua;
			this.upload_btn.ForeColor = System.Drawing.Color.Black;
			this.upload_btn.Location = new System.Drawing.Point(985, 148);
			this.upload_btn.Margin = new System.Windows.Forms.Padding(2);
			this.upload_btn.Name = "upload_btn";
			this.upload_btn.Size = new System.Drawing.Size(62, 41);
			this.upload_btn.TabIndex = 23;
			this.upload_btn.Text = "Cargar";
			this.upload_btn.UseVisualStyleBackColor = false;
			this.upload_btn.Click += new System.EventHandler(this.Button4_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Cyan;
			this.button4.ForeColor = System.Drawing.Color.Black;
			this.button4.Location = new System.Drawing.Point(9, 465);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 37);
			this.button4.TabIndex = 24;
			this.button4.Text = "Simular";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.Button4_Click_1);
			// 
			// RELOJ
			// 
			this.RELOJ.AutoSize = true;
			this.RELOJ.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RELOJ.Location = new System.Drawing.Point(10, 272);
			this.RELOJ.Name = "RELOJ";
			this.RELOJ.Size = new System.Drawing.Size(70, 21);
			this.RELOJ.TabIndex = 25;
			this.RELOJ.Text = "00:00:00";
			this.RELOJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.Cyan;
			this.button5.ForeColor = System.Drawing.Color.Black;
			this.button5.Location = new System.Drawing.Point(9, 528);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 37);
			this.button5.TabIndex = 26;
			this.button5.Text = "Para simulación";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.Button5_Click);
			// 
			// listBox
			// 
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new System.Drawing.Point(985, 605);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(62, 21);
			this.listBox.TabIndex = 27;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// gMapControl1
			// 
			this.gMapControl1.AutoScroll = true;
			this.gMapControl1.AutoSize = true;
			this.gMapControl1.Bearing = 0F;
			this.gMapControl1.CanDragMap = true;
			this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
			this.gMapControl1.GrayScaleMode = false;
			this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gMapControl1.LevelsKeepInMemmory = 5;
			this.gMapControl1.Location = new System.Drawing.Point(3, 0);
			this.gMapControl1.MarkersEnabled = true;
			this.gMapControl1.MaxZoom = 2;
			this.gMapControl1.MinZoom = 2;
			this.gMapControl1.MouseWheelZoomEnabled = true;
			this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gMapControl1.Name = "gMapControl1";
			this.gMapControl1.NegativeMode = false;
			this.gMapControl1.PolygonsEnabled = true;
			this.gMapControl1.RetryLoadTile = 0;
			this.gMapControl1.RoutesEnabled = true;
			this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gMapControl1.ShowTileGridLines = false;
			this.gMapControl1.Size = new System.Drawing.Size(973, 674);
			this.gMapControl1.TabIndex = 0;
			this.gMapControl1.Zoom = 0D;
			// 
			// panelMap
			// 
			this.panelMap.AutoScroll = true;
			this.panelMap.AutoSize = true;
			this.panelMap.Controls.Add(this.label7);
			this.panelMap.Controls.Add(this.label2);
			this.panelMap.Controls.Add(this.tiempo);
			this.panelMap.Controls.Add(this.listBox);
			this.panelMap.Controls.Add(this.upload_btn);
			this.panelMap.Controls.Add(this.gMapControl1);
			this.panelMap.Controls.Add(this.button3);
			this.panelMap.Location = new System.Drawing.Point(114, 2);
			this.panelMap.MaximumSize = new System.Drawing.Size(1303, 769);
			this.panelMap.MinimumSize = new System.Drawing.Size(1020, 565);
			this.panelMap.Name = "panelMap";
			this.panelMap.Size = new System.Drawing.Size(1274, 756);
			this.panelMap.TabIndex = 28;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(999, 637);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "Lineas";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(990, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 28;
			this.label2.Text = "Velocidad";
			// 
			// tiempo
			// 
			this.tiempo.FormattingEnabled = true;
			this.tiempo.Location = new System.Drawing.Point(985, 31);
			this.tiempo.Name = "tiempo";
			this.tiempo.Size = new System.Drawing.Size(62, 21);
			this.tiempo.TabIndex = 1;
			this.tiempo.SelectedIndexChanged += new System.EventHandler(this.tiempo_SelectedIndexChanged);
			// 
			// Interfaz
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1172, 670);
			this.Controls.Add(this.panelMap);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.RELOJ);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.AllSectors);
			this.Controls.Add(this.Sector8);
			this.Controls.Add(this.Sector7);
			this.Controls.Add(this.Sector6);
			this.Controls.Add(this.Sector5);
			this.Controls.Add(this.Sector4);
			this.Controls.Add(this.Sector3);
			this.Controls.Add(this.Sector2);
			this.Controls.Add(this.Sector1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.zoomBar);
			this.Controls.Add(this.button1);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "Interfaz";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MIO_SYSTEM_TRASNPORT";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
			this.panelMap.ResumeLayout(false);
			this.panelMap.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar zoomBar;
		private System.Windows.Forms.Timer timerBuses;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer updateMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Sector1;
        private System.Windows.Forms.CheckBox Sector2;
        private System.Windows.Forms.CheckBox Sector3;
        private System.Windows.Forms.CheckBox Sector4;
        private System.Windows.Forms.CheckBox Sector5;
        private System.Windows.Forms.CheckBox Sector6;
        private System.Windows.Forms.CheckBox Sector7;
        private System.Windows.Forms.CheckBox Sector8;
        private System.Windows.Forms.CheckBox AllSectors;
        private System.Windows.Forms.Button upload_btn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label RELOJ;
        private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ComboBox listBox;
		private GMap.NET.WindowsForms.GMapControl gMapControl1;
		private System.Windows.Forms.Panel panelMap;
		private System.Windows.Forms.ComboBox tiempo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label2;
	}
}

