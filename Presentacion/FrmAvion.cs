using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos;

namespace Presentacion
{
    public partial class FrmAvion : Form
    {
        nAvion navion;
        List<Avion> aviones;
        private int avionIdSeleccionado;

        public FrmAvion()
        {
            InitializeComponent();
            navion = new nAvion();
            aviones = new List<Avion>();
        }

        private void MostrarListaAvion(List<Avion> lista)
        {
            dataAvion.Rows.Clear();
            foreach (Avion avion in lista)
            {
                dataAvion.Rows.Add(
                    avion.Codigo_Avion,
                    avion.Modelo,
                    avion.Longitud_Metros,
                    avion.Ancho_Metros,
                    avion.Capacidad
         
                );
            }
        }

        private void CrearColumnaAvion()
        {
            dataAvion.Columns.Clear();
            dataAvion.Columns.Add("Codigo_Avion", "Codigo_Avion");
            dataAvion.Columns.Add("Modelo", "Modelo");
            dataAvion.Columns.Add("Longitud_Metros", "Longitud_Metros");
            dataAvion.Columns.Add("Ancho_Metros", "Ancho_Metros");
            dataAvion.Columns.Add("Capacidad", "Capacidad");
        }

        private void FrmAvion_Load(object sender, EventArgs e)
        {
            CrearColumnaAvion();
            MostrarAviones();
            LimpiarCampos();
        }

        private void MostrarAviones()
        {
            aviones = navion.ListarAviones();
            MostrarListaAvion(aviones);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textModelo.Text == " " || textLongitud.Text == "" || textAncho.Text == "" || textCapacidad.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
               
                if (!int.TryParse(textCapacidad.Text, out int capacidad) || capacidad <= 0)
                {
                    MessageBox.Show("La capacidad debe ser un número mayor a 0.");
                    return;
                }
                else
                {
                    Avion avion = new Avion();
                    avion.Modelo = textModelo.Text;
                    avion.Longitud_Metros = textLongitud.Text;
                    avion.Ancho_Metros = textAncho.Text;
                    avion.Capacidad = capacidad;

                    string respuesta = navion.Insertar(avion);
                    MessageBox.Show(respuesta);
                    MostrarAviones();
                    LimpiarCampos();
                }
               
            }
        }

        private void dataAvion_SelectionChanged(object sender, EventArgs e)
        {

            if (dataAvion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataAvion.SelectedRows[0];
                avionIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Avion"].Value);

                Avion avionSeleccionado = aviones.FirstOrDefault(av => av.Codigo_Avion == avionIdSeleccionado);

                if (avionSeleccionado != null)
                {
                    textModelo.Text = avionSeleccionado.Modelo;
                    textLongitud.Text = avionSeleccionado.Longitud_Metros;
                    textAncho.Text = avionSeleccionado.Ancho_Metros;
                    textCapacidad.Text = avionSeleccionado.Capacidad.ToString();
                }
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (avionIdSeleccionado != 0)
            {
                Avion avionModificado = new Avion
                {
                    Codigo_Avion = avionIdSeleccionado,
                    Modelo = textModelo.Text,
                    Longitud_Metros = textLongitud.Text,
                    Ancho_Metros = textAncho.Text,
                    Capacidad = Convert.ToInt32(textCapacidad.Text)
                };

                string respuesta = navion.Editar(avionModificado);
                MessageBox.Show(respuesta);

                MostrarAviones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un avion para modificar.");
            }
        }
        private void LimpiarCampos()
        {
            textModelo.Text = "";
            textLongitud.Text = "";
            textAncho.Text = "";
            textCapacidad.Text = "";
            avionIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (avionIdSeleccionado != 0)
            {
                Avion avionAEliminar = new Avion
                {
                    Codigo_Avion = avionIdSeleccionado
                };

                string respuesta = navion.Eliminar(avionAEliminar);
                MessageBox.Show(respuesta);

                MostrarAviones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un avion para eliminar.");

            }
        }

        private void btnVuelo_Click(object sender, EventArgs e)
        {
            FrmVuelo frmVuelo = new FrmVuelo();
            frmVuelo.Show();
        }
    }
}
