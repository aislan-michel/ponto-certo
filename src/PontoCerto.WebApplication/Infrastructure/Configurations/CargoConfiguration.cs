using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoCerto.Domain.Entities;

namespace PontoCerto.WebApplication.Infrastructure.Configurations;

public class CargoConfiguration: IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome).HasColumnType("varchar(255)").IsRequired();
        builder.HasMany(x => x.Colaboradores).WithOne(x => x.Cargo).HasForeignKey(x => x.CargoId);

        builder.ToTable("Cargos");
    }
}