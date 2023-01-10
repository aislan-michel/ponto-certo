using PontoCerto.Domain.Commands;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IIdentityService _identityService;
    private readonly INotificator _notificator;

    public EmpresaService(
        IEmpresaRepository empresaRepository, IIdentityService identityService,
        INotificator notificator)
    {
        _empresaRepository = empresaRepository;
        _identityService = identityService;
        _notificator = notificator;
    }

    public async Task Registrar(RegistrarEmpresaCommand command)
    {
        await _identityService.Register(command.UserName, command.Senha);

        if (_notificator.HaveNotifications())
        {
            return;
        }

        var usuarioId = await _identityService.GetUserId(command.UserName);

        var empresa = new Empresa(command.Nome, command.Cnpj, command.QuantidadeFuncionarios, usuarioId);
        
        _empresaRepository.Adicionar(empresa);

        await _empresaRepository.Salvar();
    }
}