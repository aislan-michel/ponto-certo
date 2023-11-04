using PontoCerto.Domain.Commands.Empresa;
using PontoCerto.Domain.Entities;
using PontoCerto.Domain.Queries.Empresa;

namespace PontoCerto.Domain.Services;

public interface IEmpresaService
{
    Task<Empresa> ObterEmpresa(string cnpj);
    Task Registrar(RegistrarEmpresaCommand command);
    Task<ObterColaboradoresQueryResult> ObterColaboradores(string empresaId);
    Task ObterColaborador();
    Task RegistrarColaborador(RegistrarColaboradorCommand command);
    Task RegistrarColaboradores(IEnumerable<RegistrarColaboradorCommand> commands);
    Task AtualizarColaborador();
}