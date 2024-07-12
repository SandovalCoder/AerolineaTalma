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
    public partial class FrmPasajero : Form
    {
        nPasajero npasajero;
        List<Pasajero> pasajeros;
        private int pasajeroIdSeleccionado;

        public FrmPasajero()
        {
            InitializeComponent();
            npasajero = new nPasajero();
            pasajeros = new List<Pasajero>();
        }

        private void MostrarListaPasajero(List<Pasajero> lista)
        {
            dataPasajero.Rows.Clear();
            foreach (Pasajero pasajero in lista)
            {
                dataPasajero.Rows.Add(
                    pasajero.Codigo_Pasajero,
                    pasajero.DNI,
                    pasajero.Nombre_Completo
                );
            }
        }

        private void CrearColumnaPasajero()
        {
            dataPasajero.Columns.Clear();
            dataPasajero.Columns.Add("Codigo_Pasajero", "Codigo_Pasajero");
            dataPasajero.Columns.Add("DNI", "DNI");
            dataPasajero.Columns.Add("Nombre_Completo", "Nombre_Completo");
        }

        private void FrmPasajero_Load(object sender, EventArgs e)
        {
            CrearColumnaPasajero();
            MostrarPasajeros();
            LimpiarCampos();
        }

        private void MostrarPasajeros()
        {
            pasajeros = npasajero.ListarPasajeros();
            MostrarListaPasajero(pasajeros);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(textDNI.Text == "" || textNombre.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                Pasajero pasajero = new Pasajero();
                pasajero.DNI = textDNI.Text;
                pasajero.Nombre_Completo = textNombre.Text;

                string respuesta = npasajero.Insertar(pasajero);
                MessageBox.Show(respuesta);
                MostrarPasajeros();
                LimpiarCampos();
            }
        }

        private void dataPasajero_SelectionChanged(object sender, EventArgs e)
        {
            if (dataPasajero.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataPasajero.SelectedRows[0];
                pasajeroIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Pasajero"].Value);

                Pasajero pasajeroSeleccionado = pasajeros.FirstOrDefault(pas => pas.Codigo_Pasajero == pasajeroIdSeleccionado);

                if (pasajeroSeleccionado != null)
                {
                    textDNI.Text = pasajeroSeleccionado.DNI;
                    textNombre.Text = pasajeroSeleccionado.Nombre_Completo;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (pasajeroIdSeleccionado != 0)
            {
                Pasajero pasajeroModificado = new Pasajero
                {
                    Codigo_Pasajero = pasajeroIdSeleccionado,
                    DNI = textDNI.Text,
                    Nombre_Completo = textNombre.Text
                };

                string respuesta = npasajero.Editar(pasajeroModificado);
                MessageBox.Show(respuesta);

                MostrarPasajeros();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pasajero para modificar.");
            }
        }

        private void LimpiarCampos()
        {
            textDNI.Text = "";
            textNombre.Text = "";

            pasajeroIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (pasajeroIdSeleccionado != 0)
            {
                Pasajero pasajeroAEliminar = new Pasajero
                {
                    Codigo_Pasajero = pasajeroIdSeleccionado
                };

                string respuesta = npasajero.Eliminar(pasajeroAEliminar);
                MessageBox.Show(respuesta);

                MostrarPasajeros();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pasajero para eliminar.");
            }
        }

        private void btnVueloPasajero_Click(object sender, EventArgs e)
        {
            FrmVueloPasajero frmVueloPasajero = new FrmVueloPasajero();
            frmVueloPasajero.Show();
        }

        private void btnEquipaje_Click(object sender, EventArgs e)
        {
            FrmEquipaje frmEquipaje = new FrmEquipaje();
            frmEquipaje.Show();
        }
    }
}
