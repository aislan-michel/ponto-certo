namespace PontoCerto.Domain.Queries.Admin;

public class ObterEmpresasQueryResult
{
    public List<EmpresaVm> Empresas { get; set; } = new();
}

public class EmpresaVm
{
    public EmpresaVm(string nome, string cnpj, int quantidadeFuncionarios, string userName)
    {
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
        UserName = userName;
    }

    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeFuncionarios { get; private set; }
    public string UserName { get; private set; }
}