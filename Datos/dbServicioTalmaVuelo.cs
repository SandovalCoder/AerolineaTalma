using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbServicioTalmaVuelo
    {
        public dbServicioTalmaVuelo()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<ServiciosTalma_Vuelo> ListarServicioTalmaVuelo()
        {
            List<ServiciosTalma_Vuelo> servicioTalmaVuelos = new List<ServiciosTalma_Vuelo>();
            using (var db = new TalmaAerolineaEntities())
            {
                servicioTalmaVuelos = db.ServiciosTalma_Vuelo
                    .Include("Equipo_ServicioRampa")
                    .Include("Equipo_ServicioLimpieza")
                    .Include("Vuelo").ToList();
            }
            return servicioTalmaVuelos;
        }

        public string Insertar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ServiciosTalma_Vuelo.Add(servicioTalmaVuelo);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Servicio Talma Vuelo registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al registrar el servicio Talma Vuelo: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var servicioTalmaVueloExistente = db.ServiciosTalma_Vuelo.Find(servicioTalmaVuelo.Codigo_Servicio);
                        if (servicioTalmaVueloExistente != null)
                        {
                            servicioTalmaVueloExistente.Codigo_Servicio = servicioTalmaVuelo.Codigo_Servicio;
                            servicioTalmaVueloExistente.Equipo_ServicioRampa_Codigo = servicioTalmaVuelo.Equipo_ServicioRampa_Codigo;
                            servicioTalmaVueloExistente.Equipo_ServicioLimpieza_Codigo = servicioTalmaVuelo.Equipo_ServicioLimpieza_Codigo;
                            servicioTalmaVueloExistente.Vuelo_Codigo_Vuelo = servicioTalmaVuelo.Vuelo_Codigo_Vuelo;

                            db.SaveChanges();
                            transaction.Commit();
                            return "Servicio Talma Vuelo actualizado correctamente";
                        }
                        return "Servicio Talma Vuelo no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al actualizar el servicio Talma Vuelo: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(ServiciosTalma_Vuelo servicioTalmaVuelo)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var servicioTalmaVueloExistente = db.ServiciosTalma_Vuelo.Find(servicioTalmaVuelo.Codigo_Servicio);
                        if (servicioTalmaVueloExistente != null)
                        {
                            db.ServiciosTalma_Vuelo.Remove(servicioTalmaVueloExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Servicio Talma Vuelo eliminado correctamente";
                        }
                        return "Servicio Talma Vuelo no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error al eliminar el servicio Talma Vuelo: {ex.Message}";
                    }
                }
            }
        }
    }
}