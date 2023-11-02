using Microsoft.EntityFrameworkCore;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Queries.Admin;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Services;

public class AdminService : IAdminService
{
    private readonly IEmpresaRepository _empresaRepository;
    //todo: remover injeção do dbcontext
    private readonly MyDbContext _dbContext;

    public AdminService(IEmpresaRepository empresaRepository, MyDbContext dbContext)
    {
        _empresaRepository = empresaRepository;
        _dbContext = dbContext;
    }

    public async Task<ObterEmpresasQueryResult> ObterEmpresas()
    {
        var empresas = await _empresaRepository.GetDataAsync(default, default);
        
        return new ObterEmpresasQueryResult(empresas.Select(x => new EmpresaDto(x.Nome, x.Cnpj, x.QuantidadeFuncionarios)));
    }

    public async Task<PerfilDeAcessoQueryResult> ObterPerfisDeAcesso()
    {
        var roles = await _dbContext.Roles.ToListAsync();

        var perfisDeAcesso = roles.Select(x => new PerfilDeAcessoDto(x.Id.ToString(), x.Name));

        return new PerfilDeAcessoQueryResult(perfisDeAcesso);
    }
}