using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nEquipoLimpieza
    {
        dbEquipoLimpieza dblimpieza;

        public nEquipoLimpieza()
        {
            dblimpieza = new dbEquipoLimpieza();
        }

        public List<Equipo_ServicioLimpieza> ListarEquipoLimpieza()
        {
            return dblimpieza.ListarEquipoLimpieza();
        }

        public string Insertar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            return this.dblimpieza.Insertar(equipoLimpieza);
        }

        public string Editar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            return this.dblimpieza.Editar(equipoLimpieza);
        }

        public string Eliminar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            return this.dblimpieza.Eliminar(equipoLimpieza);
        }

    }
}
