using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

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
      string[] arr = { "+", "-", "*", "/" };
      cmbOperador.Items.AddRange(arr);
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnConvertirABinario_Click(object sender, EventArgs e)
    {
      Numero n = new Numero();
      lblResultado.Text = n.DecimalBinario(lblResultado.Text);
    }

    private void btnConvertirADecimal_Click(object sender, EventArgs e)
    {
      Numero n = new Numero();
      lblResultado.Text = n.BinarioDecimal(lblResultado.Text);
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      Limpiar();
    }

    private void btnOperar_Click(object sender, EventArgs e)
    {
      lblResultado.Text = Convert.ToInt32(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString())).ToString();
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
      Numero n1 = new Numero(numero1);
      Numero n2 = new Numero(numero2);
      return Calculadora.Operar(n1, n2, operador);
    }
  }
}
