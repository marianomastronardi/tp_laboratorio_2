using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

        }

        private void btnConccertirADecimal_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = string.Empty;
        }

        static double Operar(string numero1, string numero2, string operador)
        {
            return double.MinValue;
        }
    }
}
