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
    public partial class FrmEmpleado : Form
    {
        nEmpleado NEmpl;
        List<EmpleadoTalma> emplea;
        private int empleadoIdSeleccionado;

        public FrmEmpleado()
        {
            InitializeComponent();
            NEmpl = new nEmpleado();
            emplea = new List<EmpleadoTalma>();
        }

        private void MostrarListaEmpleado(List<EmpleadoTalma> lista)
        {
            dataEmpleado.Rows.Clear();
            foreach (EmpleadoTalma empleado in lista)
            {
                dataEmpleado.Rows.Add(
                    empleado.Codigo_Empleado,
                    empleado.Nombre,
                    empleado.DNI,
                    empleado.Usuario,
                    empleado.Contrasena,
                    empleado.Rango,
                    empleado.Rol,
                    empleado.Hora_Inicio_Labores,
                    empleado.Hora_Fin_Labores
                );
            }
        }
        private void CrearColumnaEmpleado()
        {
            dataEmpleado.Columns.Clear();
            dataEmpleado.Columns.Add("Codigo_Empleado", "Codigo_Empleado");
            dataEmpleado.Columns.Add("Nombre", "Nombre");
            dataEmpleado.Columns.Add("DNI", "DNI");
            dataEmpleado.Columns.Add("Usuario", "Usuario");
            dataEmpleado.Columns.Add("Contrasena", "Contrasena");
            dataEmpleado.Columns.Add("Rango", "Rango");
            dataEmpleado.Columns.Add("Rol", "Rol");
            dataEmpleado.Columns.Add("Hora_Inicio_Labores", "Hora_Inicio_Labores");
            dataEmpleado.Columns.Add("Hora_Fin_Labores", "Hora_Fin_Labores");
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CrearColumnaEmpleado();
            MostrarEmpleados();
            LimpiarCampos();
        }

        private void MostrarEmpleados()
        {
            emplea = NEmpl.ListarEmpleados();
            MostrarListaEmpleado(emplea);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "" || textDNI.Text == "" || textUsuario.Text == "" || textContraseña.Text == "" || cbRango.Text == "" || cbRol.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                if (!int.TryParse(textDNI.Text, out int dni) || dni <= 0)
                {
                    MessageBox.Show("El DNI debe ser tener 8 digitos.");
                    return;
                }

                EmpleadoTalma empleado = new EmpleadoTalma();
                empleado.Nombre = textNombre.Text;
                empleado.DNI = dni;
                empleado.Usuario = textUsuario.Text;
                empleado.Contrasena = textContraseña.Text;
                empleado.Rango = cbRango.Text;
                empleado.Rol = cbRol.Text;
                empleado.Hora_Inicio_Labores = dateTimeInicio.Value.TimeOfDay;
                empleado.Hora_Fin_Labores = dateTimeFinal.Value.TimeOfDay;

                string respuesta = NEmpl.Insertar(empleado);
                MessageBox.Show(respuesta);
                MostrarEmpleados();
                LimpiarCampos();
            }
        }
        private void dataEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            if (dataEmpleado.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataEmpleado.SelectedRows[0];
                empleadoIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Empleado"].Value);

                
                EmpleadoTalma empleadoSeleccionado = emplea.FirstOrDefault(emp => emp.Codigo_Empleado == empleadoIdSeleccionado);

                if (empleadoSeleccionado != null)
                {
                    textNombre.Text = empleadoSeleccionado.Nombre;
                    textDNI.Text = empleadoSeleccionado.DNI.ToString();
                    textUsuario.Text = empleadoSeleccionado.Usuario;
                    textContraseña.Text = empleadoSeleccionado.Contrasena;
                    cbRango.Text = empleadoSeleccionado.Rango;
                    cbRol.Text = empleadoSeleccionado.Rol;
                    dateTimeInicio.Value = DateTime.Today.Add(empleadoSeleccionado.Hora_Inicio_Labores);
                    dateTimeFinal.Value = DateTime.Today.Add(empleadoSeleccionado.Hora_Fin_Labores);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (empleadoIdSeleccionado != 0)
            {
                EmpleadoTalma empleadoModificado = new EmpleadoTalma
                {
                    Codigo_Empleado = empleadoIdSeleccionado,
                    Nombre = textNombre.Text,
                    DNI = Convert.ToInt32(textDNI.Text),
                    Usuario = textUsuario.Text,
                    Contrasena = textContraseña.Text,
                    Rango = cbRango.Text,
                    Rol = cbRol.Text,
                    Hora_Inicio_Labores = dateTimeInicio.Value.TimeOfDay,
                    Hora_Fin_Labores = dateTimeFinal.Value.TimeOfDay
                };

                string respuesta = NEmpl.Editar(empleadoModificado);
                MessageBox.Show(respuesta);

                MostrarEmpleados();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para modificar.");
            }
        }
        private void LimpiarCampos()
        {
            textNombre.Text = "";
            textDNI.Text = "";
            textUsuario.Text = "";
            textContraseña.Text = "";
            cbRango.SelectedIndex = -1;
            cbRol.SelectedIndex = -1;
            dateTimeInicio.Value = DateTime.Now;
            dateTimeFinal.Value = DateTime.Now;

            empleadoIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (empleadoIdSeleccionado != 0)
            {
               
                EmpleadoTalma empleadoAEliminar = new EmpleadoTalma
                {
                    Codigo_Empleado = empleadoIdSeleccionado
                };

                
                string respuesta = NEmpl.Eliminar(empleadoAEliminar);
                MessageBox.Show(respuesta);
               
                MostrarEmpleados();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.");
            }
        }

        private void btnServicioLimpieza_Click(object sender, EventArgs e)
        { 
            FrmEquipoDeLimpieza frmEquipoDeLimpieza = new FrmEquipoDeLimpieza();
            frmEquipoDeLimpieza.ShowDialog();
        }

        private void btnServicioRampa_Click(object sender, EventArgs e)
        {
            FrmEquipoDeRampa frmEquipoDeRampa = new FrmEquipoDeRampa();
            frmEquipoDeRampa.ShowDialog();
        }
    }
}
