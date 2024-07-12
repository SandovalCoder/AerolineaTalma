using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbVueloPuertaEmbarque
    {
        public dbVueloPuertaEmbarque()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Vuelo_PuertaEmbarque> ListarVueloPuertaEmbarque()
        {
            List<Vuelo_PuertaEmbarque> vueloPuertaEmbarques = new List<Vuelo_PuertaEmbarque>();
            using (var db = new TalmaAerolineaEntities())
            {
                vueloPuertaEmbarques = db.Vuelo_PuertaEmbarque
                    .Include("Vuelo")
                    .Include("PuertaEmbarque").ToList();
            }
            return vueloPuertaEmbarques;
        }

        public string Insertar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Vuelo_PuertaEmbarque.Add(vueloPuertaEmbarque);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Vuelo-Puerta de embarque registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el Vuelo-Puerta de embarque: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vueloPuertaEmbarqueExistente = db.Vuelo_PuertaEmbarque.Find(vueloPuertaEmbarque.Id);
                        if (vueloPuertaEmbarqueExistente != null)
                        {
                            vueloPuertaEmbarqueExistente.Id = vueloPuertaEmbarque.Id;
                            vueloPuertaEmbarqueExistente.Vuelo_Codigo_Vuelo = vueloPuertaEmbarque.Vuelo_Codigo_Vuelo;
                            vueloPuertaEmbarqueExistente.PuertaEmbarque_Codigo = vueloPuertaEmbarque.PuertaEmbarque_Codigo;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo-Puerta de embarque actualizado correctamente";
                        }
                        return "Vuelo-Puerta de embarque no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el Vuelo-Puerta de embarque: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Vuelo_PuertaEmbarque vueloPuertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vueloPuertaEmbarqueExistente = db.Vuelo_PuertaEmbarque.Find(vueloPuertaEmbarque.Id);
                        if (vueloPuertaEmbarqueExistente != null)
                        {
                            db.Vuelo_PuertaEmbarque.Remove(vueloPuertaEmbarqueExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo-Puerta de embarque eliminado correctamente";
                        }
                        return "Vuelo-Puerta de embarque no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el Vuelo-Puerta de embarque: {ex.Message}";
                    }
                }
            }
        }
    }
}
