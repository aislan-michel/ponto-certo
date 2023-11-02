using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class CargoRepository : Repository<Cargo>, ICargoRepository
{
    public CargoRepository(DbContext context) : base(context)
    {
    }
}