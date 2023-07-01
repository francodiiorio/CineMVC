using CineXperience.Helpers;
using CineXperience.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CineXperience.DataBase
{
    public class CineXperienceContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public CineXperienceContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser<int>>().ToTable("Usuarios");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funcion { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}
