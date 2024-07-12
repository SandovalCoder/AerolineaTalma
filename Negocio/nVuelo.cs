using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nVuelo
    {
        dbVuelo dbvu;

        public nVuelo()
        {
            dbvu = new dbVuelo();
        }

        public List<Vuelo> ListarVuelos()
        {
            return dbvu.ListarVuelos();
        }

        public string Insertar(Vuelo vuelo)
        {
            return dbvu.Insertar(vuelo);
        }

        public string Editar(Vuelo vuelo)
        {
            return dbvu.Editar(vuelo);
        }
        public string Eliminar(Vuelo vuelo)
        {
            return dbvu.Eliminar(vuelo);
        }
    }
}
