using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbEquipoLimpieza
    {
        public dbEquipoLimpieza()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Equipo_ServicioLimpieza> ListarEquipoLimpieza()
        {
            List<Equipo_ServicioLimpieza> equipoLimpieza = new List<Equipo_ServicioLimpieza>();
            using (var db = new TalmaAerolineaEntities())
            {
                equipoLimpieza = db.Equipo_ServicioLimpieza
                    .Include("EmpleadoTalma")
                    .Include("ServiciosTalma_Vuelo").ToList();
            }
            return equipoLimpieza;
        }

        public string Insertar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Equipo_ServicioLimpieza.Add(equipoLimpieza);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Equipo de limpieza registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el equipo de limpieza: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipoLimpiezaExistente = db.Equipo_ServicioLimpieza.Find(equipoLimpieza.Codigo_EpLimpienza);
                        if (equipoLimpiezaExistente != null)
                        {
                            equipoLimpiezaExistente.Codigo_EpLimpienza = equipoLimpieza.Codigo_EpLimpienza;
                            equipoLimpiezaExistente.EmpleadoTalma_Codigo = equipoLimpieza.EmpleadoTalma_Codigo;
                            equipoLimpiezaExistente.Cantidad_Auxiliares = equipoLimpieza.Cantidad_Auxiliares;
                            equipoLimpiezaExistente.Recursos_Empleados = equipoLimpieza.Recursos_Empleados;
                            equipoLimpiezaExistente.Tareas_Realizadas = equipoLimpieza.Tareas_Realizadas;
                            equipoLimpiezaExistente.Comentarios = equipoLimpieza.Comentarios;
                            equipoLimpiezaExistente.Hora_Inicio_Servicio_Limpieza = equipoLimpieza.Hora_Inicio_Servicio_Limpieza;
                            equipoLimpiezaExistente.Hora_Fin_Servicio_Limpieza = equipoLimpieza.Hora_Fin_Servicio_Limpieza;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipo de limpieza actualizado correctamente";
                        }
                        return "Equipo de limpieza no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el equipo de limpieza: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Equipo_ServicioLimpieza equipoLimpieza)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipoLimpiezaExistente = db.Equipo_ServicioLimpieza.Find(equipoLimpieza.Codigo_EpLimpienza);
                        if (equipoLimpiezaExistente != null)
                        {
                            db.Equipo_ServicioLimpieza.Remove(equipoLimpiezaExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipo de limpieza eliminado correctamente";
                        }
                        return "Equipo de limpieza no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el equipo de limpieza: {ex.Message}";
                    }
                }
            }
        }
    }
}