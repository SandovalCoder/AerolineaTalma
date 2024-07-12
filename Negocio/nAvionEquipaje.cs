using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nAvionEquipaje
    {
        Datos.dbAvionEquipaje dbavionequipaje;

        public nAvionEquipaje()
        {
            dbavionequipaje = new Datos.dbAvionEquipaje();
        }

        public List<Datos.Avion_Equipaje> ListarAvionEquipaje()
        {
            return dbavionequipaje.ListarAvionEquipaje();
        }

        public string Insertar(Datos.Avion_Equipaje avion_Equipaje)
        {
            return dbavionequipaje.Insertar(avion_Equipaje);
        }

        public string Editar(Datos.Avion_Equipaje avion_Equipaje)
        {
            return dbavionequipaje.Editar(avion_Equipaje);
        }

        public string Eliminar(Datos.Avion_Equipaje avion_Equipaje)
        {
            return dbavionequipaje.Eliminar(avion_Equipaje);
        }
    }
}
