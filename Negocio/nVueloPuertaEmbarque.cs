using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nVueloPuertaEmbarque
    {
        dbVueloPuertaEmbarque dbVueloPuerta;
        public nVueloPuertaEmbarque()
        {
            dbVueloPuerta = new dbVueloPuertaEmbarque();
        }

        public List<Vuelo_PuertaEmbarque> ListarVueloPuertaEmbarque()
        {
            return dbVueloPuerta.ListarVueloPuertaEmbarque();
        }
        public string Insertar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            return dbVueloPuerta.Insertar(vueloPuertaEmbarque);
        }
        public string Editar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            return dbVueloPuerta.Editar(vueloPuertaEmbarque);
        }

        public string Eliminar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            return dbVueloPuerta.Eliminar(vueloPuertaEmbarque);
        }
    }
}
