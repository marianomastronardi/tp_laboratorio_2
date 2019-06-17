using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainCorreo
{

    public partial class FormPpal : Form
    {
        private Correo correo = new Correo();
        public FormPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra todos los paquetes en el richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Menu habilitado para los paquetes entregados que se mostraran en el RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Metodo llamado para mostrar la informacion de/l los/paquetes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text += elemento.MostrarDatos(elemento);
                GuardaString.Guardar(rtbMostrar.Text, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Paquetes.txt");
            }
        }

        /// <summary>
        /// Agrega los paquetes ingresados a la lista del correo y luego actualiza el estado hasta llegar a Entregado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += this.paq_InformaEstado;
            try
            {
                correo += p;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException trEx)
            {
                MessageBox.Show(trEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Invoca al metodo que actualiza el estado del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Actualiza el estado del paquete hasta llegar a Entregado
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch ((int)p.Estado)
                {
                    case (int)Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case (int)Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case (int)Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
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

        private void FormPpal_Load(object sender, EventArgs e)
        {

        }
    }
}