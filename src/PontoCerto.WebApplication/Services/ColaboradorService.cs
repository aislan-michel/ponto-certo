using PontoCerto.Domain.Commands.Colaborador;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Queries.Colaborador;
using PontoCerto.Domain.Repositories;
using PontoCerto.Domain.Services;

namespace PontoCerto.WebApplication.Services;

public class ColaboradorService : IColaboradorSerivce
{
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly IRegistroDePontoRepository _registroDePontoRepository;

    public ColaboradorService( 
        IColaboradorRepository colaboradorRepository, 
        IRegistroDePontoRepository registroDePontoRepository)
    {
        _colaboradorRepository = colaboradorRepository;
        _registroDePontoRepository = registroDePontoRepository;
    }

    public async Task<MeusRegistrosDePontoQueryResult> MeusRegistrosDePonto(Guid colaboradorId)
    {
        var registrosDePonto = await _registroDePontoRepository.Obter(colaboradorId);

        return new MeusRegistrosDePontoQueryResult
        {
            RegistrosDePonto = registrosDePonto.Select(x => new RegistroDePontoVm(x.ColaboradorId.ToString(), x.Registro))
        };
    }

    public async Task EfetuarRegistroDePonto(EfetuarRegistroDePontoCommand command)
    {
        var colaborador = await _colaboradorRepository.ObterId(command.UsuarioId);

        var registroDePonto = new RegistroDePonto(colaborador.Id, command.Marcacao);
        
        _registroDePontoRepository.Adicionar(registroDePonto);

        await _registroDePontoRepository.Salvar();
    }
}