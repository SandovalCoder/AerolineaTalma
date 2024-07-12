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
using System.Windows.Annotations;

namespace Presentacion
{
    public partial class FrmPuertaEmbarque : Form
    {
        nPuertaEmbarque nPuertaEmba;
        List<PuertaEmbarque> puertasEmbarque;
        private int puertaEmbarqueIdSeleccionado;

        public FrmPuertaEmbarque()
        {
            InitializeComponent();
            nPuertaEmba = new nPuertaEmbarque();
            puertasEmbarque = new List<PuertaEmbarque>();
        }

        private void MostrarListaPuertaEmbarque(List<PuertaEmbarque> lista)
        {
            dataPuertaEmbarque.Rows.Clear();
            foreach (PuertaEmbarque puertaEmbarque in lista)
            {
                dataPuertaEmbarque.Rows.Add(
                    puertaEmbarque.Codigo_Puerta,
                    puertaEmbarque.Nombre_Puerta,
                    puertaEmbarque.Ubicacion,
                    puertaEmbarque.Tipo
                );
            }
        }

        private void CrearColumnaPuertaEmbarque()
        {
            dataPuertaEmbarque.Columns.Clear();
            dataPuertaEmbarque.Columns.Add("Codigo_Puerta", "Codigo_Puerta");
            dataPuertaEmbarque.Columns.Add("Nombre_Puerta", "Nombre_Puerta");
            dataPuertaEmbarque.Columns.Add("Ubicacion", "Ubicacion");
            dataPuertaEmbarque.Columns.Add("Tipo", "Tipo");
        }

        private void FrmPuertaEmbarque_Load(object sender, EventArgs e)
        {
            CrearColumnaPuertaEmbarque();
            MostrarPuertasEmbarque();
            LimpiarCampos();
        }

        private void MostrarPuertasEmbarque()
        {
            puertasEmbarque = nPuertaEmba.ListarPuertasEmbarque();
            MostrarListaPuertaEmbarque(puertasEmbarque);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(textUbicacion.Text == "" || cbTipo.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                PuertaEmbarque puertaEmbarque = new PuertaEmbarque();
                puertaEmbarque.Nombre_Puerta = textNombrePuerta.Text;
                puertaEmbarque.Ubicacion = textUbicacion.Text;
                puertaEmbarque.Tipo = cbTipo.Text;

                string respuesta = nPuertaEmba.Insertar(puertaEmbarque);
                MessageBox.Show(respuesta);
                MostrarPuertasEmbarque();
                LimpiarCampos();
            }
        }

        private void dataPuertaEmbarque_SelectionChanged(object sender, EventArgs e)
        {
            if (dataPuertaEmbarque.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataPuertaEmbarque.SelectedRows[0];
                puertaEmbarqueIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Puerta"].Value);

                PuertaEmbarque puertaEmbarqueSeleccionado = puertasEmbarque.FirstOrDefault(pu => pu.Codigo_Puerta == puertaEmbarqueIdSeleccionado);

                if (puertaEmbarqueSeleccionado != null)
                {
                    textNombrePuerta.Text = puertaEmbarqueSeleccionado.Nombre_Puerta;
                    textUbicacion.Text = puertaEmbarqueSeleccionado.Ubicacion;
                    cbTipo.Text = puertaEmbarqueSeleccionado.Tipo;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (puertaEmbarqueIdSeleccionado != 0)
            {
                PuertaEmbarque puertaEmbarqueModificado = new PuertaEmbarque
                {
                    Codigo_Puerta = puertaEmbarqueIdSeleccionado,
                    Nombre_Puerta = textNombrePuerta.Text,
                    Ubicacion = textUbicacion.Text,
                    Tipo = cbTipo.Text
                };

                string respuesta = nPuertaEmba.Editar(puertaEmbarqueModificado);
                MessageBox.Show(respuesta);

                MostrarPuertasEmbarque();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una puerta de embarque para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            textNombrePuerta.Text = "";
            textUbicacion.Text = "";
            cbTipo.SelectedIndex = -1;

            puertaEmbarqueIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (puertaEmbarqueIdSeleccionado != 0)
            {
                PuertaEmbarque puertaEmbarqueAEliminar = new PuertaEmbarque
                {
                    Codigo_Puerta = puertaEmbarqueIdSeleccionado
                };

                string respuesta = nPuertaEmba.Eliminar(puertaEmbarqueAEliminar);
                MessageBox.Show(respuesta);

                MostrarPuertasEmbarque();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una puerta de embarque para eliminar.");
            }
        }

        private void btnVueloPuertaEmbarque_Click(object sender, EventArgs e)
        {
            FrmVueloPuertoEmbarque frmVueloPuertoEmbarque = new FrmVueloPuertoEmbarque();
            frmVueloPuertoEmbarque.Show();
        }
    }
}
