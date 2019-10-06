using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modelo
{   
    public class ThreadBus
    {
        private Line line;
        private int time;
        
        public ThreadBus( Line line, int time)
        {
            this.line = line; 
            this.time = time;


        }
        //creamos un nuevo metodo
        public void pause()
        {
            //Console.WriteLine(name + "Este hilo solo durara" + time + "segundos");

            Thread.Sleep(500); 
            //Console.WriteLine("Hilo terminado " + name);

        }

        public void tasks2()
        {
            Console.WriteLine(line.LineId + "Este hilo solo durara" + time + "segundos");

            Thread.Sleep(time * 1000);

            Console.WriteLine("Hilo terminado " + line.LineId);

        }
    }
}
