using System;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }
        public DbSet<FamiliarDesignado> Familiar { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<SignoVital> Signos { get; set; }
        public DbSet<SugerenciaCuidado> Sugerencias { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaData44");
            }
        }
    }
}
