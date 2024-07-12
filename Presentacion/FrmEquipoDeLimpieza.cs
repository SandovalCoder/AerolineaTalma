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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Presentacion
{
    public partial class FrmEquipoDeLimpieza : Form
    {
        nEquipoLimpieza nequipoLimpieza;
        List<Equipo_ServicioLimpieza> equiposLimpieza;
        nEmpleado nEmpleado;
        List<EmpleadoTalma> empleados;
        private int equipoLimpiezaIdSeleccionado;

        public FrmEquipoDeLimpieza()
        {
            InitializeComponent();
            nequipoLimpieza = new nEquipoLimpieza();
            equiposLimpieza = new List<Equipo_ServicioLimpieza>();
            nEmpleado = new nEmpleado();
            empleados = new List<EmpleadoTalma>();
        }

        private void MostrarListaEquipoLimpieza(List<Equipo_ServicioLimpieza> lista)
        {
            dataEquipoLimpieza.Rows.Clear();
            foreach (Equipo_ServicioLimpieza equipoLimpieza in lista)
            {
                dataEquipoLimpieza.Rows.Add(
                    equipoLimpieza.Codigo_EpLimpienza,
                    equipoLimpieza.EmpleadoTalma_Codigo,
                    equipoLimpieza.Cantidad_Auxiliares,
                    equipoLimpieza.Recursos_Empleados,
                    equipoLimpieza.Tareas_Realizadas,
                    equipoLimpieza.Comentarios,
                    equipoLimpieza.Hora_Inicio_Servicio_Limpieza,
                    equipoLimpieza.Hora_Fin_Servicio_Limpieza
                );
            }
        }
        private void CrearColumnaEquipoLimpieza()
        {
            dataEquipoLimpieza.Columns.Clear();
            dataEquipoLimpieza.Columns.Add("Codigo_EpLimpienza", "Codigo_EpLimpienza");
            dataEquipoLimpieza.Columns.Add("EmpleadoTalma_Codigo", "EmpleadoTalma_Codigo");
            dataEquipoLimpieza.Columns.Add("Cantidad_Auxiliares", "Cantidad_Auxiliares");
            dataEquipoLimpieza.Columns.Add("Recursos_Empleados", "Recursos_Empleados");
            dataEquipoLimpieza.Columns.Add("Tareas_Realizadas", "Tareas_Realizadas");
            dataEquipoLimpieza.Columns.Add("Comentarios", "Comentarios");
            dataEquipoLimpieza.Columns.Add("Hora_Inicio_Servicio_Limpieza", "Hora_Inicio_Servicio_Limpieza");
            dataEquipoLimpieza.Columns.Add("Hora_Fin_Servicio_Limpieza", "Hora_Fin_Servicio_Limpieza");
        }

        private void FrmEquipoDeLimpieza_Load(object sender, EventArgs e)
        {
            CrearColumnaEquipoLimpieza();
            MostrarEquiposLimpieza();
            CaragarEmpleados();
        }

        private void MostrarEquiposLimpieza()
        {
            equiposLimpieza = nequipoLimpieza.ListarEquipoLimpieza();
            MostrarListaEquipoLimpieza(equiposLimpieza);
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
            if (cbCodigoEmpleado.Text == "" || textCantidad.Text == "" || textRecursos.Text == "" || textTareas.Text == "" || textComentario.Text == "")
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

                Equipo_ServicioLimpieza equipoLimpieza = new Equipo_ServicioLimpieza();
                equipoLimpieza.EmpleadoTalma_Codigo = (int)cbCodigoEmpleado.SelectedValue;
                equipoLimpieza.Cantidad_Auxiliares = cantidad; 
                equipoLimpieza.Recursos_Empleados = textRecursos.Text;
                equipoLimpieza.Tareas_Realizadas = textTareas.Text;
                equipoLimpieza.Comentarios = textComentario.Text;
                equipoLimpieza.Hora_Inicio_Servicio_Limpieza = TimeInicio.Value.TimeOfDay;
                equipoLimpieza.Hora_Fin_Servicio_Limpieza = TimeFin.Value.TimeOfDay;

                string respuesta = nequipoLimpieza.Insertar(equipoLimpieza);
                MessageBox.Show(respuesta);
                MostrarEquiposLimpieza();
                LimpiarCampos();
            }
        }

        private void dataEquipoLimpieza_SelectionChanged(object sender, EventArgs e)
        {
            if (dataEquipoLimpieza.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataEquipoLimpieza.SelectedRows[0];
                equipoLimpiezaIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_EpLimpienza"].Value);

                Equipo_ServicioLimpieza equipoLimpiezaSeleccionado = equiposLimpieza.FirstOrDefault(eq => eq.Codigo_EpLimpienza == equipoLimpiezaIdSeleccionado);

                if (equipoLimpiezaSeleccionado != null)
                {
                    cbCodigoEmpleado.SelectedValue = equipoLimpiezaSeleccionado.EmpleadoTalma_Codigo;
                    textCantidad.Text = equipoLimpiezaSeleccionado.Cantidad_Auxiliares.ToString();
                    textRecursos.Text = equipoLimpiezaSeleccionado.Recursos_Empleados;
                    textTareas.Text = equipoLimpiezaSeleccionado.Tareas_Realizadas;
                    textComentario.Text = equipoLimpiezaSeleccionado.Comentarios;
                    TimeInicio.Value = DateTime.Today.Add(equipoLimpiezaSeleccionado.Hora_Inicio_Servicio_Limpieza);
                    TimeFin.Value = DateTime.Today.Add(equipoLimpiezaSeleccionado.Hora_Fin_Servicio_Limpieza);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (equipoLimpiezaIdSeleccionado != 0)
            {
                Equipo_ServicioLimpieza equipoLimpiezaModificado = new Equipo_ServicioLimpieza
                {
                    Codigo_EpLimpienza = equipoLimpiezaIdSeleccionado,
                    EmpleadoTalma_Codigo = (int)cbCodigoEmpleado.SelectedValue,
                    Cantidad_Auxiliares = Convert.ToInt32(textCantidad.Text),
                    Recursos_Empleados = textRecursos.Text,
                    Tareas_Realizadas = textTareas.Text,
                    Comentarios = textComentario.Text,
                    Hora_Inicio_Servicio_Limpieza = TimeInicio.Value.TimeOfDay,
                    Hora_Fin_Servicio_Limpieza = TimeFin.Value.TimeOfDay
                };

                string respuesta = nequipoLimpieza.Editar(equipoLimpiezaModificado);
                MessageBox.Show(respuesta);

                MostrarEquiposLimpieza();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo de limpieza para modificar.");
            }

        }

        private void LimpiarCampos()
        {
            cbCodigoEmpleado.SelectedIndex = -1;
            textCantidad.Text = "";
            textRecursos.Text = "";
            textTareas.Text = "";
            textComentario.Text = "";
            TimeInicio.Value = DateTime.Today;
            TimeFin.Value = DateTime.Today;

            equipoLimpiezaIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (equipoLimpiezaIdSeleccionado != 0)
            {
                Equipo_ServicioLimpieza equipoLimpiezaAEliminar = new Equipo_ServicioLimpieza
                {
                    Codigo_EpLimpienza = equipoLimpiezaIdSeleccionado
                };

                string respuesta = nequipoLimpieza.Eliminar(equipoLimpiezaAEliminar);
                MessageBox.Show(respuesta);

                MostrarEquiposLimpieza();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo de limpieza para eliminar.");
            }
        }
    }
}
