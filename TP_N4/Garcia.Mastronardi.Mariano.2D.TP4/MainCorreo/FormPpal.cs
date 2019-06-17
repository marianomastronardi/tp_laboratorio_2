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

namespace MainCorreo
{

    public partial class FormPpal : Form
    {
        private Correo correo = new Correo();
        public FormPpal()
        {
            InitializeComponent();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostrar.Text += elemento.MostrarDatos(elemento);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += this.paq_InformaEstado;
            try
            {
                correo += p;
                ActualizarEstados();
            }
            catch(TrackingIdRepetidoException trEx)
            {
                MessageBox.Show(trEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Text = string.Empty;
            lstEstadoEnViaje.Text = string.Empty;
            lstEstadoEntregado.Text = string.Empty;

            foreach(Paquete p in correo.Paquetes)
            {
                switch((int)p.Estado)
                {
                    case (int)Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Text += p.ToString();
                        break;
                    case (int)Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Text += p.ToString();
                        break;
                    case (int)Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Text += p.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void FormPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
    }
}