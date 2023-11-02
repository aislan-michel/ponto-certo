using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoCerto.Domain.Entities;

namespace PontoCerto.WebApplication.Infrastructure.Configurations;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(120)");
        builder.Property(x => x.Cnpj).IsRequired().HasColumnType("varchar(14)");
        builder.OwnsOne(pt => pt.Endereco, endereco =>
        {
            endereco.Property(e => e.Logradouro).HasColumnType("varchar(200)").HasColumnName("Logradouro");
            endereco.Property(e => e.Numero).HasColumnType("varchar(5)").HasColumnName("Numero");
            endereco.Property(e => e.Cep).HasColumnType("varchar(8)").HasColumnName("Cep");
            endereco.Property(e => e.Bairro).HasColumnType("varchar(100)").HasColumnName("Bairro");
            endereco.Property(e => e.Cidade).HasColumnType("varchar(100)").HasColumnName("Cidade");
            endereco.Property(e => e.Estado).HasColumnType("varchar(50)").HasColumnName("Estado");
        });
        builder.Property(x => x.QuantidadeFuncionarios).IsRequired();
        builder.Property(x => x.Segmento).HasColumnType("varchar(100)");
        builder.Ignore(x => x.Contato);
        
        builder.HasMany(x => x.Colaboradores).WithOne(x => x.Empresa).HasForeignKey(x => x.EmpresaId);
        
        builder.ToTable("Empresas");
    }
}