using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly MyDbContext _myDbContext;

    public EmpresaRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<IEnumerable<Empresa>> Obter()
    {
        return await _myDbContext.Empresas.ToListAsync();
    }

    public async Task<Empresa> ObterId(string usuarioId)
    {
        var empresa = await _myDbContext.Empresas.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);

        if (empresa == null)
        {
            throw new Exception($"empresa não encontrada para este usuario: {usuarioId}");
        }

        return empresa;
    }

    public Task<IEnumerable<Empresa>> ObterColaboradores(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Empresa> ObterColaborador(long colaboradorId)
    {
        throw new NotImplementedException();
    }

    public Task CadastrarColaborador(Colaborador colaborador)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarColaborador(Colaborador colaborador)
    {
        throw new NotImplementedException();
    }

    public Task CadastrarColaboradores(IEnumerable<Colaborador> colaboradores)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarStatusColaborador(long colaboradorId)
    {
        throw new NotImplementedException();
    }

    public async Task<Empresa> ObterNome(Guid empresaId)
    {
        return await _myDbContext.Empresas.FirstOrDefaultAsync(x => x != null && x.Id == empresaId);
    }

    public void Adicionar(Empresa empresa)
    {
        _myDbContext.Empresas.Add(empresa);
    }

    public async Task Salvar()
    {
        await _myDbContext.SaveChangesAsync();
    }
}