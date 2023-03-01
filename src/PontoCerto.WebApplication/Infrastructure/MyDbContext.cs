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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
        modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());

        modelBuilder.Ignore<Usuario>();
        
        base.OnModelCreating(modelBuilder);
    }
}