using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class dbEquipoRampa
    {
        public dbEquipoRampa()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<Equipo_ServicioRampa> ListarEquipoRampa()
        {
            List<Equipo_ServicioRampa> equipoRampa = new List<Equipo_ServicioRampa>();
            using (var db = new TalmaAerolineaEntities())
            {
                equipoRampa = db.Equipo_ServicioRampa
                    .Include("EmpleadoTalma")
                    .Include("ServiciosTalma_Vuelo").ToList();
            }
            return equipoRampa;
        }

        public string Insertar(Equipo_ServicioRampa equipoRampa)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Equipo_ServicioRampa.Add(equipoRampa);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Equipo de rampa registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el equipo de rampa: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(Equipo_ServicioRampa equipoRampa)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipoRampaExistente = db.Equipo_ServicioRampa.Find(equipoRampa.Codigo_EpServicio);
                        if (equipoRampaExistente != null)
                        {
                            equipoRampaExistente.Codigo_EpServicio = equipoRampa.Codigo_EpServicio;
                            equipoRampaExistente.EmpleadoTalma_Codigo = equipoRampa.EmpleadoTalma_Codigo;
                            equipoRampaExistente.Cantidad_Auxiliares = equipoRampa.Cantidad_Auxiliares;
                            equipoRampaExistente.Recursos_Empleados = equipoRampa.Recursos_Empleados;
                            equipoRampaExistente.Hora_Inicio_Servicio_Rampa = equipoRampa.Hora_Inicio_Servicio_Rampa;
                            equipoRampaExistente.Hora_Fin_Servicio_Rampa = equipoRampa.Hora_Fin_Servicio_Rampa;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipo de rampa actualizado correctamente";
                        }
                        return "Equipo de rampa no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el equipo de rampa: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(Equipo_ServicioRampa equipoRampa)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var equipoRampaExistente = db.Equipo_ServicioRampa.Find(equipoRampa.Codigo_EpServicio);
                        if (equipoRampaExistente != null)
                        {
                            db.Equipo_ServicioRampa.Remove(equipoRampaExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Equipo de rampa eliminado correctamente";
                        }
                        return "Equipo de rampa no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el equipo de rampa: {ex.Message}";
                    }
                }
            }
        }
    }
}
