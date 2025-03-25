using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprestimosLivros.Models;

namespace EmprestimosLivros.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Autor).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Editora).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
        }
    }
}