using Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            lblResultado.TextAlign = ContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Carga del Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            cmbOperador.SelectedItem = 1;
        }

        /// <summary>
        /// Cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado del label de Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            double decToBin;

            if (double.TryParse(lblResultado.Text, out decToBin))
            {
                decToBin = (int)decToBin;
                lblResultado.Text = n.DecimalBinario(decToBin.ToString());
            }
        }

        /// <summary>
        /// Convierte el valor del label resultado de Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n = new Numero();
            double binToDec = 0;

            if (double.TryParse(lblResultado.Text, out binToDec))
                lblResultado.Text = n.BinarioDecimal(binToDec.ToString());
        }

        /// <summary>
        /// Llama a la funcion Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la operacion matematica seleccionada segun los valores ingresados y el operador selcionado
        /// Si no se selecciona ningun operador, opera una suma por default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double res = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem == null ? "" : cmbOperador.SelectedItem.ToString());
            if (res == double.MinValue)
                lblResultado.Text = "No se puede dividir por 0";
            else
                lblResultado.Text = Math.Round(res, 2).ToString();
        }

        /// <summary>
        /// vacia los textbox de numero y el resultado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Realiza la operacion matematica segun los valores y el operador ingresados
        /// Si no se selecciona un operador, por defecto realiza una suma
        /// llama a la funcion estatica de la Clase Calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
    }
}
