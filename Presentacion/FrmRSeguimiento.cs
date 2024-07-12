using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FrmRSeguimiento : Form
    {
        nReporteSeguimientoYGestionDeEquipaje nreporteSeguimientoYGestionDeEquipaje;

        public FrmRSeguimiento()
        {
            InitializeComponent();
            nreporteSeguimientoYGestionDeEquipaje = new nReporteSeguimientoYGestionDeEquipaje();
        }

        private void FrmRSeguimiento_Load(object sender, EventArgs e)
        {
            var reportes = nreporteSeguimientoYGestionDeEquipaje.ReporteSeguimientoYGestionDeEquipaje();
            dataRSeguimiento.DataSource = reportes.Select(r => new
            {
                PasajeroCodigo = r.Pasajero.Codigo_Pasajero,
                PasajeroNombre = r.Pasajero.Nombre_Completo,
                VueloCodigo = r.Vuelo.Codigo_Vuelo,
                VueloIdentificador = r.Vuelo.Identificador_Vuelo,
                VueloDestino = r.Vuelo.Destino,
                EquipajeCodigo = r.Equipaje.Codigo_Equipaje,
                EquipajeNombre = r.Equipaje.Nombre_Equipaje,
                EquipajeEstado = r.Equipaje.Estado_Equipaje,
                EquipajePeso = r.Equipaje.Peso,
                EquipajeBodegaAsignada = r.Equipaje.Bodega_Asignada_en_Aeronave
            }).ToList();
        }
    }
}
