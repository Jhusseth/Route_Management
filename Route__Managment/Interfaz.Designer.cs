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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Simulate = new System.Windows.Forms.Button();
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
            this.listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(130, 9);
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
            this.gMapControl1.Size = new System.Drawing.Size(917, 606);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(12, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Estaciones";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(7, 530);
            this.zoomBar.Maximum = 25;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(101, 45);
            this.zoomBar.TabIndex = 2;
            this.zoomBar.Scroll += new System.EventHandler(this.ZoomBar_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Cyan;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(12, 334);
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
            this.button3.Location = new System.Drawing.Point(12, 456);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 37);
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
            // Simulate
            // 
            this.Simulate.BackColor = System.Drawing.Color.Cyan;
            this.Simulate.ForeColor = System.Drawing.Color.Black;
            this.Simulate.Location = new System.Drawing.Point(12, 397);
            this.Simulate.Name = "Simulate";
            this.Simulate.Size = new System.Drawing.Size(96, 37);
            this.Simulate.TabIndex = 11;
            this.Simulate.Text = "Simular";
            this.Simulate.UseVisualStyleBackColor = false;
            this.Simulate.Click += new System.EventHandler(this.Simulate_Click);
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
            this.AllSectors.Location = new System.Drawing.Point(49, 222);
            this.AllSectors.Name = "AllSectors";
            this.AllSectors.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AllSectors.Size = new System.Drawing.Size(56, 17);
            this.AllSectors.TabIndex = 21;
            this.AllSectors.Text = "Todos";
            this.AllSectors.UseVisualStyleBackColor = true;
            this.AllSectors.CheckedChanged += new System.EventHandler(this.AllSectors_CheckedChanged);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(1053, 9);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(65, 602);
            this.listBox.TabIndex = 22;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // Interfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1121, 619);
            this.Controls.Add(this.listBox);
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
            this.Controls.Add(this.Simulate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gMapControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Interfaz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIO_SYSTEM_TRASNPORT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Simulate;
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
        private System.Windows.Forms.ListBox listBox;
    }
}

