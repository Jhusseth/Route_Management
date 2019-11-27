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

        [TestMethod]
        public void TestAdd()
        {
            OperationalData op = new OperationalData("000", "universidades-menga", "A12A", 5 );
            mc.add(op.BusId, op);
            Assert.IsFalse(mc.StateBusOperation.ContainsKey(op.BusId));

        }


        [TestMethod]
        public void TestStateTimeBus()
        {
            Assert.AreNotEqual(mc.stateTimeBus(90), "1.50 Minutos Adelantado");
            
        }

    }
}
