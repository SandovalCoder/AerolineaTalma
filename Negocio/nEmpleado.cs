using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class nEmpleado
    {
        dbEmpleado emple;

        public nEmpleado()
        {
            emple = new dbEmpleado();
        }

        public List<EmpleadoTalma> ListarEmpleados()
        {
            return emple.ListarEmpleados();
        }

        public EmpleadoTalma Login(string usuario, string contraseña)
        {
            return emple.Login(usuario, contraseña);
        }

        public bool EsAdministrador(string usuario)
        {
            return emple.EsAdministrador(usuario);
        }

        public bool EsEmpleado(string usuario)
        {
            return emple.EsEmpleado(usuario);
        }

        public bool ExisteDni(int dni)
        {
            return emple.ExisteDni(dni);
        }

        public string Insertar(EmpleadoTalma empleado)
        {
            return emple.Insertar(empleado);
        }

        public string Editar(EmpleadoTalma empleado)
        {
            return emple.Editar(empleado);
        }
        public string Eliminar(EmpleadoTalma empleado)
        {
            return emple.Eliminar(empleado);
        }
    }
}
