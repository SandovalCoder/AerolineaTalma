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
    public partial class FrmRLimpiezaCabina : Form
    {
        nReporteLimpienzaDeCabinas nreporteLimpienzaDeCabinas;
        public FrmRLimpiezaCabina()
        {
            InitializeComponent();
            nreporteLimpienzaDeCabinas = new nReporteLimpienzaDeCabinas();
        }

        private void FrmRLimpiezaCabina_Load(object sender, EventArgs e)
        {
            var reportes = nreporteLimpienzaDeCabinas.GenerarReporteLimpienzaDeCabinas();
            dataRLimpieza.DataSource = reportes.Select(r => new
            {
                VueloCodigo = r.Vuelo.Codigo_Vuelo,
                VueloIdentificador = r.Vuelo.Identificador_Vuelo,
                VueloLlegada = r.Vuelo.Llegada_Vuelo,
                VueloSalida = r.Vuelo.Salida_Vuelo,
                VueloEstado = r.Vuelo.Estado,
                VueloOrigen = r.Vuelo.Origen,
                VueloDestino = r.Vuelo.Destino,
                EquipoLimpiezaCodigo = r.Equipo_ServicioLimpieza.Codigo_EpLimpienza,
                EmpleadoTalmaCodigo = r.Equipo_ServicioLimpieza.EmpleadoTalma_Codigo,
                CantidadAuxiliares = r.Equipo_ServicioLimpieza.Cantidad_Auxiliares,
                RecursosEmpleados = r.Equipo_ServicioLimpieza.Recursos_Empleados,
                TareasRealizadas = r.Equipo_ServicioLimpieza.Tareas_Realizadas,
                Comentarios = r.Equipo_ServicioLimpieza.Comentarios,
                HoraInicio = r.Equipo_ServicioLimpieza.Hora_Inicio_Servicio_Limpieza,
                HoraFin = r.Equipo_ServicioLimpieza.Hora_Fin_Servicio_Limpieza
            }).ToList();
        }
    }
}
