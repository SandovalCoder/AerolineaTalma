using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbAvionEquipaje
    {
        public dbAvionEquipaje()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Avion_Equipaje> ListarAvionEquipaje()
        {
            List<Avion_Equipaje> avionEquipajes = new List<Avion_Equipaje>();
            using (var db = new TalmaAerolineaEntities())
            {
                avionEquipajes = db.Avion_Equipaje
                    .Include("Avion")
                    .Include("Equipaje").ToList();
            }
            return avionEquipajes;
        }

        public string Insertar(Avion_Equipaje avion_Equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Avion_Equipaje.Add(avion_Equipaje);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Avion-Equipaje registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar Avion-Equipaje: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Avion_Equipaje avion_Equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var avion_EquipajeExistente = db.Avion_Equipaje.Find(avion_Equipaje.Id);
                        if (avion_EquipajeExistente != null)
                        {
                            avion_EquipajeExistente.Id = avion_Equipaje.Id;
                            avion_EquipajeExistente.Avion_Codigo = avion_Equipaje.Avion_Codigo;
                            avion_EquipajeExistente.Equipaje_Codigo_Equipaje = avion_Equipaje.Equipaje_Codigo_Equipaje;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Avion-Equipaje actualizado correctamente";
                        }
                        return "Avion-Equipaje no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar Avion-Equipaje: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Avion_Equipaje avion_Equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var avion_EquipajeExistente = db.Avion_Equipaje.Find(avion_Equipaje.Id);
                        if (avion_EquipajeExistente != null)
                        {
                            db.Avion_Equipaje.Remove(avion_EquipajeExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Avion-Equipaje eliminado correctamente";
                        }
                        return "Avion-Equipaje no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar Avion-Equipaje: {ex.Message}";
                    }
                }
            }
        }
    }
}