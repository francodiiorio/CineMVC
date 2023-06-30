using CineXperience.Models;
using Microsoft.EntityFrameworkCore;

namespace CineXperience.DataBase
{
    public class CineXperienceContext : DbContext
    {
        public CineXperienceContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funcion { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
    }
}
