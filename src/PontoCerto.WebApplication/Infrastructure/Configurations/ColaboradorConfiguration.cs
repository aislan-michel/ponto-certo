using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoCerto.Domain.Entities;

namespace PontoCerto.WebApplication.Infrastructure.Configurations;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.HasKey(x => x.Id);
        
        //builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(120)");
        builder.OwnsOne(x => x.Nome, y =>
        {
            y.Property(x => x.PrimeiroNome).IsRequired().HasColumnType("varchar(120)");
            y.Property(x => x.UltimoNome).IsRequired().HasColumnType("varchar(120)");
        });
        
        builder.Property(x => x.DataNascimento).IsRequired();
        builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(255)");
        
        builder.Property(x => x.EmpresaId).IsRequired().HasColumnType("varchar(255)");
        builder.Property(x => x.UsuarioId).IsRequired().HasColumnType("varchar(255)");
        
        builder.ToTable("Colaboradores");
    }
}