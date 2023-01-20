using PontoCerto.Domain.Commands;
using PontoCerto.Domain.Queries.Empresa;

namespace PontoCerto.Domain.Services;

public interface IEmpresaService
{
    Task Registrar(RegistrarEmpresaCommand command);
    Task<ObterColaboradoresQuery> ObterColaboradores(string empresaId);
    Task ObterColaborador();
    Task RegistrarColaborador(RegistrarColaboradorCommand command);
    Task RegistrarColaboradores();
    Task AtualizarColaborador();
}