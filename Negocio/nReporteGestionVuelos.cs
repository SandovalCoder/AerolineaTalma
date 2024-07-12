using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nReporteGestionVuelos
    {
        dbAvion dbavion;
        dbVuelo dbvuelo;
        dbPuertaEmbarque dbpuertaembarque;

        public nReporteGestionVuelos()
        {
            dbavion = new dbAvion();
            dbvuelo = new dbVuelo();
            dbpuertaembarque = new dbPuertaEmbarque();
        }

        public List<Avion> ListarAviones()
        {
            return dbavion.ListarAviones();
        }

        public List<Vuelo> ListarVuelos()
        {
            return dbvuelo.ListarVuelos();
        }

        public List<PuertaEmbarque> ListarPuertasEmbarque()
        {
            return dbpuertaembarque.ListarPuertasEmbarque();
        }

        public List<ReporteGestionVuelos> GenerarReporteGestionVuelos()
        {
            List<Vuelo> vuelos = ListarVuelos();
            List<Avion> aviones = ListarAviones();
            List<PuertaEmbarque> puertas = ListarPuertasEmbarque();

            var reporte = (from vuelo in vuelos
                           join avion in aviones on vuelo.Avion_Codigo equals avion.Codigo_Avion
                           join puerta in puertas on vuelo.Codigo_Vuelo equals puerta.Codigo_Puerta 
                           select new ReporteGestionVuelos
                           {
                               Vuelo = vuelo,
                               Avion = avion,
                               PuertaEmbarque = puerta
                           }).ToList();

              return reporte;
        }
    }
}
