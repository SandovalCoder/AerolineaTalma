using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nAvion
    {
        dbAvion avion;

        public nAvion()
        {
            avion = new dbAvion();
        }

        public List<Avion> ListarAviones()
        {
            return avion.ListarAviones();
        }

        public string Insertar(Avion avion)
        {
            return this.avion.Insertar(avion);
        }

        public string Editar(Avion avion)
        {
            return this.avion.Editar(avion);
        }

        public string Eliminar(Avion avion)
        {
            return this.avion.Eliminar(avion);
        }

    }
}
