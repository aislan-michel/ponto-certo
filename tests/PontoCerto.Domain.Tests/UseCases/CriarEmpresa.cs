using PontoCerto.Domain.Entities;
using PontoCerto.Domain.ValueObjects;

namespace PontoCerto.Domain.Tests.UseCases;

public class CriarEmpresa
{
    [Fact]
    public void EmpresaXPTO()
    {
        var empresa = new Empresa("Empresa XPTO", "Associação XPTO", "24.628.063/0001-55",
            new Endereco("Rua do teste", "HTTP404", "", "Web", "Bowser"), 2, new List<string>(0));
        
        Assert.NotNull(empresa);
        Assert.NotEmpty(empresa.Cnpj);
        Assert.Empty(empresa.Emails);
    }
}