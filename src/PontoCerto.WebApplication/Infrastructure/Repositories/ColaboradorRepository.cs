using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
{
    public ColaboradorRepository(DbContext context) : base(context)
    {
    }
}