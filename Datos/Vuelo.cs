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
    
    public partial class Vuelo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vuelo()
        {
            this.ServiciosTalma_Vuelo = new HashSet<ServiciosTalma_Vuelo>();
            this.Vuelos_Pasajeros = new HashSet<Vuelos_Pasajeros>();
            this.Vuelo_PuertaEmbarque = new HashSet<Vuelo_PuertaEmbarque>();
        }
    
        public int Codigo_Vuelo { get; set; }
        public string Identificador_Vuelo { get; set; }
        public int Avion_Codigo { get; set; }
        public System.DateTime Llegada_Vuelo { get; set; }
        public System.DateTime Salida_Vuelo { get; set; }
        public string Estado { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Cantidad_de_Equipaje { get; set; }
    
        public virtual Avion Avion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiciosTalma_Vuelo> ServiciosTalma_Vuelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelos_Pasajeros> Vuelos_Pasajeros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelo_PuertaEmbarque> Vuelo_PuertaEmbarque { get; set; }
    }
}
