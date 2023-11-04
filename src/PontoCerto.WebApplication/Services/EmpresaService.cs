using PontoCerto.Domain.Commands.Empresa;
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
    private readonly IIdentityService _identityService;
    private readonly INotificator _notificator;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly ICargoRepository _cargoRepository;

    public EmpresaService(
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

    public async Task<Empresa> ObterEmpresa(string cnpj)
    {
        return await _empresaRepository.FirstAsync(x => x.Cnpj == cnpj, default) ?? new Empresa(Guid.Empty, string.Empty);
    }
    
    public async Task Registrar(RegistrarEmpresaCommand command)
    {
        var empresa = new Empresa(command.Nome, command.Cnpj, command.QuantidadeFuncionarios);
        
        _empresaRepository.Add(empresa);

        await _empresaRepository.SaveAsync();
    }

    public async Task<ObterColaboradoresQueryResult> ObterColaboradores(string empresaId)
    {
        if (string.IsNullOrWhiteSpace(empresaId))
        {
            return new ObterColaboradoresQueryResult();
        }
        
        var colaboradores = await _colaboradorRepository.GetDataAsync(x => x.EmpresaId == empresaId, default);

        if (!colaboradores.Any())
        {
            return new ObterColaboradoresQueryResult();
        }
        
        var query = new ObterColaboradoresQueryResult();
        
        foreach (var colaborador in colaboradores)
        {
            var dataNascimento = colaborador.DataNascimento.ToString("dd/MM/yyyy");
            var userName = await _identityService.GetUserName(colaborador.UsuarioId);

            query.Colaboradores.Add(new ColaboradorDto(colaborador.Nome.NomeCompleto, dataNascimento, colaborador.Email, userName));
        }

        return query;
    }

    public Task ObterColaborador()
    {
        throw new NotImplementedException();
    }

    public async Task RegistrarColaborador(RegistrarColaboradorCommand command)
    {
        var usuario = new Usuario(command.Username, "Teste@123", Role.Colaborador);

        await _identityService.Register(usuario);

        if (_notificator.HaveNotifications())
        {
            return;
        }

        var usuarioId = await _identityService.GetUserId(usuario.UserName);

        var cargo = await _cargoRepository.FirstAsync(x => x.Nome == command.CargoId, default);
        
        var colaborador = new Colaborador(new Nome(command.PrimeiroNome, command.UltimoNome),
            command.DataNascimento, command.Email, command.EmpresaId, usuarioId, cargo.Id);
        
        _colaboradorRepository.Add(colaborador);

        await _colaboradorRepository.SaveAsync();
    }

    public async Task RegistrarColaboradores(IEnumerable<RegistrarColaboradorCommand> commands)
    {
        foreach (var command in commands)
        {
            await RegistrarColaborador(command);
        }
    }

    public Task AtualizarColaborador()
    {
        throw new NotImplementedException();
    }
}