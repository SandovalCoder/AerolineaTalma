using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbVueloPasajero
    {
        public dbVueloPasajero()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Vuelos_Pasajeros> ListarVuelosPasajeros()
        {
            List<Vuelos_Pasajeros> vuelosPasajeros = new List<Vuelos_Pasajeros>();
            using (var db = new TalmaAerolineaEntities())
            {
                vuelosPasajeros = db.Vuelos_Pasajeros
                    .Include("Vuelo")
                    .Include("Pasajero").ToList();
            }
            return vuelosPasajeros;
        }

        public string Insertar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Vuelos_Pasajeros.Add(vuelos_Pasajero);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Vuelo-Pasajero registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el Vuelo-Pasajero: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vuelos_PasajeroExistente = db.Vuelos_Pasajeros.Find(vuelos_Pasajero.Id);
                        if (vuelos_PasajeroExistente != null)
                        {
                            vuelos_PasajeroExistente.Id = vuelos_Pasajero.Id;
                            vuelos_PasajeroExistente.Vuelo_Codigo_Vuelo = vuelos_Pasajero.Vuelo_Codigo_Vuelo;
                            vuelos_PasajeroExistente.Pasajero_Codigo_Usuario = vuelos_Pasajero.Pasajero_Codigo_Usuario;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo-Pasajero actualizado correctamente";
                        }
                        return "Vuelo-Pasajero no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el Vuelo-Pasajero: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Vuelos_Pasajeros vuelos_Pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var vuelos_PasajeroExistente = db.Vuelos_Pasajeros.Find(vuelos_Pasajero.Id);
                        if (vuelos_PasajeroExistente != null)
                        {
                            db.Vuelos_Pasajeros.Remove(vuelos_PasajeroExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Vuelo-Pasajero eliminado correctamente";
                        }
                        return "Vuelo-Pasajero no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el Vuelo-Pasajero: {ex.Message}";
                    }
                }
            }
        }
    }
}