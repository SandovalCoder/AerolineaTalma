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
    
    public partial class Equipaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipaje()
        {
            this.Avion_Equipaje = new HashSet<Avion_Equipaje>();
        }
    
        public int Codigo_Equipaje { get; set; }
        public string Nombre_Equipaje { get; set; }
        public string Bodega_Asignada_en_Aeronave { get; set; }
        public string Estado_Equipaje { get; set; }
        public string Peso { get; set; }
        public string Destino { get; set; }
        public int Pasajero_Codigo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avion_Equipaje> Avion_Equipaje { get; set; }
        public virtual Pasajero Pasajero { get; set; }
    }
}
