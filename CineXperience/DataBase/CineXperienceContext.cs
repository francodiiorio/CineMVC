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

            builder.Entity<Rol>().HasData(
                new Rol { Id = 1, Name = Displays.RolAdmin, NormalizedName = Displays.RolAdmin.ToUpper() },
                new Rol { Id = 2, Name = Displays.RolEmpleado, NormalizedName = Displays.RolEmpleado.ToUpper() },
                new Rol { Id = 3, Name = Displays.RolCliente, NormalizedName = Displays.RolCliente.ToUpper() },
                new Rol { Id = 4, Name = Displays.RolUsuario, NormalizedName = Displays.RolUsuario.ToUpper() }
            );

            var adminUser = new Usuario
            {
                Nombre= "admin",
                Apellido= "admin",
                Email = "admin@ort.edu.ar"
            };
            var passwordHasher = new PasswordHasher<Usuario>();
            var hashedPassword = passwordHasher.HashPassword(adminUser, Negocio.ContraseniaPred);
            builder.Entity<Usuario>().HasData(
                new Usuario { Id = 1,
                    Nombre=adminUser.Nombre, 
                    Apellido=adminUser.Apellido, 
                    Email= adminUser.Email, 
                    UserName= adminUser.Email, 
                    NormalizedUserName= adminUser.Email.ToUpper(),
                    PasswordHash = hashedPassword,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
                );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId=1, UserId=1});
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
