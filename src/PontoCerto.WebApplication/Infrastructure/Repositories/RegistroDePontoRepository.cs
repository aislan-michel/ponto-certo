using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class RegistroDePontoRepository : IRegistroDePontoRepository
{
    private readonly MyDbContext _dbContext;

    public RegistroDePontoRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RegistroDePonto>> Obter(Guid colaboradorId)
    {
        return await _dbContext.RegistrosDePonto.Where(x => x.ColaboradorId == colaboradorId).ToListAsync();
    }

    public void Adicionar(RegistroDePonto registroDePonto)
    {
        _dbContext.RegistrosDePonto.Add(registroDePonto);
    }

    public async Task Salvar()
    {
        await _dbContext.SaveChangesAsync();
    }
}