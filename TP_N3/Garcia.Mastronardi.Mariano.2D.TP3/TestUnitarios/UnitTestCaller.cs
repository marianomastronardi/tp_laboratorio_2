using Entidades;
using EntidadesAbstractas;
using ExceptionManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestCaller
    {
        #region "Exception"
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethodNacionalidadException()
        {
            //arrange
            Alumno a1 = new Alumno(1, "Mariano", "Garcia Mastronardi", "10101010", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethodDNIException()
        {
            //arrange
            Alumno a2 = new Alumno(2, "Mariano", "Garcia Mastronardi", "9000000A", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestMethodSinProfesorException()
        {
            //arrange
            Profesor p1 = new Profesor(1, "Fede", "Davila", "89999999", Persona.ENacionalidad.Argentino);
            Alumno a3 = new Alumno(2, "Mariano", "Garcia Mastronardi", "00000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Universidad utn = new Universidad();

            //act
            utn += p1;
            utn += a3;
            utn += Universidad.EClases.Laboratorio;
            utn += Universidad.EClases.Legislacion;
            utn += Universidad.EClases.Programacion;
            utn += Universidad.EClases.SPD;
        }
        #endregion

        #region "Validar Numericos"
        [TestMethod]
        public void TestMethodValidarNumericos()
        {
            //arrange
            int dniOK = 44556677;
            int dniWrong = 0;
            Alumno a1 = new Alumno(1, "Mariano", "Garcia Mastronardi", "00000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            //act
            dniOK = (a1.DNI = dniOK);
            try
            {
                dniWrong = (a1.DNI = dniWrong);
            }
            catch (NacionalidadInvalidaException dniEx)
            {
                dniWrong = 0;
            }
            catch (Exception e)
            {
                dniWrong = 1;
            }

            //assert
            Assert.AreEqual(44556677, dniOK);
            Assert.AreEqual(0, dniWrong);
        }
        #endregion

        #region "Atributos Null"
        [TestMethod]
        public void TestMethodValidarAtributoNull()
        {
            //arrange
            Alumno a1 = new Alumno(1, "Mariano", "Garcia.Mastronardi", "00000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            //assert
            Assert.AreEqual(a1.Apellido, null);

            //act
            a1.Apellido = "Garcia Mastronardi";

            //assert
            Assert.AreEqual(a1.Apellido, "Garcia Mastronardi");

        }
        #endregion
    }
}

