using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly MyDbContext _myDbContext;

    public ColaboradorRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<IEnumerable<Colaborador>> Obter(string empresaId)
    {
        return await _myDbContext.Colaboradores
            .Where(x => x.EmpresaId == new Guid(empresaId))
            .ToListAsync();
    }
}