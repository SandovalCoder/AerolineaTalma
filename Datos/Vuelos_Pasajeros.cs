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
    
    public partial class Vuelos_Pasajeros
    {
        public int Id { get; set; }
        public int Vuelo_Codigo_Vuelo { get; set; }
        public int Pasajero_Codigo_Usuario { get; set; }
    
        public virtual Pasajero Pasajero { get; set; }
        public virtual Vuelo Vuelo { get; set; }
    }
}
