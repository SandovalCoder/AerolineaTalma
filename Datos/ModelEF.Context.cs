﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TalmaAerolineaEntities : DbContext
    {
        public TalmaAerolineaEntities()
            : base("name=TalmaAerolineaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Avion> Avion { get; set; }
        public virtual DbSet<Avion_Equipaje> Avion_Equipaje { get; set; }
        public virtual DbSet<EmpleadoTalma> EmpleadoTalma { get; set; }
        public virtual DbSet<Equipaje> Equipaje { get; set; }
        public virtual DbSet<Equipo_ServicioLimpieza> Equipo_ServicioLimpieza { get; set; }
        public virtual DbSet<Equipo_ServicioRampa> Equipo_ServicioRampa { get; set; }
        public virtual DbSet<Pasajero> Pasajero { get; set; }
        public virtual DbSet<PuertaEmbarque> PuertaEmbarque { get; set; }
        public virtual DbSet<ServiciosTalma_Vuelo> ServiciosTalma_Vuelo { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }
        public virtual DbSet<Vuelo_PuertaEmbarque> Vuelo_PuertaEmbarque { get; set; }
        public virtual DbSet<Vuelos_Pasajeros> Vuelos_Pasajeros { get; set; }
    }
}
