using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbPasajero
    {
        public dbPasajero()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Pasajero> ListarPasajeros()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();
            using (var db = new TalmaAerolineaEntities())
            {
                pasajeros = db.Pasajero
                    .Include("Equipaje")
                    .Include("Vuelos_Pasajeros").ToList();
            }
            return pasajeros;
        }

        public string Insertar(Pasajero pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Pasajero.Add(pasajero);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Pasajero registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el pasajero: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Pasajero pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var pasajeroExistente = db.Pasajero.Find(pasajero.Codigo_Pasajero);
                        if (pasajeroExistente != null)
                        {
                            pasajeroExistente.Codigo_Pasajero = pasajero.Codigo_Pasajero;
                            pasajeroExistente.DNI = pasajero.DNI;
                            pasajeroExistente.Nombre_Completo = pasajero.Nombre_Completo;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Pasajero actualizado correctamente";
                        }
                        return "Pasajero no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el pasajero: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Pasajero pasajero)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var pasajeroExistente = db.Pasajero.Find(pasajero.Codigo_Pasajero);
                        if (pasajeroExistente != null)
                        {
                            db.Pasajero.Remove(pasajeroExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Pasajero eliminado correctamente";
                        }
                        return "Pasajero no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el pasajero: {ex.Message}";
                    }
                }
            }
        }

    }
}
