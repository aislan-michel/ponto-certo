using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Queries;
using PontoCerto.Domain.Repositories;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly MyDbContext _myDbContext;
    private readonly IIdentityService _identityService;

    public EmpresaRepository(MyDbContext myDbContext, IIdentityService identityService)
    {
        _myDbContext = myDbContext;
        _identityService = identityService;
    }

    public async Task<ObterEmpresasQuery> Obter()
    {
        var query = new ObterEmpresasQuery();

        var empresas = await _myDbContext.Empresas.ToListAsync();

        foreach (var empresa in empresas)
        {
            var userName = await _identityService.GetUserName(empresa.UsuarioId);

            query.Empresas.Add(new EmpresaVm(empresa.Nome, empresa.Cnpj, empresa.QuantidadeFuncionarios, userName));
        }

        return query;
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