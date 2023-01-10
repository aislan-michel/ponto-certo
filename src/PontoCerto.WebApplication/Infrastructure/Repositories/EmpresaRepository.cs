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

    public void Adicionar(Empresa empresa)
    {
        _myDbContext.Empresas.Add(empresa);
    }

    public async Task Salvar()
    {
        await _myDbContext.SaveChangesAsync();
    }
}