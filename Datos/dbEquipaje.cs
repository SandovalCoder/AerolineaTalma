using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbEquipaje
    {
        public dbEquipaje()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Equipaje> ListarEquipajes()
        {
            List<Equipaje> equipajes = new List<Equipaje>();
            using (var db = new TalmaAerolineaEntities())
            {
                equipajes = db.Equipaje
                    .Include("Pasajero")
                    .Include("Avion_Equipaje").ToList();
            }
            return equipajes;
        }

        public string Insertar(Equipaje equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Equipaje.Add(equipaje);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Equipaje registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el equipaje: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Equipaje equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipajeExistente = db.Equipaje.Find(equipaje.Codigo_Equipaje);
                        if (equipajeExistente != null)
                        {
                            equipajeExistente.Codigo_Equipaje = equipaje.Codigo_Equipaje;
                            equipajeExistente.Nombre_Equipaje = equipaje.Nombre_Equipaje;
                            equipajeExistente.Bodega_Asignada_en_Aeronave = equipaje.Bodega_Asignada_en_Aeronave;
                            equipajeExistente.Estado_Equipaje = equipaje.Estado_Equipaje;
                            equipajeExistente.Peso = equipaje.Peso;
                            equipajeExistente.Destino = equipaje.Destino;
                            equipajeExistente.Pasajero_Codigo = equipaje.Pasajero_Codigo;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipaje actualizado correctamente";
                        }
                        return "Equipaje no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el equipaje: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Equipaje equipaje)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipajeExistente = db.Equipaje.Find(equipaje.Codigo_Equipaje);
                        if (equipajeExistente != null)
                        {
                            db.Equipaje.Remove(equipajeExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipaje eliminado correctamente";
                        }
                        return "Equipaje no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el equipaje: {ex.Message}";
                    }
                }
            }
        }
    }
}