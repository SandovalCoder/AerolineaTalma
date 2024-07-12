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
    public partial class FrmRAsignacionPersonal : Form
    {
        nReporteAsignacionDePersonalyRecursos nreporteAsignacionDePersonalyRecursos;

        public FrmRAsignacionPersonal()
        {
            InitializeComponent();
            nreporteAsignacionDePersonalyRecursos = new nReporteAsignacionDePersonalyRecursos();
        }

        private void FrmRAsignacionPersonal_Load(object sender, EventArgs e)
        {
            var reportes = nreporteAsignacionDePersonalyRecursos.GenerarReporteAsignacionDePersonalyRecursos();
            dataRAsignacion.DataSource = reportes.Select(r => new
            {
                Vuelo_Codigo = r.Vuelo.Codigo_Vuelo,
                Vuelo_Identificador = r.Vuelo.Identificador_Vuelo,
                Vuelo_Llegada = r.Vuelo.Llegada_Vuelo,
                Vuelo_Salida = r.Vuelo.Salida_Vuelo,
                Vuelo_Estado = r.Vuelo.Estado,
                Rampa_Codigo_Servicio = r.Equipo_ServicioRampa.Codigo_EpServicio,
                Rampa_Empleado_Codigo = r.Equipo_ServicioRampa.EmpleadoTalma_Codigo,
                Rampa_Cantidad_Auxiliares = r.Equipo_ServicioRampa.Cantidad_Auxiliares,
                Rampa_Recursos_Empleados = r.Equipo_ServicioRampa.Recursos_Empleados,
                Limpieza_Codigo_Servicio = r.Equipo_ServicioLimpieza.Codigo_EpLimpienza,
                Limpieza_Empleado_Codigo = r.Equipo_ServicioLimpieza.EmpleadoTalma_Codigo,
                Limpieza_Cantidad_Auxiliares = r.Equipo_ServicioLimpieza.Cantidad_Auxiliares,
                Limpieza_Recursos_Empleados = r.Equipo_ServicioLimpieza.Recursos_Empleados
            }).ToList();
        }
    }
}
