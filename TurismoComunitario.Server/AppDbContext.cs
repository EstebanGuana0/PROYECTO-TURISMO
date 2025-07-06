using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TurismoComunitario.Server.Models;

namespace TurismoComunitario.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

    }
}