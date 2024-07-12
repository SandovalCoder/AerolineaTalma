using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nReporteLimpienzaDeCabinas
    {
        dbEquipoLimpieza dbequipoLimpieza;
        dbVuelo dbvuelo;
        dbServicioTalmaVuelo dbservicioTalmaVuelo;

        public nReporteLimpienzaDeCabinas()
        {
            dbequipoLimpieza = new dbEquipoLimpieza();
            dbvuelo = new dbVuelo();
            dbservicioTalmaVuelo = new dbServicioTalmaVuelo();
        }

        public List<Equipo_ServicioLimpieza> equipo_ServicioLimpiezas()
        {
            return dbequipoLimpieza.ListarEquipoLimpieza();
        }

        public List<Vuelo> vuelos()
        {
            return dbvuelo.ListarVuelos();
        }

        public List<ServiciosTalma_Vuelo> serviciosTalma_Vuelos()
        {
            return dbservicioTalmaVuelo.ListarServicioTalmaVuelo();
        }

        public List<ReporteLimpienzaDeCabinas> GenerarReporteLimpienzaDeCabinas()
        {
            var vuelos = this.vuelos();
            var equiposLimpieza = this.equipo_ServicioLimpiezas();
            var serviciosTalmaVuelos = this.serviciosTalma_Vuelos();

            var reporte = from servicio in serviciosTalmaVuelos
                          join vuelo in vuelos
                          on servicio.Vuelo_Codigo_Vuelo equals vuelo.Codigo_Vuelo
                          join equipoLimpieza in equiposLimpieza
                          on servicio.Equipo_ServicioLimpieza_Codigo equals equipoLimpieza.Codigo_EpLimpienza
                          select new ReporteLimpienzaDeCabinas
                          {
                              Vuelo = vuelo,
                              Equipo_ServicioLimpieza = equipoLimpieza
                          };

            return reporte.ToList();
        }
    }
}
