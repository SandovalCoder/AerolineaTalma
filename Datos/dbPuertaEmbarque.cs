using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbPuertaEmbarque
    {
        public dbPuertaEmbarque()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<PuertaEmbarque> ListarPuertasEmbarque()
        {
            List<PuertaEmbarque> puertasEmbarques = new List<PuertaEmbarque>();
            using (var db = new TalmaAerolineaEntities())
            {
                puertasEmbarques = db.PuertaEmbarque
                    .Include("Vuelo_PuertaEmbarque")
                    .ToList();
            }
            return puertasEmbarques;
        }

        public string Insertar(PuertaEmbarque puertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.PuertaEmbarque.Add(puertaEmbarque);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Puerta de embarque registrada correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar la puerta de embarque: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(PuertaEmbarque puertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var puertaEmbarqueExistente = db.PuertaEmbarque.Find(puertaEmbarque.Codigo_Puerta);
                        if (puertaEmbarqueExistente != null)
                        {
                            puertaEmbarqueExistente.Codigo_Puerta = puertaEmbarque.Codigo_Puerta;
                            puertaEmbarqueExistente.Nombre_Puerta = puertaEmbarque.Nombre_Puerta;
                            puertaEmbarqueExistente.Ubicacion = puertaEmbarque.Ubicacion;
                            puertaEmbarqueExistente.Tipo = puertaEmbarque.Tipo;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Puerta de embarque actualizada correctamente";
                        }
                        return "Puerta de embarque no encontrada";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar la puerta de embarque: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(PuertaEmbarque puertaEmbarque)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var puertaEmbarqueExistente = db.PuertaEmbarque.Find(puertaEmbarque.Codigo_Puerta);
                        if (puertaEmbarqueExistente != null)
                        {
                            db.PuertaEmbarque.Remove(puertaEmbarqueExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Puerta de embarque eliminada correctamente";
                        }
                        return "Puerta de embarque no encontrada";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar la puerta de embarque: {ex.Message}";
                    }
                }
            }
        }
    }
}