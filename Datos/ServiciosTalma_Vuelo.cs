//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiciosTalma_Vuelo
    {
        public int Codigo_Servicio { get; set; }
        public int Equipo_ServicioRampa_Codigo { get; set; }
        public int Equipo_ServicioLimpieza_Codigo { get; set; }
        public int Vuelo_Codigo_Vuelo { get; set; }
    
        public virtual Equipo_ServicioLimpieza Equipo_ServicioLimpieza { get; set; }
        public virtual Equipo_ServicioRampa Equipo_ServicioRampa { get; set; }
        public virtual Vuelo Vuelo { get; set; }
    }
}
