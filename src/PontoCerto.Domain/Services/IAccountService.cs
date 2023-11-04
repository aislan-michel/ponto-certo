using PontoCerto.Domain.Commands.Account;
using PontoCerto.Domain.Queries.Account;

namespace PontoCerto.Domain.Services;

public interface IAccountService
{
    Task RegistrarEmpresa(RegistrarEmpresaCommand command);
    Task<ObterEmpresaQueryResult> ObterEmpresa(string cnpj);
    Task RegistrarGerente(RegistrarGerenteCommand command);
    Task SignIn(string userName, string password);
    Task SignOut();
}