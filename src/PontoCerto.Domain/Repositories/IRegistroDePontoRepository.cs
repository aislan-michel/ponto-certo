using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Repositories;

public interface IRegistroDePontoRepository
{
    Task<IEnumerable<RegistroDePonto>> Obter(Guid colaboradorId);
    void Adicionar(RegistroDePonto registroDePonto);
    Task Salvar();
}