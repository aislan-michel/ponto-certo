using PontoCerto.Domain.Commands;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Queries.Empresa;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.Domain.ValueObjects;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IIdentityService _identityService;
    private readonly INotificator _notificator;
    private readonly IColaboradorRepository _colaboradorRepository;

    public EmpresaService(
        IEmpresaRepository empresaRepository, IIdentityService identityService,
        INotificator notificator,
        IColaboradorRepository colaboradorRepository)
    {
        _empresaRepository = empresaRepository;
        _identityService = identityService;
        _notificator = notificator;
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task Registrar(RegistrarEmpresaCommand command)
    {
        await _identityService.Register(command.UserName, command.Senha, Role.Empresa);

        if (_notificator.HaveNotifications())
        {
            return;
        }

        var usuarioId = await _identityService.GetUserId(command.UserName);

        var empresa = new Empresa(command.Nome, command.Cnpj, command.QuantidadeFuncionarios, usuarioId);
        
        _empresaRepository.Adicionar(empresa);

        await _empresaRepository.Salvar();
    }

    public async Task<ObterColaboradoresQuery> ObterColaboradores(string empresaId)
    {
        var query = new ObterColaboradoresQuery();

        if (string.IsNullOrWhiteSpace(empresaId))
        {
            return query;
        }
        
        var colaboradores = await _colaboradorRepository.Obter(empresaId);

        if (!colaboradores.Any())
        {
            return query;
        }
        
        foreach (var colaborador in colaboradores)
        {
            var dataNascimento = colaborador.DataNascimento.ToString("dd/MM/yyyy");
            var userName = await _identityService.GetUserName(colaborador.UsuarioId.ToString());
            
            query.Colaboradores.Add(new ColaboradorVm(colaborador.Nome.NomeCompleto, dataNascimento, colaborador.Email, userName));
        }

        return query;
    }

    public Task ObterColaborador()
    {
        throw new NotImplementedException();
    }

    public Task RegistrarColaborador()
    {
        throw new NotImplementedException();
    }

    public Task RegistrarColaboradores()
    {
        throw new NotImplementedException();
    }

    public Task AtualizarColaborador()
    {
        throw new NotImplementedException();
    }
}