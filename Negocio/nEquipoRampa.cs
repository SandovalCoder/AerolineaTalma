using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nEquipoRampa
    {
        dbEquipoRampa dbrampa;

        public nEquipoRampa()
        {
            dbrampa = new dbEquipoRampa();
        }

        public List<Equipo_ServicioRampa> ListarEquipoRampa()
        {
            return dbrampa.ListarEquipoRampa();
        }

        public string Insertar(Equipo_ServicioRampa equipoRampa)
        {
            return this.dbrampa.Insertar(equipoRampa);
        }

        public string Editar(Equipo_ServicioRampa equipoRampa)
        {
            return this.dbrampa.Editar(equipoRampa);
        }

        public string Eliminar(Equipo_ServicioRampa equipoRampa)
        {
            return this.dbrampa.Eliminar(equipoRampa);
        }
    }
}
