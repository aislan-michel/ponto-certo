using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Tests.UseCases;

public class CriarEmpresa
{
    [Fact]
    public void EmpresaXPTO()
    {
        var empresa = new Empresa("Empresa XPTO","24.628.063/0001-55", 2);
        
        Assert.NotNull(empresa);
        Assert.NotEmpty(empresa.Cnpj);
        Assert.Null(empresa.Contato);
    }
}