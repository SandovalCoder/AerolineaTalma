using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nVueloPasajero
    {
        dbVueloPasajero dbvuelopasajero;

        public nVueloPasajero()
        {
            dbvuelopasajero = new dbVueloPasajero();
        }

        public List<Vuelos_Pasajeros> ListarVuelosPasajeros()
        {
            return dbvuelopasajero.ListarVuelosPasajeros();
        }

        public string Insertar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            return dbvuelopasajero.Insertar(vuelos_Pasajero);
        }

        public string Editar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            return dbvuelopasajero.Editar(vuelos_Pasajero);
        }

        public string Eliminar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            return dbvuelopasajero.Eliminar(vuelos_Pasajero);
        }
    }
}
