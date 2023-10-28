using PontoCerto.Domain.Commands.Colaborador;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Notifications;
using PontoCerto.Domain.Queries.Colaborador;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;
using PontoCerto.WebApplication.Infrastructure.Extensions;

namespace PontoCerto.WebApplication.Services;

public class ColaboradorService : IColaboradorSerivce
{
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly IRegistroDePontoRepository _registroDePontoRepository;
    private readonly INotificator _notificator;

    public ColaboradorService(
        IColaboradorRepository colaboradorRepository, 
        IRegistroDePontoRepository registroDePontoRepository, 
        INotificator notificator)
    {
        _colaboradorRepository = colaboradorRepository;
        _registroDePontoRepository = registroDePontoRepository;
        _notificator = notificator;
    }

    public async Task<MeusRegistrosDePontoQueryResult> MeusRegistrosDePonto(Guid colaboradorId)
    {
        var registrosDePonto = await _registroDePontoRepository.GetDataAsync(x => x.ColaboradorId == colaboradorId, default);

        return new MeusRegistrosDePontoQueryResult(registrosDePonto.Select(x =>
            new RegistroDePontoDto(x.ColaboradorId.ToString(), x.Registro)));
    }

    public async Task EfetuarRegistroDePonto(EfetuarRegistroDePontoCommand command)
    {
        var colaborador = await _colaboradorRepository.FirstAsync(x => x.UsuarioId == command.UsuarioId.ToGuid(), default);

        if (colaborador == null)
        {
            _notificator.Add(new Notification("", "colaborador não encontrado"));
            
            return;
        }

        var registroDePonto = new RegistroDePonto(colaborador.Id, command.Marcacao);
        
        _registroDePontoRepository.Add(registroDePonto);

        await _registroDePontoRepository.SaveAsync();
    }
}