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
    public partial class FrmLogin : Form
    {
        nEmpleado emple;
        public FrmLogin()
        {
            InitializeComponent();
            emple = new nEmpleado();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = textUsuario1.Text;
            string contraseña = textContraseña1.Text;

            EmpleadoTalma empleado = emple.Login(usuario, contraseña);

            if (empleado != null)
            {
                this.Hide();
                if (emple.EsAdministrador(usuario))
                {
                    FrmPrincipal frmPrincipal = new FrmPrincipal(usuario, contraseña);
                    frmPrincipal.FormClosing += from_closing;
                    frmPrincipal.Show();
                }
                else if (emple.EsEmpleado(usuario))
                {
                    FrmPrincipalEmpleado frmPrincipalEmpleado = new FrmPrincipalEmpleado(usuario, contraseña);
                    frmPrincipalEmpleado.FormClosing += from_closing;
                    frmPrincipalEmpleado.Show();
                }
                else
                {
                    MessageBox.Show("No tiene permisos para ingresar al sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void from_closing(object sender, FormClosingEventArgs e)
        {
            textUsuario1.Text = "";
            textContraseña1.Text = "";
            this.Show();
        }
    }
}
