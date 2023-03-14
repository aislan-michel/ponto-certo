using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.WebApplication.Infrastructure.Configurations;

namespace PontoCerto.WebApplication.Infrastructure;

public class MyDbContext : IdentityDbContext<IdentityUser>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
            
    }

    public DbSet<Empresa> Empresas { get; set; } 
    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<RegistroDePonto> RegistrosDePonto { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
        modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
        modelBuilder.ApplyConfiguration(new RegistroDePontoConfiguration());

        modelBuilder.Ignore<Usuario>();
        
        base.OnModelCreating(modelBuilder);
    }
}