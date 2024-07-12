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
    public partial class FrmEquipaje : Form
    {
        nEquipaje nequipaje;
        List<Equipaje> equipajes;
        private int equipajeIdSeleccionado;
        nPasajero npasajero;
        List<Pasajero> pasajeros;

        public FrmEquipaje()
        {
            InitializeComponent();
            nequipaje = new nEquipaje();
            equipajes = new List<Equipaje>();
            npasajero = new nPasajero();
            pasajeros = new List<Pasajero>();
        }

        private void MostrarListaEquipaje(List<Equipaje> lista)
        {
            dataEquipaje.Rows.Clear();
            foreach (Equipaje equipaje in lista)
            {
                dataEquipaje.Rows.Add(
                    equipaje.Codigo_Equipaje,
                    equipaje.Nombre_Equipaje,
                    equipaje.Bodega_Asignada_en_Aeronave,
                    equipaje.Estado_Equipaje,
                    equipaje.Peso,
                    equipaje.Destino,
                    equipaje.Pasajero_Codigo
                );
            }
        }

        private void CrearColumnaEquipaje()
        {
            dataEquipaje.Columns.Clear();
            dataEquipaje.Columns.Add("Codigo_Equipaje", "Codigo_Equipaje");
            dataEquipaje.Columns.Add("Nombre_Equipaje", "Nombre_Equipaje");
            dataEquipaje.Columns.Add("Bodega_Asignada_en_Aeronave", "Bodega_Asignada_en_Aeronave");
            dataEquipaje.Columns.Add("Estado_Equipaje", "Estado_Equipaje");
            dataEquipaje.Columns.Add("Peso", "Peso");
            dataEquipaje.Columns.Add("Destino", "Destino");
            dataEquipaje.Columns.Add("Pasajero_Codigo", "Pasajero_Codigo");
        }

        private void FrmEquipaje_Load(object sender, EventArgs e)
        {
            CrearColumnaEquipaje();
            MostrarEquipajes();
            LimpiarCampos();
            CargarPasajeros();
        }

        private void MostrarEquipajes()
        {
            equipajes = nequipaje.ListarEquipajes();
            MostrarListaEquipaje(equipajes);
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
            if (textNombreEquipaje.Text =="" || textBodega.Text == "" || cbEstado.Text == "" || textPeso.Text == "" || textDestino.Text == "" || cbCodigoPasajero.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                Equipaje equipaje = new Equipaje();
                equipaje.Nombre_Equipaje = textNombreEquipaje.Text;
                equipaje.Bodega_Asignada_en_Aeronave = textBodega.Text;
                equipaje.Estado_Equipaje = cbEstado.Text;
                equipaje.Peso = textPeso.Text;
                equipaje.Destino = textDestino.Text;
                equipaje.Pasajero_Codigo = (int)cbCodigoPasajero.SelectedValue;

                string respuesta = nequipaje.Insertar(equipaje);
                MessageBox.Show(respuesta);
                MostrarEquipajes();
                LimpiarCampos();
            }
        }

        private void dataEquipaje_SelectionChanged(object sender, EventArgs e)
        {
            if (dataEquipaje.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataEquipaje.SelectedRows[0];
                equipajeIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Equipaje"].Value);

                Equipaje equipajeSeleccionado = equipajes.FirstOrDefault(eq => eq.Codigo_Equipaje == equipajeIdSeleccionado);

                if (equipajeSeleccionado != null)
                {
                    textNombreEquipaje.Text = equipajeSeleccionado.Nombre_Equipaje;
                    textBodega.Text = equipajeSeleccionado.Bodega_Asignada_en_Aeronave;
                    cbEstado.Text = equipajeSeleccionado.Estado_Equipaje;
                    textPeso.Text = equipajeSeleccionado.Peso;
                    textDestino.Text = equipajeSeleccionado.Destino;
                    cbCodigoPasajero.SelectedValue = equipajeSeleccionado.Pasajero_Codigo;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (equipajeIdSeleccionado != 0)
            {
                Equipaje equipajeModificado = new Equipaje
                {
                    Codigo_Equipaje = equipajeIdSeleccionado,
                    Nombre_Equipaje = textNombreEquipaje.Text,
                    Bodega_Asignada_en_Aeronave = textBodega.Text,
                    Estado_Equipaje = cbEstado.Text,
                    Peso = textPeso.Text,
                    Destino = textDestino.Text,
                    Pasajero_Codigo = (int)cbCodigoPasajero.SelectedValue
                };

                string respuesta = nequipaje.Editar(equipajeModificado);
                MessageBox.Show(respuesta);

                MostrarEquipajes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipaje para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            textNombreEquipaje.Text = "";
            textBodega.Text = "";
            cbEstado.SelectedIndex = -1;
            textPeso.Text = "";
            textDestino.Text = "";
            cbCodigoPasajero.SelectedIndex = -1;

            equipajeIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (equipajeIdSeleccionado != 0)
            {
                Equipaje equipajeAEliminar = new Equipaje
                {
                    Codigo_Equipaje = equipajeIdSeleccionado
                };

                string respuesta = nequipaje.Eliminar(equipajeAEliminar);
                MessageBox.Show(respuesta);

                MostrarEquipajes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipaje para eliminar.");
            }
        }

        private void btnAvionEquipaje_Click(object sender, EventArgs e)
        { 
            FrmAvionEquipaje frmAvionEquipaje = new FrmAvionEquipaje();
            frmAvionEquipaje.Show();
        }
    }
}
