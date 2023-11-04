using PontoCerto.Domain.Commands.Account;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Queries.Account;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.Domain.ValueObjects;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Services;

public class AccountService : IAccountService
{
    private readonly IIdentityService _identityService;
    private readonly INotificator _notificator;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly ICargoRepository _cargoRepository;

    public AccountService(
        IIdentityService identityService, 
        INotificator notificator, 
        IEmpresaRepository empresaRepository, 
        IColaboradorRepository colaboradorRepository, 
        ICargoRepository cargoRepository)
    {
        _identityService = identityService;
        _notificator = notificator;
        _empresaRepository = empresaRepository;
        _colaboradorRepository = colaboradorRepository;
        _cargoRepository = cargoRepository;
    }

    public async Task RegistrarEmpresa(RegistrarEmpresaCommand command)
    {
        var empresa = new Empresa(command.Nome, command.Cnpj, command.QuantidadeFuncionarios);
        
        _empresaRepository.Add(empresa);

        await _empresaRepository.SaveAsync();
    }

    public async Task<ObterEmpresaQueryResult> ObterEmpresa(string cnpj)
    {
        var empresa = await _empresaRepository.FirstAsync(x => x.Cnpj == cnpj, default) ?? new Empresa(Guid.Empty, string.Empty);

        return new ObterEmpresaQueryResult(new EmpresaDto(empresa.Id, empresa.Nome));
    }

    public async Task RegistrarGerente(RegistrarGerenteCommand command)
    {
        var usuario = new Usuario(command.Username, command.Senha, Role.Gerente);

        await _identityService.Register(usuario);

        if (_notificator.HaveNotifications())
        {
            return;
        }

        var usuarioId = await _identityService.GetUserId(usuario.UserName);

        var cargo = await _cargoRepository.FirstAsync(x => x.Id == command.CargoId, default);
        
        var colaborador = new Colaborador(new Nome(command.PrimeiroNome, command.UltimoNome),
            command.DataNascimento, command.Email, command.EmpresaId, usuarioId, cargo.Id);
        
        _colaboradorRepository.Add(colaborador);

        await _colaboradorRepository.SaveAsync();
    }

    public async Task SignIn(string userName, string password)
    {
        await _identityService.SignIn(userName, password);
    }

    public async Task SignOut()
    {
        await _identityService.SignOut();
    }
}