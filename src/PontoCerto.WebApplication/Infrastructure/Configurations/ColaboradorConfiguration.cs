using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoCerto.Domain.Entities;

namespace PontoCerto.WebApplication.Infrastructure.Configurations;

public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x => x.Nome, y =>
        {
            y.Property(x => x.PrimeiroNome).IsRequired().HasColumnType("varchar(120)").HasColumnName("Nome");
            y.Property(x => x.UltimoNome).IsRequired().HasColumnType("varchar(120)").HasColumnName("Sobrenome");
        });
        
        builder.Property(x => x.DataNascimento).IsRequired();
        builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(255)");
        
        builder.HasOne(x => x.Empresa).WithMany(x => x.Colaboradores).HasForeignKey(x => x.EmpresaId);
        builder.HasOne(x => x.Usuario).WithOne(x => x.Colaborador);
        builder.HasOne(x => x.Cargo).WithMany(x => x.Colaboradores).HasForeignKey(x => x.CargoId);
        
        builder.ToTable("Colaboradores");
    }
}