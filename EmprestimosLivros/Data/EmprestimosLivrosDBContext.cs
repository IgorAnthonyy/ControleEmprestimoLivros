using Microsoft.EntityFrameworkCore;
using EmprestimosLivros.Models;

namespace EmprestimosLivros.Data
{
    public class EmprestimosLivrosDBContext : DbContext
    {
        public EmprestimosLivrosDBContext(DbContextOptions<EmprestimosLivrosDBContext> options) : base(options)
        {
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Map.ClienteMap());
            modelBuilder.ApplyConfiguration(new Map.EmprestimoMap());
            modelBuilder.ApplyConfiguration(new Map.LivroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}