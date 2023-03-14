using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoCerto.Domain.Entities;

namespace PontoCerto.WebApplication.Infrastructure.Configurations;

public class RegistroDePontoConfiguration : IEntityTypeConfiguration<RegistroDePonto>
{
    public void Configure(EntityTypeBuilder<RegistroDePonto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Registro);
        builder.Property(x => x.ColaboradorId);

        builder.ToTable("RegistrosDePonto");
    }
}