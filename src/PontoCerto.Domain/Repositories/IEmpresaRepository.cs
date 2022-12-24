using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Repositories;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> ObterColaboradores(long id);
    Task<Empresa> ObterColaborador(long colaboradorId);
    Task CadastrarColaborador(Colaborador colaborador);
    Task AtualizarColaborador(Colaborador colaborador);
    Task CadastrarColaboradores(IEnumerable<Colaborador> colaboradores);
    Task AtualizarStatusColaborador(long colaboradorId);
}