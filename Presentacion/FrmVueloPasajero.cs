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
    public partial class FrmVueloPasajero : Form
    {
        nVueloPasajero nvuelopasajero;
        List<Vuelos_Pasajeros> vuelos_Pasajeros;
        nVuelo nvuelo;
        List<Vuelo> vuelos;
        nPasajero npasajero;
        List<Pasajero> pasajeros;
        private int vueloPasajeroIDSeleccionado;


        public FrmVueloPasajero()
        {
            InitializeComponent();
            nvuelopasajero = new nVueloPasajero();
            vuelos_Pasajeros = new List<Vuelos_Pasajeros>();
            nvuelo = new nVuelo();
            vuelos = new List<Vuelo>();
            npasajero = new nPasajero();
            pasajeros = new List<Pasajero>();
        }

        private void MostrarListaVueloPasajero(List<Vuelos_Pasajeros> lista)
        {
            dataVueloPasajero.Rows.Clear();
            foreach (Vuelos_Pasajeros vueloPasajero in lista)
            {
                dataVueloPasajero.Rows.Add(
                    vueloPasajero.Id,
                    vueloPasajero.Vuelo_Codigo_Vuelo,
                    vueloPasajero.Pasajero_Codigo_Usuario
                );
            }
        }

        private void CrearColumnaVueloPasajero()
        {
            dataVueloPasajero.Columns.Clear();
            dataVueloPasajero.Columns.Add("Id", "Id");
            dataVueloPasajero.Columns.Add("Vuelo_Codigo_Vuelo", "Vuelo_Codigo_Vuelo");
            dataVueloPasajero.Columns.Add("Pasajero_Codigo_Usuario", "Pasajero_Codigo_Usuario");
        }

        private void FrmVueloPasajero_Load(object sender, EventArgs e)
        {
            CrearColumnaVueloPasajero();
            MostrarVuelosPasajeros();
            LimpiarCampos();
            CargarVuelos();
            CargarPasajeros();
        }
        private void MostrarVuelosPasajeros()
        {
            vuelos_Pasajeros = nvuelopasajero.ListarVuelosPasajeros();
            MostrarListaVueloPasajero(vuelos_Pasajeros);
        }

        private void CargarVuelos()
        {
            vuelos = nvuelo.ListarVuelos();
            cbCodigoVuelo.DataSource = vuelos;
            cbCodigoVuelo.DisplayMember = "Identificador_Vuelo";  
            cbCodigoVuelo.ValueMember = "Codigo_Vuelo"; 
        }
        private void CargarPasajeros()
        {
            pasajeros = npasajero.ListarPasajeros();
            cbCodigoPasajero.DataSource = pasajeros;
            cbCodigoPasajero.DisplayMember = "Nombre_Completo";
            cbCodigoPasajero.ValueMember = "Codigo_Pasajero";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCodigoVuelo.Text == "" || cbCodigoPasajero.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                Vuelos_Pasajeros vueloPasajero = new Vuelos_Pasajeros();
                vueloPasajero.Vuelo_Codigo_Vuelo = (int)cbCodigoVuelo.SelectedValue;
                vueloPasajero.Pasajero_Codigo_Usuario = (int)cbCodigoPasajero.SelectedValue;

                string respuesta = nvuelopasajero.Insertar(vueloPasajero);
                MessageBox.Show(respuesta);
                MostrarVuelosPasajeros();
                LimpiarCampos();
            }
        }

        private void dataVueloPasajero_SelectionChanged(object sender, EventArgs e)
        {
            if (dataVueloPasajero.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataVueloPasajero.SelectedRows[0];
                vueloPasajeroIDSeleccionado = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                Vuelos_Pasajeros vueloPasajeroSeleccionado = vuelos_Pasajeros.FirstOrDefault(v => v.Id == vueloPasajeroIDSeleccionado);

                if (vueloPasajeroSeleccionado != null)
                {
                    cbCodigoVuelo.SelectedValue = vueloPasajeroSeleccionado.Vuelo_Codigo_Vuelo;
                    cbCodigoPasajero.SelectedValue = vueloPasajeroSeleccionado.Pasajero_Codigo_Usuario;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (vueloPasajeroIDSeleccionado != 0)
            {
                Vuelos_Pasajeros vueloPasajeroModificado = new Vuelos_Pasajeros
                {
                    Id = vueloPasajeroIDSeleccionado,
                    Vuelo_Codigo_Vuelo = (int)cbCodigoVuelo.SelectedValue,
                    Pasajero_Codigo_Usuario = (int)cbCodigoPasajero.SelectedValue
                };

                string respuesta = nvuelopasajero.Editar(vueloPasajeroModificado);
                MessageBox.Show(respuesta);

                MostrarVuelosPasajeros();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo-pasajero para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            cbCodigoVuelo.SelectedIndex = -1;
            cbCodigoPasajero.SelectedIndex = -1;

            vueloPasajeroIDSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (vueloPasajeroIDSeleccionado != 0)
            {
                Vuelos_Pasajeros vueloPasajeroAEliminar = new Vuelos_Pasajeros
                {
                    Id = vueloPasajeroIDSeleccionado
                };

                string respuesta = nvuelopasajero.Eliminar(vueloPasajeroAEliminar);
                MessageBox.Show(respuesta);

                MostrarVuelosPasajeros();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo-pasajero para eliminar.");
            }
        }
    }
}
