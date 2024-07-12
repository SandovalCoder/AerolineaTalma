using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nReporteAsignacionDePersonalyRecursos
    {
        dbVuelo dbavion;
        dbEquipoRampa dbequipoRampa;
        dbEquipoLimpieza dbequipoLimpieza;

        public nReporteAsignacionDePersonalyRecursos()
        {
            dbavion = new dbVuelo();
            dbequipoRampa = new dbEquipoRampa();
            dbequipoLimpieza = new dbEquipoLimpieza();
        }

        //Lista Vuelo, Equipos de Rampa y Equipos de Limpieza

        public List<Vuelo> ListarVuelos()
        {
            return dbavion.ListarVuelos();
        }

        public List<Equipo_ServicioRampa> ListarEquiposRampa()
        {
            return dbequipoRampa.ListarEquipoRampa();
        }

        public List<Equipo_ServicioLimpieza> ListarEquiposLimpieza()
        {
            return dbequipoLimpieza.ListarEquipoLimpieza();
        }


        public List<ReporteAsignacionDePersonalyRecursos> GenerarReporteAsignacionDePersonalyRecursos()
        {

            var vuelos = ListarVuelos();
            var equiposRampa = ListarEquiposRampa();
            var equiposLimpieza = ListarEquiposLimpieza();

            var reporte = from vuelo in vuelos
                          join equipoRampa in equiposRampa
                          on vuelo.Codigo_Vuelo equals equipoRampa.Codigo_EpServicio 
                          join equipoLimpieza in equiposLimpieza
                          on vuelo.Codigo_Vuelo equals equipoLimpieza.Codigo_EpLimpienza 
                          select new ReporteAsignacionDePersonalyRecursos
                          {
                              Vuelo = vuelo,
                              Equipo_ServicioRampa = equipoRampa,
                              Equipo_ServicioLimpieza = equipoLimpieza
                          };

            return reporte.ToList();
        }
    }

}

