using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbAvion
    {
        public dbAvion()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Avion> ListarAviones()
        {
            List<Avion> aviones = new List<Avion>();
            using (var db = new TalmaAerolineaEntities())
            {
                aviones = db.Avion
                    .Include("Avion_Equipaje")
                    .Include("Vuelo").ToList();
            }
            return aviones;
        }

        public string Insertar(Avion avion)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Avion.Add(avion);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Avion registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar avion: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Avion avion)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var avionExistente = db.Avion.Find(avion.Codigo_Avion);
                        if (avionExistente != null)
                        {
                            avionExistente.Codigo_Avion = avion.Codigo_Avion;
                            avionExistente.Modelo = avion.Modelo;
                            avionExistente.Longitud_Metros = avion.Longitud_Metros;
                            avionExistente.Ancho_Metros = avion.Ancho_Metros;
                            avionExistente.Capacidad = avion.Capacidad;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Avion actualizado correctamente";
                        }
                        return "Avion no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar avion: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Avion avion)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var avionExistente = db.Avion.Find(avion.Codigo_Avion);
                        if (avionExistente != null)
                        {
                            db.Avion.Remove(avionExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Avion eliminado correctamente";
                        }
                        return "Avion no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"No puedes eliminar, porque tiene asignaciones. Elimina las asignaciones y vuelve a intentarlo: {ex.Message}";
                    }
                }
            }
        }
    }
}
