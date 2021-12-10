using LivrariaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaBackend.Context
{
    public class LivrariaDbContext : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        public LivrariaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivrariaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
