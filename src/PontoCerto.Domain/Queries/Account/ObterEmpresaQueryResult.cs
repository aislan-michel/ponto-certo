namespace PontoCerto.Domain.Queries.Account;

public class ObterEmpresaQueryResult
{
    public ObterEmpresaQueryResult(EmpresaDto empresa)
    {
        Empresa = empresa;
    }

    public EmpresaDto Empresa { get; set; }
}

public class EmpresaDto
{
    public EmpresaDto(string id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public string Id { get; set; }
    public string Nome { get; set; }
}