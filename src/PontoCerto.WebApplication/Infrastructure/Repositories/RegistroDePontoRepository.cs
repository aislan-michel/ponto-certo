using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class RegistroDePontoRepository : Repository<RegistroDePonto>, IRegistroDePontoRepository
{
    public RegistroDePontoRepository(DbContext context) : base(context)
    {
    }
}