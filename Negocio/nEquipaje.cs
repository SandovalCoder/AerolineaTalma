using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nEquipaje
    {
        dbEquipaje equipaje;

        public nEquipaje()
        {
            equipaje = new dbEquipaje();
        }

        public List<Equipaje> ListarEquipajes()
        {
            return equipaje.ListarEquipajes();
        }

        public string Insertar(Equipaje equipaje)
        {
            return this.equipaje.Insertar(equipaje);
        }

        public string Editar(Equipaje equipaje)
        {
            return this.equipaje.Editar(equipaje);
        }

        public string Eliminar(Equipaje equipaje)
        {
            return this.equipaje.Eliminar(equipaje);
        }
    }
}
