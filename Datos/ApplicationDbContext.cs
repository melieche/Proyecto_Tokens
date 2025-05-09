using Microsoft.EntityFrameworkCore;
using Proyecto_Tokens.Models;
using System.Collections.Generic;

namespace Proyecto_Tokens.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModels> Usuarios { get; set; }
        public DbSet<LoginRegistro> LoginRegistro { get; set; }
    }
}

