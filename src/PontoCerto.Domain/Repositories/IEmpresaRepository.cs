using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Queries;

namespace PontoCerto.Domain.Repositories;

public interface IEmpresaRepository
{
    Task<ObterEmpresasQuery> Obter();
    Task<Empresa> ObterId(string usuarioId);
    Task<IEnumerable<Empresa>> ObterColaboradores(long id);
    Task<Empresa> ObterColaborador(long colaboradorId);
    Task CadastrarColaborador(Colaborador colaborador); //vincular?
    Task AtualizarColaborador(Colaborador colaborador);
    Task CadastrarColaboradores(IEnumerable<Colaborador> colaboradores);
    Task AtualizarStatusColaborador(long colaboradorId);
    Task<Empresa> ObterNome(Guid empresaId);
    void Adicionar(Empresa empresa);
    Task Salvar();
}