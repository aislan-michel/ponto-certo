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
    private readonly IRepository<Empresa> _empresaRepository;
    private readonly IIdentityService _identityService;
    //todo: remover injeção do dbcontext
    private readonly MyDbContext _dbContext;

    public AdminService(IRepository<Empresa> empresaRepository, IIdentityService identityService, MyDbContext dbContext)
    {
        _empresaRepository = empresaRepository;
        _identityService = identityService;
        _dbContext = dbContext;
    }

    public async Task<ObterEmpresasQueryResult> ObterEmpresas()
    {
        var empresas = await _empresaRepository.GetDataAsync(default, default);

        var empresasVm = new List<EmpresaVm>();

        foreach (var empresa in empresas)
        {
            var userName = await _identityService.GetUserName(empresa.UsuarioId);

            empresasVm.Add(new EmpresaVm(empresa.Nome, empresa.Cnpj, empresa.QuantidadeFuncionarios, userName));
        }
        
        return new ObterEmpresasQueryResult(empresasVm);
    }

    public async Task<PerfilDeAcessoQueryResult> ObterPerfisDeAcesso()
    {
        var roles = await _dbContext.Roles.ToListAsync();

        var perfisDeAcesso = roles.Select(x => new PerfilDeAcessoVm(x.Id.ToString(), x.Name));

        return new PerfilDeAcessoQueryResult(perfisDeAcesso);
    }
}