using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nPuertaEmbarque
    {
        dbPuertaEmbarque dbPuertaEm;
        public nPuertaEmbarque()
        {
            dbPuertaEm = new dbPuertaEmbarque();
        }

        public List<PuertaEmbarque> ListarPuertasEmbarque()
        {
            return dbPuertaEm.ListarPuertasEmbarque();
        }

        public string Insertar(PuertaEmbarque puertaEmbarque)
        {
            return dbPuertaEm.Insertar(puertaEmbarque);
        }

        public string Editar(PuertaEmbarque puertaEmbarque)
        {
            return dbPuertaEm.Editar(puertaEmbarque);
        }

        public string Eliminar(PuertaEmbarque puertaEmbarque)
        {
            return dbPuertaEm.Eliminar(puertaEmbarque);
        }
    }
}
