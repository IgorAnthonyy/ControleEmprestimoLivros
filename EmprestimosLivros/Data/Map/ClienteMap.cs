using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprestimosLivros.Models;

namespace EmprestimosLivros.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
        }
    }
}