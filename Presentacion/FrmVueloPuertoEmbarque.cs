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
using System.Windows.Media.Animation;

namespace Presentacion
{
    public partial class FrmVueloPuertoEmbarque : Form
    {
        nVueloPuertaEmbarque nVueloPuertaEmbarque;
        List<Vuelo_PuertaEmbarque> vuelosPuertaEmbarque;
        nPuertaEmbarque nPuertaEmbarque;
        List<PuertaEmbarque> puertasEmbarque;
        nVuelo nVuelo;
        List<Vuelo> vuelos;
        private int vueloPuertaEmbarqueIDSeleccionado;

        public FrmVueloPuertoEmbarque()
        {
            InitializeComponent();
            nVueloPuertaEmbarque = new nVueloPuertaEmbarque();
            vuelosPuertaEmbarque = new List<Vuelo_PuertaEmbarque>();
            nPuertaEmbarque = new nPuertaEmbarque();
            puertasEmbarque = new List<PuertaEmbarque>();
            nVuelo = new nVuelo();
            vuelos = new List<Vuelo>();
        }

        private void MostrarListaVueloPuertaEmbarque(List<Vuelo_PuertaEmbarque> lista)
        {
            dataVueloPuerta.Rows.Clear();
            foreach (Vuelo_PuertaEmbarque vueloPuertaEmbarque in lista)
            {
                dataVueloPuerta.Rows.Add(
                    vueloPuertaEmbarque.Id,
                    vueloPuertaEmbarque.Vuelo_Codigo_Vuelo,
                    vueloPuertaEmbarque.PuertaEmbarque_Codigo
                );
            }
        }

        private void CrearColumnaVueloPuertaEmbarque()
        {
            dataVueloPuerta.Columns.Clear();
            dataVueloPuerta.Columns.Add("Id", "Id");
            dataVueloPuerta.Columns.Add("Vuelo_Codigo_Vuelo", "Vuelo_Codigo_Vuelo");
            dataVueloPuerta.Columns.Add("PuertaEmbarque_Codigo", "PuertaEmbarque_Codigo");
        }

        private void FrmVueloPuertoEmbarque_Load(object sender, EventArgs e)
        {
            CrearColumnaVueloPuertaEmbarque();
            MostrarVuelosPuertaEmbarque();
            CargarVuelos();
            CargarPuertasEmbarque();
            LimpiarCampos();
        }

        private void MostrarVuelosPuertaEmbarque()
        {
            vuelosPuertaEmbarque = nVueloPuertaEmbarque.ListarVueloPuertaEmbarque();
            MostrarListaVueloPuertaEmbarque(vuelosPuertaEmbarque);
        }

        private void CargarVuelos()
        {
            vuelos = nVuelo.ListarVuelos();
            cbCodigoVuelo.DataSource = vuelos;
            cbCodigoVuelo.DisplayMember = "Identificador_Vuelo";
            cbCodigoVuelo.ValueMember = "Codigo_Vuelo";
        }

        private void CargarPuertasEmbarque()
        {
            puertasEmbarque = nPuertaEmbarque.ListarPuertasEmbarque();
            cbPuerta.DataSource = puertasEmbarque;
            cbPuerta.DisplayMember = "Nombre_Puerta";
            cbPuerta.ValueMember = "Codigo_Puerta";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cbCodigoVuelo.Text == "" || cbPuerta.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                Vuelo_PuertaEmbarque vueloPuertaEmbarque = new Vuelo_PuertaEmbarque();
                vueloPuertaEmbarque.Vuelo_Codigo_Vuelo = (int)cbCodigoVuelo.SelectedValue;
                vueloPuertaEmbarque.PuertaEmbarque_Codigo = (int)cbPuerta.SelectedValue;

                string respuesta = nVueloPuertaEmbarque.Insertar(vueloPuertaEmbarque);
                MessageBox.Show(respuesta);
                MostrarVuelosPuertaEmbarque();
                LimpiarCampos();
            }
        }

        private void dataVueloPuerta_SelectionChanged(object sender, EventArgs e)
        {
            if (dataVueloPuerta.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataVueloPuerta.SelectedRows[0];
                vueloPuertaEmbarqueIDSeleccionado = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                Vuelo_PuertaEmbarque vueloPuertaEmbarqueSeleccionado = vuelosPuertaEmbarque.FirstOrDefault(v => v.Id == vueloPuertaEmbarqueIDSeleccionado);

                if (vueloPuertaEmbarqueSeleccionado != null)
                {
                    cbCodigoVuelo.SelectedValue = vueloPuertaEmbarqueSeleccionado.Vuelo_Codigo_Vuelo;
                    cbPuerta.SelectedValue = vueloPuertaEmbarqueSeleccionado.PuertaEmbarque_Codigo;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if(vueloPuertaEmbarqueIDSeleccionado != 0)
            {
                Vuelo_PuertaEmbarque vueloPuertaEmbarqueModificado = new Vuelo_PuertaEmbarque
                {
                    Id = vueloPuertaEmbarqueIDSeleccionado,
                    Vuelo_Codigo_Vuelo= (int)cbCodigoVuelo.SelectedValue,
                    PuertaEmbarque_Codigo = (int)cbPuerta.SelectedValue
                };

                string respuesta = nVueloPuertaEmbarque.Editar(vueloPuertaEmbarqueModificado);
                MessageBox.Show(respuesta);

                MostrarVuelosPuertaEmbarque();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo-puerta de embarque para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            cbCodigoVuelo.SelectedIndex = -1;
            cbPuerta.SelectedIndex = -1;

            vueloPuertaEmbarqueIDSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (vueloPuertaEmbarqueIDSeleccionado != 0)
            {
                Vuelo_PuertaEmbarque vueloPuertaEmbarqueAEliminar = new Vuelo_PuertaEmbarque
                {
                    Id = vueloPuertaEmbarqueIDSeleccionado
                };

                string respuesta = nVueloPuertaEmbarque.Eliminar(vueloPuertaEmbarqueAEliminar);
                MessageBox.Show(respuesta);

                MostrarVuelosPuertaEmbarque();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo-puerta de embarque para eliminar.");
            }
        }
    }
}
