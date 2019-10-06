using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Modelo
{   
    [Serializable]
    public class ThreadBus
    {
        private String name;
        private int time;
        
        public ThreadBus(String name, int time)
        {
            this.name = name; 
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
            Console.WriteLine(name + "Este hilo solo durara" + time + "segundos");

            Thread.Sleep(time * 1000);

            Console.WriteLine("Hilo terminado " + name);

        }
    }
}
