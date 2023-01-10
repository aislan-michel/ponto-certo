using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Tests.UseCases;

public class CriarEmpresa
{
    [Fact]
    public void EmpresaXPTO()
    {
        var usuarioId = Guid.NewGuid();
        
        var empresa = new Empresa("Empresa XPTO","24.628.063/0001-55", 2,usuarioId.ToString());
        
        Assert.NotNull(empresa);
        Assert.NotEmpty(empresa.Cnpj);
        Assert.Null(empresa.Contato);
    }
}