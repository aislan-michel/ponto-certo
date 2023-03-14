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

    public async Task<Colaborador> ObterId(string usuarioId)
    {
        return await _myDbContext.Colaboradores
            .Where(x => x.UsuarioId == new Guid(usuarioId)).Select(x => new Colaborador(x.Id)).FirstOrDefaultAsync() 
               ?? throw new InvalidOperationException();
    }

    public async Task<Colaborador> ObterId(Guid usuarioId)
    {
        return await _myDbContext.Colaboradores.Where(x => x.UsuarioId == usuarioId).Select(x => new Colaborador(x.Id)).FirstOrDefaultAsync() 
               ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Colaborador>> Obter(string empresaId)
    {
        return await _myDbContext.Colaboradores
            .Where(x => x.EmpresaId == new Guid(empresaId))
            .ToListAsync();
    }

    public void Adicionar(Colaborador colaborador)
    {
        _myDbContext.Colaboradores.Add(colaborador);
    }

    public async Task Salvar()
    {
        await _myDbContext.SaveChangesAsync();
    }
}