using PontoCerto.Domain.Commands;

namespace PontoCerto.Domain.Services;

public interface IEmpresaService
{
    Task Registrar(RegistrarEmpresaCommand command);
}