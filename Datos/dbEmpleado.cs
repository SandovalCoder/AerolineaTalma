using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dbEmpleado
    {
        public dbEmpleado()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public List<EmpleadoTalma> ListarEmpleados()
        {
            List<EmpleadoTalma> empleados = new List<EmpleadoTalma>();
            using (var db = new TalmaAerolineaEntities())
            {
                empleados = db.EmpleadoTalma
                    .Include("Equipo_ServicioLimpieza")
                    .Include("Equipo_ServicioRampa").ToList();
            }
            return empleados;
        }

        public EmpleadoTalma Login(string usuario, string contraseña)
        {
            using (var context = new TalmaAerolineaEntities())
            {
                return context.EmpleadoTalma.FirstOrDefault(e => e.Usuario == usuario && e.Contrasena == contraseña);
            }
        }

        public bool EsAdministrador(string usuario)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                var empleado = db.EmpleadoTalma.FirstOrDefault(e => e.Usuario == usuario);
                return empleado != null && string.Equals(empleado.Rol.Trim(), "Administrador", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool EsEmpleado(string usuario)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                var empleado = db.EmpleadoTalma.FirstOrDefault(e => e.Usuario == usuario);
                return empleado != null && string.Equals(empleado.Rol.Trim(), "Empleado", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool ExisteDni(int dni)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                return db.EmpleadoTalma.Any(e => e.DNI == dni);
            }
        }

        public string Insertar(EmpleadoTalma empleado)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.EmpleadoTalma.Add(empleado);
                        db.SaveChanges();
                        transaction.Commit();
                        return "Empleado registrado correctamente";
                    }
                    catch (DbEntityValidationException ex)
                    {
                        transaction.Rollback();
                        return "Error al registrar el empleado. Verifique los datos e intente nuevamente.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error inesperado al registrar el empleado: {ex.Message}";
                    }
                }
            }
        }

        public string Editar(EmpleadoTalma empleado)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var empleadoExistente = db.EmpleadoTalma.Find(empleado.Codigo_Empleado);
                        if (empleadoExistente != null)
                        {
                           
                            empleadoExistente.Nombre = empleado.Nombre;
                            empleadoExistente.DNI = empleado.DNI;
                            empleadoExistente.Usuario = empleado.Usuario;
                            empleadoExistente.Contrasena = empleado.Contrasena;
                            empleadoExistente.Rango = empleado.Rango;
                            empleadoExistente.Rol = empleado.Rol;
                            empleadoExistente.Hora_Inicio_Labores = empleado.Hora_Inicio_Labores;
                            empleadoExistente.Hora_Fin_Labores = empleado.Hora_Fin_Labores;

                            
                            var validationErrors = db.GetValidationErrors();
                            if (validationErrors.Any())
                            {
                                
                                transaction.Rollback();
                                var errorMessage = string.Join("; ", validationErrors.SelectMany(e => e.ValidationErrors).Select(v => $"{v.PropertyName}: {v.ErrorMessage}"));
                                return $"Error de validación al actualizar el empleado: {errorMessage}";
                            }

                            db.SaveChanges();
                            transaction.Commit();
                            return "Empleado actualizado correctamente";
                        }
                        return "Empleado no encontrado";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error inesperado al actualizar el empleado: {ex.Message}";
                    }
                }
            }
        }

        public string Eliminar(EmpleadoTalma empleado)
        {
            using (var db = new TalmaAerolineaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var empleadoExistente = db.EmpleadoTalma.Find(empleado.Codigo_Empleado);
                        if (empleadoExistente != null)
                        {
                            db.EmpleadoTalma.Remove(empleadoExistente);
                            db.SaveChanges();
                            transaction.Commit();
                            return "Empleado eliminado correctamente";
                        }
                        return "Empleado no encontrado";
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