using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nReporteSeguimientoYGestionDeEquipaje
    {
        dbPasajero dbpasajero;
        dbVuelo dbvuelo;
        dbEquipaje dbequipaje;
        public nReporteSeguimientoYGestionDeEquipaje()
        {
            dbpasajero = new dbPasajero();
            dbvuelo = new dbVuelo();
            dbequipaje = new dbEquipaje();
        }

        public List<Pasajero> getPasajeroList()
        {
               return dbpasajero.ListarPasajeros();
        }

        public List<Vuelo> getVueloList()
        {
            return dbvuelo.ListarVuelos();
        }

        public List<Equipaje> getEquipajeList()
        {
            return dbequipaje.ListarEquipajes();
        }

        public List<ReporteSeguimientoYGestionDeEquipaje> ReporteSeguimientoYGestionDeEquipaje()
        {
            var pasajeros = getPasajeroList();
            var vuelos = getVueloList();
            var equipajes = getEquipajeList();

            var reporte = from equipaje in equipajes
                          join pasajero in pasajeros
                          on equipaje.Pasajero_Codigo equals pasajero.Codigo_Pasajero
                          join vuelo in vuelos
                          on equipaje.Destino equals vuelo.Destino
                          select new ReporteSeguimientoYGestionDeEquipaje
                          {
                              Pasajero = pasajero,
                              Vuelo = vuelo,
                              Equipaje = equipaje
                          };

            return reporte.ToList();
        }


    }
}
