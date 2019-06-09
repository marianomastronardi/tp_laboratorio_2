using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionManager;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        public string StringToDNI
        {
            set { this.dni = ValidarDNI(this.Nacionalidad, value); }
        }

        public int DNI
        {
            get { return dni; }
            set { this.dni = ValidarDNI(this.Nacionalidad, value); }
        }


        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { if (ValidarNombreApellido(value).Length > 0) apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { if (ValidarNombreApellido(value).Length > 0) nombre = value; }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} \n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0} \n\n", this.Nacionalidad);

            return sb.ToString();
        }
        
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (this.Nacionalidad == ENacionalidad.Argentino)
            {
                if (!(dato >= 1 && dato <= 89999999))
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }
            else //Extranjero
            {
                if (!(dato >= 90000000 && dato <= 99999999))
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }
            return dato;
        }

        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int aux = 0;

            if (!(int.TryParse(dato, out aux) && dato.Length <= 8))
                throw new DniInvalidoException();

            return ValidarDNI(nacionalidad, aux);
        }

        private string ValidarNombreApellido(string dato)
        {
            bool IsValid = true;
            int charToASCII;

            List<int> validos = new List<int>() { 128, 129, 130, 132, 135, 137, 139, 142, 144, 145, 146, 148, 153, 154, 155, 157, 160, 161, 162, 163, 164, 165, 181, 211, 214, 216, 224, 225, 233, 255 };
            for (int i = 0; i < dato.Length; i++)
            {
                charToASCII = char.ConvertToUtf32(dato, i);

                //65-90 A-Z
                //97-122 a-z
                IsValid = ((charToASCII >= 65 && charToASCII <= 90) | (charToASCII >= 97 && charToASCII <= 122) | validos.Contains(charToASCII));

                if (!IsValid) break;
            }
            
            return IsValid ? dato : string.Empty;
        }
    }
}
