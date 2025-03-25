using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprestimosLivros.Models;

namespace EmprestimosLivros.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataEmprestimo).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DataDevolucao).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.LivroId).IsRequired();

            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Livro);
        }
    }
}