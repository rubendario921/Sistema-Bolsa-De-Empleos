using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using selecciontalento_api.Models;

namespace selecciontalento_api.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Roles> Roles { get; set; }
        //Empresas
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Industrias> Industrias { get; set; }
        public DbSet<CantidadEmpleados> CantidadEmpleados { get; set; }
        public DbSet<OfertaEmpleos> OfertaEmpleos { get; set; }
        public DbSet<Modalidades> Modalidades { get; set; }
        //Candidatos
        public DbSet<Candidatos> Candidatos { get; set; }
        public DbSet<DatosContacto> DatosContactos { get; set; }
        public DbSet<Educacion> Educacion { get; set; }
        public DbSet<Experiencias> Experiencias { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        //Idiomas
        public DbSet<Idiomas> Idiomas { get; set; }
        public DbSet<CandidatoIdioma> CandidatoIdiomas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación de muchos a uno OfertaEmpleos => Empresas
            modelBuilder.Entity<OfertaEmpleos>().HasOne(o => o.Empresa).WithMany(o => o.OfertaEmpleos).HasForeignKey(e => e.EmpId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OfertaEmpleos>().HasOne(o => o.Provincia).WithMany(o => o.OfertaEmpleos).HasForeignKey(e => e.EmpId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OfertaEmpleos>().HasOne(o => o.Estado).WithMany(e => e.OfertaEmpleos).HasForeignKey(o => o.EstId).OnDelete(DeleteBehavior.Cascade);

            //Relacion de 1 a Muchos Usuarios => Rol            
            modelBuilder.Entity<Usuarios>().HasOne(u => u.Rol).WithMany(r => r.Usuarios).HasForeignKey(u => u.RolId);
            //Relacion de 1 a 1 Usuarios => Estados            
            modelBuilder.Entity<Usuarios>().HasOne(u => u.Estado).WithMany(e => e.Usuarios).HasForeignKey(u => u.EstId);
            //Relacion de 1 a 1 Empresas => Estado
            modelBuilder.Entity<Empresas>().HasOne(e => e.Estado).WithMany(e => e.Empresas).HasForeignKey(u => u.EstId);
            //Relacion de 1 a Muchos Empresas => Industrias
            modelBuilder.Entity<Empresas>().HasOne(e => e.Industria).WithMany(e => e.Empresas).HasForeignKey(u => u.IndId);
            //Relacion de 1 a Muchos Empresas => CantidadEmpleados
            modelBuilder.Entity<Empresas>().HasOne(e => e.CantidadEmpleado).WithMany(e => e.Empresas).HasForeignKey(u => u.CantEmpId).OnDelete(DeleteBehavior.Cascade);
            //Relacion de 1 a muchos OFertasEmpleo => Modalidades
            //
            //Relacion de muchos a mucho Candidatos => Idiomas
            modelBuilder.Entity<CandidatoIdioma>().HasKey(ci => new { ci.CanId, ci.IdiId });
            modelBuilder.Entity<CandidatoIdioma>().HasOne(ci => ci.Idioma).WithMany(i => i.CandidatoIdioma).HasForeignKey(ci => ci.IdiId);
            modelBuilder.Entity<CandidatoIdioma>().HasOne(ci => ci.Candidato).WithMany(c => c.CandidatoIdioma).HasForeignKey(ci => ci.CanId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
