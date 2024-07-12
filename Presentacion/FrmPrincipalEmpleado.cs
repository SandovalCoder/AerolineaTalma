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

namespace Presentacion
{
    public partial class FrmPrincipalEmpleado : Form
    {
        private Form activeForm = null;
        private nEmpleado emple = new nEmpleado();
        private string usuario;
        private string contraseña;
        private bool esAdministrador;
        public FrmPrincipalEmpleado(string usuario, string contraseña)
        {
            InitializeComponent();
            IsMdiContainer = true;
            InitializeCustomComponents();

            this.usuario = usuario;
            this.contraseña = contraseña;
            this.esAdministrador = emple.EsAdministrador(usuario);
            ConfigurarMenu();

        }

        private void InitializeCustomComponents()
        {
            
            panelPrincipal.Visible = true;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(childForm);
            panelPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //Inicio
        private void iconMenultem1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            
            panelPrincipal.Visible = true;
        }

        private void ConfigurarMenu()
        {
            if (!esAdministrador)
            {
                empleadoToolStripMenuItem.Visible = false;
                equipServiciodeLimpiezaToolStripMenuItem.Visible = false;
                equipoServicioDeRampaToolStripMenuItem.Visible = false;
                avionToolStripMenuItem.Visible = false;
                vueloToolStripMenuItem.Visible = false;
                puertaEmbarqueToolStripMenuItem.Visible = false;
                vueloPuertaEmbarqueToolStripMenuItem.Visible = false;
                pasajeroToolStripMenuItem.Visible = false;
                equipajeToolStripMenuItem.Visible = false;
                vueloPasajerosToolStripMenuItem.Visible = false;
                avionEquipajeToolStripMenuItem.Visible = false;
                iconMenuItem3.Visible = false;
            }
        }

        //Empleado
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void equipServiciodeLimpiezaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void equipoServicioDeRampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        //Avion
        private void avionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void vueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        //Puerta de embarque
        private void puertaEmbarqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void vueloPuertaEmbarqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        //Pasajero
        private void pasajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void equipajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void vueloPasajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void avionEquipajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        //Servicio Talma Vuelo
        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        //Salir
        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        //Reportes
        private void gestionVuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporte frmReporte = new FrmReporte();
            openChildForm(frmReporte);
        }

        private void asignacionPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRAsignacionPersonal frmRAsignacionPersonal = new FrmRAsignacionPersonal();
            openChildForm(frmRAsignacionPersonal);
        }

        private void seguimientoDeEquipajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRSeguimiento frmRSeguimiento = new FrmRSeguimiento();
            openChildForm(frmRSeguimiento);
        }

        private void limpiezaDeCabinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRLimpiezaCabina frmRLimpiezaCabinas = new FrmRLimpiezaCabina();
            openChildForm(frmRLimpiezaCabinas);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //panelPrincipal
    }
}
