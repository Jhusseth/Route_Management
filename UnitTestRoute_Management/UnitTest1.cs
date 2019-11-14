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

        MetroCali mc = new MetroCali();

        [TestMethod]
        public void TestIsZoneA()
        {
            int exceptedZone = 1;
            Assert.AreEqual(exceptedZone, mc.isZone(3.287627, -76.449366));
        }

        [TestMethod]
        public void TestIsZoneB()
        {
            int exceptedZoneB = -1;
            Assert.AreEqual(exceptedZoneB, mc.isZone(3.832123, 73.38929));
        }

        [TestMethod]
        public void TestAddLine()
        {
            Line lin = new Line(17, "E21", "Universidades-Menga");
            mc.addLines(lin, 17);
            Assert.IsTrue(mc.Lines.ContainsKey(17));
            
        }

        [TestMethod]
        public void TestDataReadingLine()
        {
            mc.dataReadingLines("TextTemplate1.tt");
            Assert.IsTrue(mc.Lines.ContainsKey(131));
        }

    }
}
