using BackPrueba_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace BackPrueba_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> USUARIO { get; set; }
        public DbSet<Contacto> CONTACTO { get; set; }
        public DbSet<Telefono> TELEFONO { get; set; }
        public DbSet<Correo> CORREO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(c => c.lstContactos)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.IdUsuario);

            modelBuilder.Entity<Contacto>()
                .HasKey(x => new { x.IdContacto });

            modelBuilder.Entity<Contacto>()
                .HasMany(c => c.lstTelefonos)
                .WithOne(t => t.Contacto)
                .HasForeignKey(t => t.IdContacto);

            modelBuilder.Entity<Contacto>()
                .HasMany(c => c.lstCorreos)
                .WithOne(e => e.Contacto)
                .HasForeignKey(e => e.IdContacto);

            modelBuilder.Entity<Telefono>()
                .HasKey(x => new { x.IdTelefono });

            modelBuilder.Entity<Correo>()
                .HasKey(x => new { x.IdCorreo });
        }
    }
}


