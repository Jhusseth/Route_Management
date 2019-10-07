using Route__Managment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modelo
{   
    public class ThreadLine
    {
        private Interfaz main;
        private int time;
        
        public ThreadLine(Interfaz main, int time)
        {
            this.main = main; 
            this.Time = time;


        }

        public int Time { get => time; set => time = value; }
        //creamos un nuevo metodo
        public void pause()
        {
            //Console.WriteLine(name + "Este hilo solo durara" + time + "segundos");

            Thread.Sleep(300); 
            //Console.WriteLine("Hilo terminado " + name);

        }

        public void tasks1()
        {
            main.readingList();
            Thread.Sleep(time * 800);
            main.Refresh();
        }
    }
}
