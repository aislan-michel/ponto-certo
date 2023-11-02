namespace PontoCerto.Domain.Queries.Admin;

public class ObterEmpresasQueryResult
{
    public ObterEmpresasQueryResult(IEnumerable<EmpresaDto> empresas)
    {
        Empresas = empresas;
    }
    
    public IEnumerable<EmpresaDto> Empresas { get; private set; }
}

public class EmpresaDto
{
    public EmpresaDto(string nome, string cnpj, int quantidadeFuncionarios)
    {
        Nome = nome;
        Cnpj = cnpj;
        QuantidadeFuncionarios = quantidadeFuncionarios;
    }

    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public int QuantidadeFuncionarios { get; private set; }
}