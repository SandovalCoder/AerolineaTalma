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
    public partial class FrmServicioTalmaVuelo : Form
    {
        nServicioTalmaVuelo nServicioTalmaVuelo;
        List<ServiciosTalma_Vuelo> servicios_talma_vuelos;
        nVuelo nVuelo;
        List<Vuelo> vuelos;
        nEquipoLimpieza nEquipoLimpieza;
        List<Equipo_ServicioLimpieza> equipos_limpieza;
        nEquipoRampa nEquipoRampa;
        List<Equipo_ServicioRampa> equipos_rampa;
        private int servicioTalmaVueloIDSeleccionado;

        public FrmServicioTalmaVuelo()
        {
            InitializeComponent();
            nServicioTalmaVuelo = new nServicioTalmaVuelo();
            servicios_talma_vuelos = new List<ServiciosTalma_Vuelo>();
            nVuelo = new nVuelo();
            vuelos = new List<Vuelo>();
            nEquipoLimpieza = new nEquipoLimpieza();
            equipos_limpieza = new List<Equipo_ServicioLimpieza>();
            nEquipoRampa = new nEquipoRampa();
            equipos_rampa = new List<Equipo_ServicioRampa>();
        }

        private void MostrarListaServicioTalmaVuelo(List<ServiciosTalma_Vuelo> lista)
        {
            dataServicioTalma.Rows.Clear();
            foreach (ServiciosTalma_Vuelo servicioTalmaVuelo in lista)
            {
                dataServicioTalma.Rows.Add(
                    servicioTalmaVuelo.Codigo_Servicio,
                    servicioTalmaVuelo.Equipo_ServicioRampa_Codigo,
                    servicioTalmaVuelo.Equipo_ServicioLimpieza_Codigo,
                    servicioTalmaVuelo.Vuelo_Codigo_Vuelo
                );
            }
        }

        private void CrearColumnaServicioTalmaVuelo()
        {
            dataServicioTalma.Columns.Clear();
            dataServicioTalma.Columns.Add("Codigo_Servicio", "Codigo_Servicio");
            dataServicioTalma.Columns.Add("Equipo_ServicioRampa_Codigo", "Equipo_ServicioRampa_Codigo");
            dataServicioTalma.Columns.Add("Equipo_ServicioLimpieza_Codigo", "Equipo_ServicioLimpieza_Codigo");
            dataServicioTalma.Columns.Add("Vuelo_Codigo_Vuelo", "Vuelo_Codigo_Vuelo");
        }

        private void FrmServicioTalmaVuelo_Load(object sender, EventArgs e)
        {
            CrearColumnaServicioTalmaVuelo();
            MostrarServiciosTalmaVuelos();
            LimpiarCampos();
            CargarVuelos();
            CargarEquiposLimpieza();
            CargarEquiposRampa();
        }

        private void MostrarServiciosTalmaVuelos()
        {
            servicios_talma_vuelos = nServicioTalmaVuelo.ListarServicioTalmaVuelo();
            MostrarListaServicioTalmaVuelo(servicios_talma_vuelos);
        }

        private void CargarVuelos()
        {
            vuelos = nVuelo.ListarVuelos();
            cbCodigoVuelo.DataSource = vuelos;
            cbCodigoVuelo.DisplayMember = "Identificador_Vuelo";
            cbCodigoVuelo.ValueMember = "Codigo_Vuelo";
        }

        private void CargarEquiposLimpieza()
        {
            equipos_limpieza = nEquipoLimpieza.ListarEquipoLimpieza();
            cbCodigoLimpieza.DataSource = equipos_limpieza;
            cbCodigoLimpieza.DisplayMember = "Recursos_Empleados";
            cbCodigoLimpieza.ValueMember = "Codigo_EpLimpienza";
        }

        private void CargarEquiposRampa()
        {
            equipos_rampa = nEquipoRampa.ListarEquipoRampa();
            cbCodigoRampa.DataSource = equipos_rampa;
            cbCodigoRampa.DisplayMember = "Recursos_Empleados";
            cbCodigoRampa.ValueMember = "Codigo_EpServicio";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            if(cbCodigoRampa.Text == "" || cbCodigoLimpieza.Text == "" || cbCodigoVuelo.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                ServiciosTalma_Vuelo serviciosTalma_Vuelo = new ServiciosTalma_Vuelo();
                serviciosTalma_Vuelo.Equipo_ServicioRampa_Codigo = (int)cbCodigoRampa.SelectedValue;
                serviciosTalma_Vuelo.Equipo_ServicioLimpieza_Codigo = (int)cbCodigoLimpieza.SelectedValue;
                serviciosTalma_Vuelo.Vuelo_Codigo_Vuelo = (int)cbCodigoVuelo.SelectedValue;

                string respuesta = nServicioTalmaVuelo.Insertar(serviciosTalma_Vuelo);
                MessageBox.Show(respuesta);
                MostrarServiciosTalmaVuelos();
                LimpiarCampos();
            }
        }

        private void dataServicioTalma_SelectionChanged(object sender, EventArgs e)
        {
            if (dataServicioTalma.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataServicioTalma.SelectedRows[0];
                servicioTalmaVueloIDSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Servicio"].Value);

                ServiciosTalma_Vuelo servicioTalmaVueloSeleccionado = servicios_talma_vuelos.FirstOrDefault(stv => stv.Codigo_Servicio == servicioTalmaVueloIDSeleccionado);

                if (servicioTalmaVueloSeleccionado != null)
                {
                    cbCodigoRampa.SelectedValue = servicioTalmaVueloSeleccionado.Equipo_ServicioRampa_Codigo;
                    cbCodigoLimpieza.SelectedValue = servicioTalmaVueloSeleccionado.Equipo_ServicioLimpieza_Codigo;
                    cbCodigoVuelo.SelectedValue = servicioTalmaVueloSeleccionado.Vuelo_Codigo_Vuelo;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (servicioTalmaVueloIDSeleccionado != 0)
            {
                ServiciosTalma_Vuelo servicioTalmaVueloModificado = new ServiciosTalma_Vuelo
                {
                    Codigo_Servicio = servicioTalmaVueloIDSeleccionado,
                    Equipo_ServicioRampa_Codigo = (int)cbCodigoRampa.SelectedValue, 
                    Equipo_ServicioLimpieza_Codigo = (int)cbCodigoLimpieza.SelectedValue,
                    Vuelo_Codigo_Vuelo = (int)cbCodigoVuelo.SelectedValue
                };

                string respuesta = nServicioTalmaVuelo.Editar(servicioTalmaVueloModificado);
                MessageBox.Show(respuesta);

                MostrarServiciosTalmaVuelos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un servicio talma vuelo para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            cbCodigoRampa.SelectedIndex = -1;
            cbCodigoLimpieza.SelectedIndex = -1;
            cbCodigoVuelo.SelectedIndex = -1;

            servicioTalmaVueloIDSeleccionado = 0;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (servicioTalmaVueloIDSeleccionado != 0)
            {
                ServiciosTalma_Vuelo servicioTalmaVueloAEliminar = new ServiciosTalma_Vuelo
                {
                    Codigo_Servicio = servicioTalmaVueloIDSeleccionado
                };

                string respuesta = nServicioTalmaVuelo.Eliminar(servicioTalmaVueloAEliminar);
                MessageBox.Show(respuesta);

                MostrarServiciosTalmaVuelos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un servicio talma vuelo para eliminar.");
            }
        }
    }
}
