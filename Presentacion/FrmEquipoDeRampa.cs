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
    public partial class FrmEquipoDeRampa : Form
    {
        nEquipoRampa nequipoRampa;
        List<Equipo_ServicioRampa> equiposRampa;
        nEmpleado nEmpleado;
        List<EmpleadoTalma> empleados;
        private int equipoRampaIdSeleccionado;

        public FrmEquipoDeRampa()
        {
            InitializeComponent();
            nequipoRampa = new nEquipoRampa();
            equiposRampa = new List<Equipo_ServicioRampa>();
            nEmpleado = new nEmpleado();
            empleados = new List<EmpleadoTalma>();
        }

        private void MostrarListaEquipoRampa(List<Equipo_ServicioRampa> lista)
        {
            dataEquipoRampa.Rows.Clear();
            foreach (Equipo_ServicioRampa equipoRampa in lista)
            {
                dataEquipoRampa.Rows.Add(
                    equipoRampa.Codigo_EpServicio,
                    equipoRampa.EmpleadoTalma_Codigo,
                    equipoRampa.Cantidad_Auxiliares,
                    equipoRampa.Recursos_Empleados,
                    equipoRampa.Hora_Inicio_Servicio_Rampa,
                    equipoRampa.Hora_Fin_Servicio_Rampa

                );
            }
        }
        private void CrearColumnaEquipoRampa()
        {
            dataEquipoRampa.Columns.Clear();
            dataEquipoRampa.Columns.Add("Codigo_EpServicio", "Codigo_EpServicio");
            dataEquipoRampa.Columns.Add("EmpleadoTalma_Codigo", "EmpleadoTalma_Codigo");
            dataEquipoRampa.Columns.Add("Cantidad_Auxiliares", "Cantidad_Auxiliares");
            dataEquipoRampa.Columns.Add("Recursos_Empleados", "Recursos_Empleados");
            dataEquipoRampa.Columns.Add("Hora_Inicio_Servicio_Rampa", "Hora_Inicio_Servicio_Rampa");
            dataEquipoRampa.Columns.Add("Hora_Fin_Servicio_Rampa", "Hora_Fin_Servicio_Rampa");
        }

        private void FrmEquipoDeRampa_Load(object sender, EventArgs e)
        {
            CrearColumnaEquipoRampa();
            MostrarEquiposRampa();
            CaragarEmpleados();
        }

        private void MostrarEquiposRampa()
        {
            equiposRampa = nequipoRampa.ListarEquipoRampa();
            MostrarListaEquipoRampa(equiposRampa);
        }
        private void CaragarEmpleados()
        {
            empleados = nEmpleado.ListarEmpleados();
            cbCodigoEmpleado.DataSource = empleados;
            cbCodigoEmpleado.DisplayMember = "Nombre";
            cbCodigoEmpleado.ValueMember = "Codigo_Empleado";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCodigoEmpleado.Text == "" || textCantidad.Text == "" || textRecuro.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                int cantidad;
                if (!int.TryParse(textCantidad.Text, out cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero.");
                    return; 
                }

                Equipo_ServicioRampa equipoRampa = new Equipo_ServicioRampa();
                equipoRampa.EmpleadoTalma_Codigo = (int)cbCodigoEmpleado.SelectedValue;
                equipoRampa.Cantidad_Auxiliares = cantidad; 
                equipoRampa.Recursos_Empleados = textRecuro.Text;
                equipoRampa.Hora_Inicio_Servicio_Rampa = dateTimeInicio.Value.TimeOfDay;
                equipoRampa.Hora_Fin_Servicio_Rampa = dateTimeFin.Value.TimeOfDay;

                string respuesta = nequipoRampa.Insertar(equipoRampa);
                MessageBox.Show(respuesta);
                MostrarEquiposRampa();
                LimpiarCampos();
            }

        }

        private void dataEquipoRampa_SelectionChanged(object sender, EventArgs e)
        {
            if (dataEquipoRampa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataEquipoRampa.SelectedRows[0];
                equipoRampaIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_EpServicio"].Value);

                Equipo_ServicioRampa equipoRampaSeleccionado = equiposRampa.FirstOrDefault(eq => eq.Codigo_EpServicio == equipoRampaIdSeleccionado);

                if (equipoRampaSeleccionado != null)
                {
                    cbCodigoEmpleado.SelectedValue = equipoRampaSeleccionado.EmpleadoTalma_Codigo;
                    textCantidad.Text = equipoRampaSeleccionado.Cantidad_Auxiliares.ToString();
                    textRecuro.Text = equipoRampaSeleccionado.Recursos_Empleados;
                    dateTimeInicio.Value = DateTime.Today.Add(equipoRampaSeleccionado.Hora_Inicio_Servicio_Rampa);
                    dateTimeFin.Value = DateTime.Today.Add(equipoRampaSeleccionado.Hora_Fin_Servicio_Rampa);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (equipoRampaIdSeleccionado != 0)
            {
                Equipo_ServicioRampa equipoRampaModificado = new Equipo_ServicioRampa
                {
                    Codigo_EpServicio = equipoRampaIdSeleccionado,
                    EmpleadoTalma_Codigo = (int)cbCodigoEmpleado.SelectedValue,
                    Cantidad_Auxiliares = Convert.ToInt32(textCantidad.Text),
                    Recursos_Empleados = textRecuro.Text,
                    Hora_Inicio_Servicio_Rampa = dateTimeInicio.Value.TimeOfDay,
                    Hora_Fin_Servicio_Rampa = dateTimeFin.Value.TimeOfDay
                };

                string respuesta = nequipoRampa.Editar(equipoRampaModificado);
                MessageBox.Show(respuesta);

                MostrarEquiposRampa();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo de rampa para modificar.");
            }

        }

        private void LimpiarCampos()
        {
            cbCodigoEmpleado.SelectedIndex = -1;
            textCantidad.Text = "";
            textRecuro.Text = "";
            dateTimeInicio.Value = DateTime.Now;
            dateTimeFin.Value = DateTime.Now;

            equipoRampaIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (equipoRampaIdSeleccionado != 0)
            {
                Equipo_ServicioRampa equipoRampaAEliminar = new Equipo_ServicioRampa
                {
                    Codigo_EpServicio = equipoRampaIdSeleccionado
                };

                string respuesta = nequipoRampa.Eliminar(equipoRampaAEliminar);
                MessageBox.Show(respuesta);

                MostrarEquiposRampa();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo de rampa para eliminar.");
            }
        }
    }
}
