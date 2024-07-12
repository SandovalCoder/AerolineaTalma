using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nPasajero
    {
        dbPasajero pasajero;

        public nPasajero()
        {
            pasajero = new dbPasajero();
        }

        public List<Pasajero> ListarPasajeros()
        {
            return pasajero.ListarPasajeros();
        }

        public string Insertar(Pasajero pasajero)
        {
            return this.pasajero.Insertar(pasajero);
        }

        public string Editar(Pasajero pasajero)
        {
            return this.pasajero.Editar(pasajero);
        }
        public string Eliminar(Pasajero pasajero)
        {
            return this.pasajero.Eliminar(pasajero);
        }
    }
}
