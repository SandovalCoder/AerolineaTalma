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
    public partial class FrmReporte : Form
    {
        nReporteGestionVuelos reporteNegocio;
        public FrmReporte()
        {
            InitializeComponent();
            reporteNegocio = new nReporteGestionVuelos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            var reportes = reporteNegocio.GenerarReporteGestionVuelos();
            dataGridView1.DataSource = reportes.Select(r => new
            {
                r.Vuelo.Codigo_Vuelo,
                r.Vuelo.Identificador_Vuelo,
                r.Vuelo.Llegada_Vuelo,
                r.Vuelo.Salida_Vuelo,
                r.Vuelo.Estado,
                r.Avion.Codigo_Avion,
                r.Avion.Modelo,
                r.Avion.Longitud_Metros,
                r.Avion.Ancho_Metros,
                r.Avion.Capacidad,
                r.PuertaEmbarque.Nombre_Puerta,
                r.PuertaEmbarque.Ubicacion,
                r.PuertaEmbarque.Tipo
            }).ToList();
        }
    }
}
