using PontoCerto.Domain.Queries.Admin;

namespace PontoCerto.Domain.Services;

public interface IAdminService
{
    Task<ObterEmpresasQueryResult> ObterEmpresas();
    Task<PerfilDeAcessoQueryResult> ObterPerfisDeAcesso();
}