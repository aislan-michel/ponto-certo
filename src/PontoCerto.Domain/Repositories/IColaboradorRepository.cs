using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Repositories;

public interface IColaboradorRepository
{
    Task<Colaborador?> ObterId(string usuarioId);
    Task<Colaborador> ObterId(Guid usuarioId);
    Task<IEnumerable<Colaborador>> Obter(string empresaId);
    void Adicionar(Colaborador colaborador);
    Task Salvar();
}