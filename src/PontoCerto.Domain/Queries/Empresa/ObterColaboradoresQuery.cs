namespace PontoCerto.Domain.Queries.Empresa;

public class ObterColaboradoresQuery
{
    public List<ColaboradorVm> Colaboradores { get; set; } = new();
}

public class ColaboradorVm
{
    public ColaboradorVm(string nome, string empresa, string dataNascimento, string email, string userName)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        UserName = userName;
        Empresa = empresa;
    }
        
    public string Nome { get; set; }
    public string Empresa { get; set; }
    public string DataNascimento { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}

