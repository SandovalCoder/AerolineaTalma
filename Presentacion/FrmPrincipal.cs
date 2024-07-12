using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private Form activeForm = null;
        private nEmpleado emple = new nEmpleado();

        public FrmPrincipal(string usuario, string contraseña)
        {
            InitializeComponent();
            IsMdiContainer = true;
            InitializeCustomComponents();
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

        //Empleado
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado();
            openChildForm(frmEmpleado);
        }

        private void equipServiciodeLimpiezaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipoDeLimpieza frmEquipoDeLimpieza = new FrmEquipoDeLimpieza();
            openChildForm(frmEquipoDeLimpieza);
        }

        private void equipoServicioDeRampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipoDeRampa frmEquipoDeRampa = new FrmEquipoDeRampa();
            openChildForm(frmEquipoDeRampa);
        }

        //Avion
        private void avionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmAvion frmAvion = new FrmAvion();
            openChildForm(frmAvion);
        }

        private void vueloToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmVuelo frmVuelo = new FrmVuelo();
            openChildForm(frmVuelo);
        }

        //Puerta de embarque
        private void puertaEmbarqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuertaEmbarque frmPuertaEmbarque = new FrmPuertaEmbarque();
            openChildForm(frmPuertaEmbarque);
        }

        private void vueloPuertaEmbarqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVueloPuertoEmbarque frmVueloPuertoEmbarque = new FrmVueloPuertoEmbarque();
            openChildForm(frmVueloPuertoEmbarque);
        }

        //Pasajero
        private void pasajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPasajero frmPasajero = new FrmPasajero();
            openChildForm(frmPasajero);
        }

        private void equipajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquipaje frmEquipaje = new FrmEquipaje();
            openChildForm(frmEquipaje);
        }

        private void vueloPasajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmVueloPasajero frmVueloPasajero = new FrmVueloPasajero();
            openChildForm(frmVueloPasajero);
        }

        private void avionEquipajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAvionEquipaje frmAvionEquipaje = new FrmAvionEquipaje();
            openChildForm(frmAvionEquipaje);
        }

        //Servicio Talma Vuelo
        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            FrmServicioTalmaVuelo frmServicioTalmaVuelo = new FrmServicioTalmaVuelo();
            openChildForm(frmServicioTalmaVuelo);
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


    }
}
