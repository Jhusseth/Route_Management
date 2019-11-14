using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace UnitTestRoute_Management
{
    //Clase encargada de hacer las pruebas unitarias de la clase MetroCali.

    [TestClass]
    public class UnitTest1
    {
    

        [TestMethod]
        public void TestIsZone()
        {
            MetroCali mc = new MetroCali();
            //mc.isZone(3.30, 75.78);
            int exceptedZone = 1;
            Assert.AreEqual(exceptedZone, mc.isZone(3.287627, -76.449366));
        }

    }
}
