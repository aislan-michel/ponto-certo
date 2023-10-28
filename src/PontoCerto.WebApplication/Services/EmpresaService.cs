using PontoCerto.Domain.Commands.Empresa;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Queries.Empresa;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.Domain.ValueObjects;
using PontoCerto.WebApplication.Infrastructure.Extensions;
using PontoCerto.WebApplication.Infrastructure.Security;

namespace PontoCerto.WebApplication.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IIdentityService _identityService;
    private readonly INotificator _notificator;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly IColaboradorRepository _colaboradorRepository;

    public EmpresaService(
        IIdentityService identityService, 
        INotificator notificator, 
        IEmpresaRepository empresaRepository, 
        IColaboradorRepository colaboradorRepository)
    {
        _identityService = identityService;
        _notificator = notificator;
        _empresaRepository = empresaRepository;
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<string> ObterId(string usuarioId)
    {
        var empresa = await _empresaRepository.FirstAsync(x => x.UsuarioId == usuarioId, default);

        return empresa == null ? string.Empty : empresa.Id.ToString();
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
        
        _empresaRepository.Add(empresa);

        await _empresaRepository.SaveAsync();
    }

    public async Task<ObterColaboradoresQueryResult> ObterColaboradores(string empresaId)
    {
        if (string.IsNullOrWhiteSpace(empresaId))
        {
            return new ObterColaboradoresQueryResult();
        }
        
        var colaboradores = await _colaboradorRepository.GetDataAsync(x => x.EmpresaId == empresaId.ToGuid(), default);

        if (!colaboradores.Any())
        {
            return new ObterColaboradoresQueryResult();
        }
        
        var query = new ObterColaboradoresQueryResult();
        
        foreach (var colaborador in colaboradores)
        {
            var dataNascimento = colaborador.DataNascimento.ToString("dd/MM/yyyy");
            var userName = await _identityService.GetUserName(colaborador.UsuarioId.ToString());

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
        //todo: concatenar conteudo do email antes do '@' + @ + nome d1a empresa em letras minusculas e tudo junto + .com.br 
        
        var usuario = new Usuario($"{command.Email.Split("@").First()}@pontocerto.com.br" , "Teste@123", Role.Colaborador);

        await _identityService.Register(usuario);

        if (_notificator.HaveNotifications())
        {
            return;
        }

        var usuarioId = await _identityService.GetUserId(usuario.UserName);
        
        var colaborador = new Colaborador(new Nome(command.PrimeiroNome, command.UltimoNome),
            command.DataNascimento, command.Email, command.EmpresaId, new Guid(usuarioId));
        
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