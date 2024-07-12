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
    public partial class FrmAvionEquipaje : Form
    {
        nAvionEquipaje navionequipaje;
        List<Avion_Equipaje> aviones_equipajes;
        nAvion navion;
        List<Avion> aviones;
        nEquipaje nequipaje;
        List<Equipaje> equipajes;
        private int avionEquipajeIDSeleccionado;


        public FrmAvionEquipaje()
        {
            InitializeComponent();
            navionequipaje = new nAvionEquipaje();
            aviones_equipajes = new List<Avion_Equipaje>();
            navion = new nAvion();
            aviones = new List<Avion>();
            nequipaje = new nEquipaje();
            equipajes = new List<Equipaje>();
        }

        private void MostrarListaAvionEquipaje(List<Avion_Equipaje> lista)
        {
            dataAvionEquipaje.Rows.Clear();
            foreach (Avion_Equipaje avionEquipaje in lista)
            {
                dataAvionEquipaje.Rows.Add(
                    avionEquipaje.Id,
                    avionEquipaje.Avion_Codigo,
                    avionEquipaje.Equipaje_Codigo_Equipaje
                );
            }
        }

        private void CrearColumnaAvionEquipaje()
        {
            dataAvionEquipaje.Columns.Clear();
            dataAvionEquipaje.Columns.Add("Id", "Id");
            dataAvionEquipaje.Columns.Add("Avion_Codigo", "Avion_Codigo");
            dataAvionEquipaje.Columns.Add("Equipaje_Codigo_Equipaje", "Equipaje_Codigo_Equipaje");
        }

        private void FrmAvionEquipaje_Load(object sender, EventArgs e)
        {
            CrearColumnaAvionEquipaje();
            MostrarAvionesEquipajes();
            LimpiarCampos();
            CargarAviones();
            CargarEquipajes();
        }

        private void MostrarAvionesEquipajes()
        {
            aviones_equipajes = navionequipaje.ListarAvionEquipaje();
            MostrarListaAvionEquipaje(aviones_equipajes);
        }

        private void CargarAviones()
        {
            aviones = navion.ListarAviones();
            cbCodigoAvion.DataSource = aviones;
            cbCodigoAvion.DisplayMember = "Modelo";
            cbCodigoAvion.ValueMember = "Codigo_Avion";
        }

        private void CargarEquipajes()
        {
            equipajes = nequipaje.ListarEquipajes();
            cbCodigoEquipaje.DataSource = equipajes;
            cbCodigoEquipaje.DisplayMember = "Nombre_Equipaje";
            cbCodigoEquipaje.ValueMember = "Codigo_Equipaje";


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCodigoAvion.Text == "" || cbCodigoEquipaje.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                Avion_Equipaje avionEquipaje = new Avion_Equipaje();
                avionEquipaje.Avion_Codigo = (int)cbCodigoAvion.SelectedValue;
                avionEquipaje.Equipaje_Codigo_Equipaje = (int)cbCodigoEquipaje.SelectedValue;

                string respuesta = navionequipaje.Insertar(avionEquipaje);
                MessageBox.Show(respuesta);
                MostrarAvionesEquipajes();
                LimpiarCampos();
            }
        }

        private void dataAvionEquipaje_SelectionChanged(object sender, EventArgs e)
        {
            if (dataAvionEquipaje.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataAvionEquipaje.SelectedRows[0];
                avionEquipajeIDSeleccionado = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                Avion_Equipaje avionEquipajeSeleccionado = aviones_equipajes.FirstOrDefault(v => v.Id == avionEquipajeIDSeleccionado);

                if (avionEquipajeSeleccionado != null)
                {
                    cbCodigoAvion.SelectedValue = avionEquipajeSeleccionado.Avion_Codigo;
                    cbCodigoEquipaje.SelectedValue = avionEquipajeSeleccionado.Equipaje_Codigo_Equipaje;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (avionEquipajeIDSeleccionado != 0)
            {
                Avion_Equipaje avionEquipajeModificado = new Avion_Equipaje
                {
                    Id = avionEquipajeIDSeleccionado,
                    Avion_Codigo = (int)cbCodigoAvion.SelectedValue,
                    Equipaje_Codigo_Equipaje = (int)cbCodigoEquipaje.SelectedValue
                };

                string respuesta = navionequipaje.Editar(avionEquipajeModificado);
                MessageBox.Show(respuesta);

                MostrarAvionesEquipajes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un avion-equipaje para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            cbCodigoAvion.SelectedIndex = -1;
            cbCodigoEquipaje.SelectedIndex = -1;

            avionEquipajeIDSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (avionEquipajeIDSeleccionado != 0)
            {
                Avion_Equipaje avionEquipajeAEliminar = new Avion_Equipaje
                {
                    Id = avionEquipajeIDSeleccionado
                };

                string respuesta = navionequipaje.Eliminar(avionEquipajeAEliminar);
                MessageBox.Show(respuesta);

                MostrarAvionesEquipajes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un avion-equipaje para eliminar.");
            }
        }
    }
}
