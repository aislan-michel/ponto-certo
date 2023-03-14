using PontoCerto.Domain.Commands.Colaborador;
using PontoCerto.Domain.Queries.Colaborador;

namespace PontoCerto.Domain.Services;

public interface IColaboradorSerivce
{
    Task<MeusRegistrosDePontoQueryResult> MeusRegistrosDePonto(Guid colaboradorId);
    Task EfetuarRegistroDePonto(EfetuarRegistroDePontoCommand command);
}