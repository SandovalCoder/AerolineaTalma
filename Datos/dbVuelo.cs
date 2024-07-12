using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class dbVuelo
    {
        public dbVuelo()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Vuelo> ListarVuelos()
        {
            List<Vuelo> vuelos = new List<Vuelo>();
            using (var db = new TalmaAerolineaEntities())
            {
                vuelos = db.Vuelo
                    .Include("Avion")
                    .Include("ServiciosTalma_Vuelo")
                    .Include("Vuelos_Pasajeros")
                    .Include("Vuelo_PuertaEmbarque").ToList();
            }
            return vuelos;
        }

        public string Insertar(Vuelo vuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Vuelo.Add(vuelo);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Vuelo registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el vuelo: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Vuelo vuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vueloExistente = db.Vuelo.Find(vuelo.Codigo_Vuelo);
                        if (vueloExistente != null)
                        {
                            vueloExistente.Codigo_Vuelo = vuelo.Codigo_Vuelo;
                            vueloExistente.Identificador_Vuelo = vuelo.Identificador_Vuelo;
                            vueloExistente.Avion_Codigo = vuelo.Avion_Codigo;
                            vueloExistente.Llegada_Vuelo = vuelo.Llegada_Vuelo;
                            vueloExistente.Salida_Vuelo = vuelo.Salida_Vuelo;
                            vueloExistente.Estado = vuelo.Estado;
                            vueloExistente.Origen = vuelo.Origen;
                            vueloExistente.Destino = vuelo.Destino;
                            vueloExistente.Cantidad_de_Equipaje = vuelo.Cantidad_de_Equipaje;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo actualizado correctamente";
                        }
                        return "Vuelo no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el vuelo: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Vuelo vuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vueloExistente = db.Vuelo.Find(vuelo.Codigo_Vuelo);
                        if (vueloExistente != null)
                        {
                            db.Vuelo.Remove(vueloExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo eliminado correctamente";
                        }
                        return "Vuelo no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el vuelo: {ex.Message}";
                    }

                }
            }
        }
    }
}