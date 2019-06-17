using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListPaquetesIniciado()
        {
            //arrange
            Correo correo;

            //act
            correo = new Correo();

            //assert
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestTrackingRepetido()
        {
            //arrange
            Paquete p1;
            Paquete p2;
            Correo c = new Correo();

            //act
            p1 = new Paquete("Salta 123", "11-11-11");
            p2 = new Paquete("Salta 124", "11-11-11");
            c += p1;
            c += p2;
        }
    }
}
