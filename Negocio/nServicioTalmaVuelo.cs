using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nServicioTalmaVuelo
    {
        dbServicioTalmaVuelo dbserviciotalmavuelo;

        public nServicioTalmaVuelo()
        {
            dbserviciotalmavuelo = new dbServicioTalmaVuelo();
        }

        public List<ServiciosTalma_Vuelo> ListarServicioTalmaVuelo()
        {
            return dbserviciotalmavuelo.ListarServicioTalmaVuelo();
        }

        public string Insertar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            return dbserviciotalmavuelo.Insertar(servicioTalmaVuelo);
        }

        public string Editar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            return dbserviciotalmavuelo.Editar(servicioTalmaVuelo);
        }

        public string Eliminar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            return dbserviciotalmavuelo.Eliminar(servicioTalmaVuelo);
        }
        
    }
}
